using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    public LayerMask unwalkableMask;
    public float nodeRadius;
    public Vector2 gridWorldSize;
    Node[,] grid;

    float nodeDiameter;
    int gridsizeX, gridsizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridsizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridsizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new Node[gridsizeX, gridsizeY];

        Vector3 gridBottomLeft = transform.position - 
            Vector3.right * gridsizeX / 2 - Vector3.forward * gridsizeY / 2;

        for (int x = 0; x < gridsizeX; x++)
          for (int y = 0; y < gridsizeY; y++)
            {
                Vector3 worldPoint = gridBottomLeft + 
                    Vector3.right * (x * nodeDiameter + nodeRadius) +
                    Vector3.forward*(y*nodeDiameter+nodeRadius);

                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));

                grid[x, y] = new Node(walkable, worldPoint,x,y);
            }
        
    }

    public Node NodeFromWorldPoint(Vector3 worldPos) 
    {
        float percentX = (worldPos.x + gridWorldSize.x / 2) / gridsizeX;
        float percentY = (worldPos.z + gridWorldSize.y / 2) / gridsizeY;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);


        int x = Mathf.RoundToInt((gridsizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridsizeY - 1) * percentY);

        return grid[x, y];
    }

    public List<Node> GetNeighbours(Node node) 
    {
        List<Node> neigbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x==0 && y==0)
                    continue;

                int CheckX = node.GridX + x;
                int CheckY = node.GridY + y;

                if (CheckX >= 0 && CheckX < gridsizeX && CheckY >= 0 && CheckY < gridsizeY)
                    neigbours.Add(grid[CheckX, CheckY]);
            }
        }
        return neigbours;
    }
    public List<Node> path;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if(grid != null) 
        {
            
            foreach (var item in grid)
            {
                Gizmos.color = (item.isWalkable) ? Color.white : Color.red;
                if (path != null)
                    if (path.Contains(item))
                        Gizmos.color = Color.black;
                        
                Gizmos.DrawCube(item.WorldPos, Vector3.one * (nodeDiameter - .05f));
            }
        }

    }
}

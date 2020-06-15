using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFind : MonoBehaviour
{
    public Transform player, target;
    Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    private void Update()
    {
        FindPath(player.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hcost < currentNode.hcost))
                    currentNode = openSet[i];
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                Retrace(startNode, targetNode);
                return;
            }

            foreach (var neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.isWalkable || closedSet.Contains(neighbour))
                    continue;
                int newMov_Cost_to_Neighbour = currentNode.gcost + GetDistance(currentNode, neighbour);
                if (newMov_Cost_to_Neighbour<neighbour.gcost || !openSet.Contains(neighbour))
                {
                    neighbour.gcost = newMov_Cost_to_Neighbour;
                    neighbour.hcost = GetDistance(neighbour, targetNode);
                    neighbour.Parent = currentNode;
                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            
            }
        }
    }

    void Retrace(Node startNode, Node endNode) 
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while(currentNode != startNode) 
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }
        path.Reverse();

        grid.path = path;
    }
    int GetDistance(Node NodeA, Node NodeB) 
    {
        int distanceX = Mathf.Abs(NodeA.GridX - NodeB.GridX);
        int distanceY = Mathf.Abs(NodeA.GridY - NodeB.GridY);

        if (distanceX > distanceY)
            return 14 * distanceY + 10 * (distanceX - distanceY);

        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
}

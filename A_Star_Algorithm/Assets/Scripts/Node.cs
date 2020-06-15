using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isWalkable;
    public Vector3 WorldPos;

    public int GridX;
    public int GridY;

    public int gcost;
    public int hcost;


    public Node Parent;
    public Node(bool isWalkable, Vector3 WorldPos, int GridX, int GridY)
    {
        this.isWalkable = isWalkable;
        this.WorldPos = WorldPos;
        this.GridX = GridX;
        this.GridY = GridY;
    }

    public int fCost
    {
        get
        {
            return gcost + hcost;
        }
    }
}
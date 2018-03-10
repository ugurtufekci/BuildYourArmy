using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public Coordinate GridPosition { get; private set; }

    public TileScript TileRef { get; private set; }

    public int Gcost { get; set; }
    public int Hcost { get; set; }
    public int Fcost { get; set; }

    public Node(TileScript tileRef)
    {
        this.TileRef = tileRef;
        this.GridPosition = tileRef.GridPosition;
    }
    public Node Parent { get; private set; }

    public void CalculateValues(Node parent,Node finish,int gCost)
    {
        this.Parent = parent;
        this.Gcost = parent.Gcost + gCost;
        this.Hcost = (Math.Abs(GridPosition.X - finish.GridPosition.X)) +(Math.Abs(finish.GridPosition.Y-GridPosition.Y))* 10;
        this.Fcost = Gcost + Fcost;
    }
}
 
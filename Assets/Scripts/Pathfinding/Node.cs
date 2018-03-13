﻿using UnityEngine;
using System.Collections;
using System;

public class Node
{

    public Coordinate GridPosition { get; private set; }


    public Vector2 WorldPosition { get; set; }


    public TileScript TileRef { get; private set; }

    public Node Parent { get; private set; }

    public int G { get; set; }

    public int H { get; set; }

    public int F { get; set; }


    public Node(TileScript tileRef)
    {
        this.TileRef = tileRef;
        this.GridPosition = tileRef.GridPosition;
        this.WorldPosition = tileRef.WorldPosition;
    }


    public void CalculateValues(Node parent, Node goal, int gCost)
    {
        this.Parent = parent;
        this.G = parent.G + gCost;
        this.H = ((Math.Abs(GridPosition.X - goal.GridPosition.X)) + Math.Abs((goal.GridPosition.Y - GridPosition.Y))) * 10;
        this.F = G + H;
    }

}

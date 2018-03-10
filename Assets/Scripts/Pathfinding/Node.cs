﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public Coordinate GridPosition { get; private set; }

    public TileScript TileRef { get; private set; }

    public Node(TileScript tileRef)
    {
        this.TileRef = tileRef;
        this.GridPosition = tileRef.GridPosition;
    }
    public Node Parent { get; private set; }

    public void CalculateValues(Node parent)
    {
        this.Parent = parent;
    }
}

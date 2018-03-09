using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Coordinate
{
    //property
    public int X { get; set; }

    public int Y { get; set; }

    public Coordinate(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

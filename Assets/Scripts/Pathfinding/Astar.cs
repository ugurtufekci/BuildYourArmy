﻿using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public static class Astar
{
    private static Dictionary<Coordinate, Node> nodes;

    private static void CreateNodes()
    {
        nodes = new Dictionary<Coordinate, Node>();

        //create a node for each tile
        foreach(TileScript tile in Map.Instance.Tiles.Values)
        {
            nodes.Add(tile.GridPosition, new Node(tile));
        }
    }
    //path generation
    public static void GetPath(Coordinate start)
    {
        if(nodes == null)
        {
            CreateNodes();
        }

        HashSet<Node> openList = new HashSet<Node>();

        Node currentNode = nodes[start];
        //adding start node to openlist
        openList.Add(currentNode);

        //look around the node
        for (int x = -1; x <=1; x++) 
        {
            for (int y = -1; y <=1; y++)
            {
                //current node = x10,y10 become 9,9
                Coordinate neighbourPos = new Coordinate(currentNode.GridPosition.X - x,currentNode.GridPosition.Y-y);

                if (Map.Instance.InMap(neighbourPos) && Map.Instance.Tiles[neighbourPos].Walkable && neighbourPos != currentNode.GridPosition)
                {
                    Node neighbour = nodes[neighbourPos];
                  //  neighbour.TileRef.SpriteRenderer.color = Color.black;
                }
                //Debug.Log(x + "," + y);
                //Debug.Log(neighbourPos.X + "," + neighbourPos.Y);
                
                

            }
        }



        
        //just for the test
        GameObject.Find("TestAstar").GetComponent<TestAstar>().ShowPath(openList);
    }
	
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Astar
{
    private static Dictionary<Coordinate, Node> nodes;
    
    private static void CreateNodes()
    {

        nodes = new Dictionary<Coordinate, Node>();

        foreach (TileScript tile in Map.Instance.Tiles.Values)
        {
            //Adds the node to the node dictionary
            nodes.Add(tile.GridPosition, new Node(tile));
        }
    }


    public static Stack<Node> GetPath(Coordinate start, Coordinate finish)
    {
        if (nodes == null) //If we don't have nodes then we need to create them
        {
            CreateNodes();
        }

        //Creates an open list to be used with the A* algorithm
        HashSet<Node> openList = new HashSet<Node>();

        
        HashSet<Node> closeList = new HashSet<Node>();

        Stack<Node> finalPath = new Stack<Node>();

        //Finds the start node and creates a reference to it called current node
        Node currentNode = nodes[start];

        //Add start node to the openlist
        openList.Add(currentNode);

        while (openList.Count > 0)
        {
           //Do it for all neighbours
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Coordinate neighbourPos = new Coordinate(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);

                    if (Map.Instance.InMap(neighbourPos) && Map.Instance.Tiles[neighbourPos].Walkable && neighbourPos != currentNode.GridPosition)
                    {
                        //Sets the initial value of g to 0
                        int gCost = 0;

                        if (Math.Abs(x - y) == 1)
                        {
                            gCost = 10;
                        }
                        else 
                        {
                            //Check if two nodes are connected diagonally
                            if (!ConnectedDiagonally(currentNode, nodes[neighbourPos]))
                            {
                                continue;
                            }
                            gCost = 14;
                        }

                        //Add  neighbour to the openlist
                        Node neighbour = nodes[neighbourPos];

                        if (openList.Contains(neighbour))
                        {
                            if (currentNode.G + gCost < neighbour.G)
                            {
                                neighbour.CalculateValues(currentNode, nodes[finish], gCost);
                            }
                        }
                        else if (!closeList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                            neighbour.CalculateValues(currentNode, nodes[finish], gCost);
                        }

                    }
                }
            }

            //Moves current node to the closed list
            openList.Remove(currentNode);
            closeList.Add(currentNode);

            if (openList.Count > 0)
            {
                //Sorts the list by F value, and selects the first on the list(smallest one)
                currentNode = openList.OrderBy(n => n.F).First();
            }

            if (currentNode == nodes[finish])
            {
                while (currentNode.GridPosition != start)
                {
                    finalPath.Push(currentNode);
                    currentNode = currentNode.Parent;
                }

                break;
            }
        }
       
        return finalPath;

        
    }


    private static bool ConnectedDiagonally(Node currentNode, Node neighbor)
    {
        //Gets the direction to check
        Coordinate direction = neighbor.GridPosition - currentNode.GridPosition;

        //The first node to check
        Coordinate first = new Coordinate(currentNode.GridPosition.X + direction.X, currentNode.GridPosition.Y);

        //The second node to check
        Coordinate second = new Coordinate(currentNode.GridPosition.X, currentNode.GridPosition.Y + direction.Y);

        //If they are not connected diagonally ==> return false
        if (Map.Instance.InMap(first) && !Map.Instance.Tiles[first].Walkable)
        {
            return false;
        }
        if (Map.Instance.InMap(second) && !Map.Instance.Tiles[second].Walkable)
        {
            return false;
        }

        return true;
    }

}

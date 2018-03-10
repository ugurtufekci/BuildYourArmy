using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Astar
{
    private static Dictionary<Coordinate, Node> nodes;

    private static void CreateNodes()
    {
        nodes = new Dictionary<Coordinate, Node>();

        //create a node for each tile
        foreach (TileScript tile in Map.Instance.Tiles.Values)
        {
            nodes.Add(tile.GridPosition, new Node(tile));
        }
    }
    //path generation
    public static void GetPath(Coordinate start, Coordinate finish)
    {
        if (nodes == null)
        {
            CreateNodes();
        }

        HashSet<Node> openList = new HashSet<Node>();

        HashSet<Node> closeList = new HashSet<Node>();

        Stack<Node> finalPath = new Stack<Node>();
        
        Node currentNode = nodes[start];
        //adding start node to openlist
        openList.Add(currentNode);

        while (openList.Count > 0) //keep searching until the openList is empty
        {
            //look around the node
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Coordinate neighbourPos = new Coordinate(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);

                    if (Map.Instance.InMap(neighbourPos) && Map.Instance.Tiles[neighbourPos].Walkable && neighbourPos != currentNode.GridPosition)
                    {
                        int gCost = 0;

                        if (Mathf.Abs(x - y) == 1)
                        {
                            gCost = 10;
                        }
                        else
                        {
                            gCost = 14;
                        }
                        //adding neighbour to the openlist
                        Node neighbour = nodes[neighbourPos];
                        
                        if (openList.Contains(neighbour))
                        {
                            if (currentNode.Gcost + gCost < neighbour.Gcost) //if its true, current node has a better parent
                            {
                                neighbour.CalculateValues(currentNode, nodes[finish], gCost); //set current node as a parent then calculate values.
                            }
                        }
                        else if (!closeList.Contains(neighbour))//if its not on the open list and its not on the close list,
                        {                                       
                            openList.Add(neighbour);            //this node should be new neighbour.
                            neighbour.CalculateValues(currentNode, nodes[finish], gCost);
                        }
                    }
                }
            }

            openList.Remove(currentNode); //if its discarded from the openlist then this node will be closed(add to the closelist)
            closeList.Add(currentNode);

            if (openList.Count > 0)
            {
                //Sorts the list bu F value then select the first one.
                currentNode = openList.OrderBy(n => n.Fcost).First();
            }

            if(currentNode == nodes[finish])
            {
                while(currentNode.GridPosition != start)
                {
                    finalPath.Push(currentNode);
                    currentNode = currentNode.Parent;
                }
                break;
            }
        }
        
        //just for the test
        GameObject.Find("TestAstar").GetComponent<TestAstar>().ShowPath(openList, closeList);
    }
}

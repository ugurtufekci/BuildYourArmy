using Assets.Scripts;
using System.Collections.Generic;

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

    }
	
}

using UnityEngine;
using System.Collections.Generic;

public class Map : Singleton<Map>
{
    [SerializeField]
    private GameObject tile;

    
    [SerializeField]
    private Transform alltiles;

    private Coordinate mapSize;

    private Coordinate soldierSpawn, soldierGoal;

    [SerializeField]
    private GameObject soldierSpawnPrefab;


    [SerializeField]
    private GameObject soldierGoalPrefab;

    public SpawnPoints SoldierSpawn { get; set; }

    private Stack<Node> fullPath;

    public Dictionary<Coordinate, TileScript> Tiles { get; set; }

    Vector3 newPosition;
    //TileSize is a property "not field", so we can access from other scripts
    //Caltulates the size of tiles then return
    public float TileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    public Stack<Node> Path
    {
        get
        {
            if (fullPath == null)
            {
                GeneratePath();
            }

            return new Stack<Node>(new Stack<Node>(fullPath));
        }
    }


    // Use this for initialization
    void Start()
    {
        
        CreateTiles();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void CreateTiles()
    {

        Tiles = new Dictionary<Coordinate, TileScript>();

        //Initializing the starting tile close to the left corner(next to the production menu). this will be optimized later.
        Vector3 tileStart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 5.0f, Screen.height));
        int i, j;
        for (j = 0; j < 10; j++) //row
        {
            for (i = 0; i < 8; i++)  //column
            {
                PlaceTiles(i, j, tileStart);

            }
        }
        mapSize = new Coordinate(10, 8);

        SoldierSpawnAndGoal();
    }

    private void PlaceTiles(int i, int j, Vector3 tileStart)
    {
        TileScript newTile = Instantiate(tile).GetComponent<TileScript>();

        newTile.Setter(new Coordinate(i, j), new Vector3(tileStart.x + TileSize * i, tileStart.y - TileSize * j, 0), alltiles);
    }

    public bool InMap(Coordinate pos)
    {
        return pos.X >= 0 && pos.Y >= 0 && pos.X < mapSize.X && pos.Y < mapSize.Y;
    }
    
    private void SoldierSpawnAndGoal()
    {
        //this coordinates are static now just for testing.
        //Spawns coordinate for soldier
        soldierSpawn = new Coordinate(0, 0);
        GameObject tmp = (GameObject)Instantiate(soldierSpawnPrefab, Tiles[soldierSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
        SoldierSpawn = tmp.GetComponent<SpawnPoints>();

        if (Input.GetMouseButtonDown(0)) //Craete a raycast if we click a tile
        {
            Debug.Log("adsasdasdasda");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            int a, b;
            if (hit.collider.tag == "LandTag")
            {
                a = (int)transform.position.x;
                b = (int)transform.position.x;
                Debug.Log(a + "dawsda " + b);
                soldierGoal = new Coordinate(a,b);
                Instantiate(soldierGoalPrefab, Tiles[soldierGoal].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
            }
        }
        

        //Goal coordinate for soldier
      //  soldierGoal = new Coordinate(3, 7);
       



       
    }
    public void GeneratePath()
    {
        //Generates a path from start to finish and save the path
        fullPath = Astar.GetPath(soldierSpawn, soldierGoal);
    }

}


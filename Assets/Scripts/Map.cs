using UnityEngine;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class Map : Singleton<Map> {

        [SerializeField]
        private GameObject tile;

        [SerializeField]
        private Transform alltiles;

        private Coordinate mapSize;

        public Dictionary<Coordinate, TileScript> Tiles { get; set; }

        //TileSize is a property "not field", so we can access from other scripts
        //Caltulates the size of tiles then return
        public float TileSize   
        {
            get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
        }

        


        // Use this for initialization
        void Start ()
        {
            CreateTiles();
		
        }
	
        // Update is called once per frame
        void Update ()
        {
		
        }
        
        private void CreateTiles()
        {
            Tiles = new Dictionary<Coordinate, TileScript>();
            
            //Initializing the starting tile close to the left corner(next to the production menu). this will be optimized later.
            Vector3 tileStart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 5.0f, Screen.height));
            int i, j;
            for ( j = 0; j < 10; j++) //row
            {
                
                for( i = 0; i < 8; i++)  //column
                {
                   PlaceTiles(i, j, tileStart);
                    
                }
            }
            mapSize = new Coordinate(10, 8);
        }
        private void PlaceTiles(int i, int j, Vector3 tileStart)
        {
            TileScript newTile = Instantiate(tile).GetComponent<TileScript>();
          
            newTile.Setter(new Coordinate(i, j), new Vector3(tileStart.x + TileSize * i, tileStart.y - TileSize * j, 0),alltiles);
            // Tiles added to dictionary
           
         
        }

        public bool InMap(Coordinate pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < mapSize.X && pos.Y < mapSize.Y;
        }

    }
}

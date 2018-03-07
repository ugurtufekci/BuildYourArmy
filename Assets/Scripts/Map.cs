using UnityEngine;
using UnityEngine.Experimental.UIElements;
using System.Collections.Generic;
namespace Assets.Scripts
{
    public class Map : Singleton<Map> {

        [SerializeField]
        private GameObject tile;

        [SerializeField]
        private Transform alltiles;

        //TileSize is a property "not field", so we can access from other scripts
        //Caltulates the size of tiles then return
        public float TileSize   
        {
            get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
        }

        public Dictionary<Coordinate,TileScript> Tiles { get; set; }


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

            int j;
            //Initializing the starting tile close to the left corner(next to the production menu). this will be optimized later.
            Vector3 tileStart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 5.0f, Screen.height)); 
            for( j = 0; j < 10; j++) //row
            {
                int i;
                for( i = 0; i < 8; i++)  //column
                {
                    
                    PlaceTiles(i, j, tileStart);
                }
            }
        }
        private void PlaceTiles(int i, int j, Vector3 tileStart)
        {
            TileScript newTile = Instantiate(tile).GetComponent<TileScript>();
          
            newTile.Setter(new Coordinate(i, j), new Vector3(tileStart.x + TileSize * i, tileStart.y - TileSize * j, 0),alltiles);
            // Tiles added to dictionary
            Tiles.Add(new Coordinate(i, j), newTile); 

            
        }
     
    }
}

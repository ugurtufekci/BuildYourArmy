using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField]
    private GameObject tile;
    //property not a field, so we can access from other scripts
    //caltulates the size of tiles then return
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
        Vector3 tileStart = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/5, (Screen.height/1.111f))); //init top-left corner to 
        for(int j = 0; j < 9; j++) //row
        {
            for(int i = 0; i < 8; i++)  //column
            {
                PlaceTiles(i, j, tileStart);
            }
        }
    }
    private void PlaceTiles(int i, int j, Vector3 tileStart)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector3(tileStart.x + (TileSize * i), tileStart.y - (TileSize * j),0);
    }
}

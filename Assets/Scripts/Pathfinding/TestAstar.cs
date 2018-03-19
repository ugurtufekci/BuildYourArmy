/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestAstar : MonoBehaviour
{

    private TileScript start, finish;

    [SerializeField]
    private Sprite blankTile;

    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private GameObject debugTilePrefab;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ClickTile();

        //Generates a path when we click space (for testing)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Astar.GetPath(start.GridPosition, finish.GridPosition);
        }
    }

    private void ClickTile()
    {
        if (Input.GetMouseButtonDown(1)) //Craete a raycast if we click a tile
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                TileScript tmp = hit.collider.GetComponent<TileScript>();

                if (tmp != null)
                {
                    if (start == null)
                    {
                        start = tmp;
                        //CreateDebugTile(start.WorldPosition, new Color32(255, 135, 0, 255));

                    }
                    else if (finish == null)
                    {
                        finish = tmp;
                       // CreateDebugTile(finish.WorldPosition, new Color32(255, 0, 0, 255));

                    }
                }
            }
        }
    }

    
}*/


using System.Collections.Generic;
using UnityEngine;

public class TestAstar : MonoBehaviour {

    [SerializeField]
    private TileScript start, finish;

	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {

        ClickTile();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Astar.GetPath(start.GridPosition);
        }
    }
    private void ClickTile()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.collider != null)
            {
                TileScript temp = hit.collider.GetComponent<TileScript>();

                if(temp != null)
                {
                    if(start == null)
                    {
                        start = temp; 
                        start.SpriteRenderer.color = new Color32(255, 132, 0, 255);
                        start.Debugging = true;
                    }
                    else if(finish == null)
                    {
                        finish = temp;
                        finish.Debugging = true;
                        finish.SpriteRenderer.color = new Color32(255, 0, 0, 255);
                    }
                }
            }
        }
        
    }

    public void ShowPath(HashSet<Node> openList)
    {
        foreach(Node node in openList)
        {
            node.TileRef.SpriteRenderer.color = Color.blue;
            
        }
    }
}

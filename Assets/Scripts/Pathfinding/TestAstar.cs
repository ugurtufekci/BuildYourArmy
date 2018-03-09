
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
    }
    private void ClickTile()
    {
        if (Input.GetMouseButtonDown(0))
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
                        
                    }
                    else if(finish == null)
                    {
                        finish = null;
                    }
                }
            }
        }
    }
}

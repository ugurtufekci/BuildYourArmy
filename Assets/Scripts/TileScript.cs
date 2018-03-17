using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
     public Coordinate GridPosition { get; private set; }

    //Control the tile is avaliable or not
    public bool IsEmpty { get; private set; }
    private Building myBuilding;
    //center of each tile
    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    private Color32 unavaliableColor = new Color32(255, 118, 118, 255);
    private Color32 avaliableColor = new Color32(96, 255, 90, 255);


    public SpriteRenderer spriteRenderer { get; set; }

    public bool Debugging { get; set; }

    public bool Walkable { get; set; }

   
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Setter(Coordinate gridPos, Vector3 startPos, Transform parent)
    {
        Walkable = true;
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = startPos;
        transform.SetParent(parent);
        Map.Instance.Tiles.Add(gridPos, this);

    }

    void OnMouseDown()
    {
         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
       
        //if user pick a barrack, we have to set each tile property IsEmpty=false for 3x3 surface.
        if (hit.collider.tag == "BarrackTag")
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Debug.Log((GridPosition.X + i) + " " + (GridPosition.Y + j));
                    IsEmpty = false;
                    Walkable = false;
                }
            }

        }
        //if user pick a powerplant, we have to set each tile property IsEmpty=false for 2x3 surface.
        else if (hit.collider.tag == "PowerPlantTag")
        {
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Debug.Log((GridPosition.X + i) + " " + (GridPosition.Y + j));
                    IsEmpty = false;
                    Walkable = false;
                }
            }
        }


    }

    
    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton != null)
        {
            if (IsEmpty && !Debugging)//Colors the tile green
            {
                ColorTile(avaliableColor);
            }
            if (!IsEmpty && !Debugging)//Colors the tile red
            {
                ColorTile(unavaliableColor);
            }
            else if (Input.GetMouseButtonDown(0))//Places a building if there is spot on the tile
            {
                PlaceBuilding();
            }
        }
        else if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton == null && Input.GetMouseButtonDown(0))
        {
            if (myBuilding != null)
            {
                GameManager.Instance.ChosenBuilding(myBuilding);
            }
            else
            {
                GameManager.Instance.IgnoredBuilding();
            }
        }

    }

    private void OnMouseExit()
    {
        if (!Debugging)
        {
            ColorTile(Color.white);
        }
    }

    private void PlaceBuilding()
    {
        GameObject building = (GameObject)Instantiate(GameManager.Instance.ClickedButton.BuildingPrefab, transform.position, Quaternion.identity);
       
        building.transform.SetParent(transform);
        OnMouseDown();
       
        IsEmpty = false;

        ColorTile(Color.white);

        GameManager.Instance.ClickBuildingButtonEveryTime();
        Walkable = false;
    }

    

    public void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}

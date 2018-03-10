using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
     public Coordinate GridPosition { get; private set; }

    //Control the tile is avaliable or not
    public bool IsEmpty { get; private set; }

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


    public SpriteRenderer SpriteRenderer { get; set; }

    public bool Debugging { get; set; }

    public bool Walkable { get; set; }

    // Use this for initialization
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
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

    private void OnMouseOver()
    {
        //place the building on a tile. if mouse is over the button dont do that.
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton != null)
        {
            if (IsEmpty && !Debugging)
            {
                ColorTile(avaliableColor);
            }
            if (!IsEmpty && !Debugging)
            {
                ColorTile(unavaliableColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
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

        IsEmpty = false;

        ColorTile(Color.white);

        GameManager.Instance.ClickBuildingButtonEveryTime();
        Walkable = false;
    }

    public void ColorTile(Color newColor)
    {
        SpriteRenderer.color = newColor;
    }
}

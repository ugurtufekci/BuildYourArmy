using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour {


    public Coordinate GridPosition { get; private set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setter(Coordinate gridPos,Vector3 startPos,Transform parent)
    {
        this.GridPosition = gridPos;
        transform.position = startPos;
        transform.SetParent(parent);
        // Map.Instance.Tiles.Add(gridPos, this);

    }

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
    }
    private void PlaceBuilding()
    {
        GameObject building = (GameObject)Instantiate(GameManager.Instance.ClickedButton.BuildingPrefab, transform.position, Quaternion.identity);
        building.transform.SetParent(transform); // center of a building is a child of a tile now.

        GameManager.Instance.ClickBuildingButtonEveryTime();
    }
}

using UnityEngine;

public class GameManager : Singleton<GameManager> {

    //tilescript can access the clickButton and get the prefab and place the prefab on the tile
    public BuildingButton ClickedButton { get; private set; } 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //when we click the button it selects a building then set a reference into ClickButton
    public void SelectBuilding(BuildingButton buildingButton) 
    {
        this.ClickedButton = buildingButton;
        Hover.Instance.ShowHover(buildingButton.Sprite);
    }

    public void ClickBuildingButtonEveryTime()
    {
        //hide hover when user create one building.
        Hover.Instance.HideHover();
        ClickedButton = null;
    }

    private void EscapeBuilding()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.HideHover();
        }
    }

    /*private IEnumerator SpawnSoldier()
    {

    }*/
}

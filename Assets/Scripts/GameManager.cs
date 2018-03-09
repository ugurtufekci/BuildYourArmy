using System.Collections;
using System.Collections.Generic;
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
        ClickedButton = null;
    }

    /*private IEnumerator SpawnSoldier()
    {

    }*/
}

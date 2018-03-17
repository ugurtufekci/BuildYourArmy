using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    //tilescript can access the clickButton and get the prefab and place the prefab on the tile
    public BuildingButton ClickedButton { get;  set; }

    public ObjectPool Pool { get; set; }

    [SerializeField]
    private GameObject informationPanel;
    
    private Building selectedBuilding;

    private void Awake()
    {
        Pool = GetComponent<ObjectPool>();
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        EscapeBuilding();

    }

    //when we click the button it selects a building then set a reference into ClickButton
    public void SelectBuilding(BuildingButton buildingButton) 
    {
        this.ClickedButton = buildingButton;
        Hover.Instance.ShowHover(buildingButton.Sprite);
    }

    public void ChosenBuilding(Building building)
    {
        if (selectedBuilding != null)//If we have selected a building
        {
            //Selects the building
            selectedBuilding.Select();
        }

        //Sets the selected building
        selectedBuilding = building;

        //Selects the building
        selectedBuilding.Select();



        informationPanel.SetActive(true);


    }

    public void IgnoredBuilding()
    {
        //If we have a selected building
        if (selectedBuilding != null)
        {
            //Calls select to deselect it
            selectedBuilding.Select();
        }

        informationPanel.SetActive(false);

        //Remove the reference to the building
        selectedBuilding = null;

    }

    public void ClickBuildingButtonEveryTime()
    {
        //hide hover when user create one building.
        Hover.Instance.HideHover();
        
    }

    private void EscapeBuilding()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.HideHover();
        }
    }

    public void StartWave()
    {
        StartCoroutine(SpawnSoldier());
    }

   
    private IEnumerator SpawnSoldier()
    {

        string type = string.Empty;
         type = "Soldier";
        
        //Requests the soldier from the pool
        Soldier soldier = Pool.GetObject(type).GetComponent<Soldier>();

        soldier.Spawn();

        yield return new WaitForSeconds(2.0f);
    }
}

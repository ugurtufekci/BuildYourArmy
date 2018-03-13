using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    //tilescript can access the clickButton and get the prefab and place the prefab on the tile
    public BuildingButton ClickedButton { get;  set; }

    public ObjectPool Pool { get; set; }

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

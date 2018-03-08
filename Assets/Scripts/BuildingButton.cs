using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour {

    [SerializeField]
    private GameObject buildingPrefab;

    public GameObject BuildingPrefab
    {
        get
        {
            return buildingPrefab;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

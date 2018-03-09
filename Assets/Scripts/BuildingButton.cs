using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour {

    [SerializeField]
    private GameObject buildingPrefab;

    [SerializeField]
    private Sprite sprite;

    public GameObject BuildingPrefab
    {
        get
        {
            return buildingPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
     }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

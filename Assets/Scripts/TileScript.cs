using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {


    public Coordinate GridPosition { get; private set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setter(Coordinate gridPos,Vector3 startPos)
    {
        this.GridPosition = gridPos;
        transform.position = startPos;
    }
}

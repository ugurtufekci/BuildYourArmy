﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select()
    {
        mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
       
    }
}

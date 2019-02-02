﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        CommonData.prefabs = FindObjectOfType<PrefabList>();
        CommonData.controllers_Events = FindObjectsOfType<ControllerEvents>();
    }
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

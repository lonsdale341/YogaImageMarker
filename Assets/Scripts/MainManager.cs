using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CommonData.prefabs = FindObjectOfType<PrefabList>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

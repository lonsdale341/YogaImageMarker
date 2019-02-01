using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabList : MonoBehaviour
{
    public MaterialEntry[] objectMaterials;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public struct MaterialEntry
{
    public MaterialEntry(string nameAnimation)
    {
        this.nameAnimation = nameAnimation;
        Materials=new List<Material>();
    }
    public string nameAnimation;
    public List<Material> Materials;
}
[System.Serializable]
public struct LabellEntry
{
    public LabellEntry(string nameAnimation,GameObject label)
    {

        this.Labels = label;
        this.nameAnimation = nameAnimation;
    }
    public string nameAnimation;
    public GameObject Labels;
}

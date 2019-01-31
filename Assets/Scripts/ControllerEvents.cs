using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerEvents : MonoBehaviour
{
    public GameObject Body;
    private int stateFade;
    public Material mater;
    // Use this for initialization
    void Start()
    {
        stateFade = 0;
        foreach (MaterialEntry entry in CommonData.prefabs.objectMaterials)
        {
            foreach (Material materialEntry in entry.Materials)
            {
                materialEntry.SetColor("_Color", new Vector4(1, 1f, 1f, 1f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFade()
    {
        switch (stateFade)
        {
            case 0:
                stateFade = 1;
                SetMaterialTransparent();
                iTween.FadeTo(Body, 0, 1);
                break;
            case 1:
                stateFade = 0;
                iTween.FadeTo(Body, 1, 1);
                Invoke("SetMaterialOpaque", 1.0f);
                break;
        }
       
    }
    public void GetAnimationEvent(string message)
    {
        foreach (MaterialEntry entry in CommonData.prefabs.objectMaterials)
        {
            foreach (Material materialEntry in entry.Materials)
            {
                materialEntry.SetColor("_Color", new Vector4(1, 1f, 1f, 1f));
            }
        }
        var items = CommonData.prefabs.objectMaterials.Where(item => item.nameAnimation == message);
        foreach (MaterialEntry entry in items)
        {
            foreach (Material materialEntry in entry.Materials)
            {
                materialEntry.SetColor("_Color", new Vector4(0, 7f / 255f, 231f / 255f, 1f));
            }
        }
        
        Debug.Log(message);

    }
    private void SetMaterialTransparent()
    {

        foreach (Material m in Body.GetComponent<Renderer>().materials)
        {

            m.SetFloat("_Mode", 2);

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            m.SetInt("_ZWrite", 0);

            m.DisableKeyword("_ALPHATEST_ON");

            m.EnableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = 3000;

        }

    }
    private void SetMaterialOpaque()
    {

        foreach (Material m in Body.GetComponent<Renderer>().materials)
        {

            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);

            m.SetInt("_ZWrite", 1);

            m.DisableKeyword("_ALPHATEST_ON");

            m.DisableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = -1;

        }

    }
}

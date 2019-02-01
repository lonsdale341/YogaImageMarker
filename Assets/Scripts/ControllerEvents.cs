using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControllerEvents : MonoBehaviour
{
    public GameObject Body;
    public GameObject Muscule;
    private int stateFade;
    public Material mater;
    public Renderer[] MusculeReners;
    public List<Material> MusculeMaterials;
    public bool IsFade;
    // Use this for initialization
    void Start()
    {
        IsFade = true;
        MusculeReners = Muscule.GetComponentsInChildren<Renderer>();
        foreach (Renderer musculeRender in MusculeReners)
        {
            foreach (Material m in musculeRender.materials)
            {
                MusculeMaterials.Add(m);
               //if (MusculeMaterials.Count(item=>item.name==m.name)==0)
               //{
               //    
               //}
                
            }
        }

        stateFade = 0;
        Muscule_SetMaterialTransparent();
        Body_SetMaterialOpaque();
        iTween.FadeTo(Muscule, 0, 0.001f);
        // foreach (MaterialEntry entry in CommonData.prefabs.objectMaterials)
        // {
        //     foreach (Material materialEntry in entry.Materials)
        //     {
        //         materialEntry.SetColor("_Color", new Vector4(1, 1f, 1f, 1f));
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFade()
    {
        if (IsFade)
        {
            IsFade = false;
            switch (stateFade)
            {
                case 0:
                    stateFade = 1;
                    Body_SetMaterialTransparent();
                    iTween.FadeTo(Body, 0, 1);
                    iTween.FadeTo(Muscule, 1, 0.5f);
                    Invoke("Muscule_SetMaterialOpaque", 0.5f);
                    StartCoroutine(SetIsFade());
                    break;
                case 1:
                    stateFade = 0;
                    Muscule_SetMaterialTransparent();
                    iTween.FadeTo(Muscule, 0, 1);
                    iTween.FadeTo(Body, 1, 0.5f);
                    Invoke("Body_SetMaterialOpaque", 0.5f);
                    StartCoroutine(SetIsFade());
                    break;
            }
        }
        

    }

    IEnumerator SetIsFade()
    {
        yield return new WaitForSeconds(1.5f);
        IsFade = true;
    }
    public void GetAnimationEvent(string message)
    {
        
        Debug.Log(message);

    }

    public void GetAnimationEvent_Label(string message)
    {

    }
    private void Body_SetMaterialTransparent()
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
    private void Muscule_SetMaterialTransparent()
    {
        foreach (Material m in MusculeMaterials)
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
    private void Body_SetMaterialOpaque()
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
    private void Muscule_SetMaterialOpaque()
    {
        
            foreach (Material m in MusculeMaterials)
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

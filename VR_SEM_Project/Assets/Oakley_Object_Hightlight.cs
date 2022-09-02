using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Object_Hightlight : MonoBehaviour
{
    // Start is called before the first frame update
    public float outline_width = 1;
    public Material outline_mat;


   // public 
    void Start()
    {
        MeshRenderer[] mesh = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach ( MeshRenderer m in mesh)
        {
            Material mat = m.material;
            outline_mat.mainTexture = mat.mainTexture;
            outline_mat.SetColor("_Color",mat.GetColor("_Color"));
            m.material = outline_mat;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

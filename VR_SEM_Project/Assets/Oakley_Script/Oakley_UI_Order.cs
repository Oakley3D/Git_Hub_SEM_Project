using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_UI_Order : MonoBehaviour
{
    public Transform parent;

    public int last_order = 1;

    public bool Auto_setting = false;

    public void OnEnable()
    {
        if (Auto_setting) transform.SetSiblingIndex(parent.transform.childCount - last_order);
    }

    public void Set_Order()
    {
        transform.SetSiblingIndex(parent.transform.childCount - last_order);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

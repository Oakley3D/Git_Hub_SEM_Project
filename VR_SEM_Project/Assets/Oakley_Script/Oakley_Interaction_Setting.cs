using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Interaction_Setting : MonoBehaviour
{
    [Header("互動對象名稱設定")]
    public bool use_obj_name = true;
    public string custom_name = "";
    // Start is called before the first frame update
    void Start()
    {
        if (use_obj_name) custom_name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

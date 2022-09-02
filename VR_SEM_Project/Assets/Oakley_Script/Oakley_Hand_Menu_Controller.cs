using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Hand_Menu_Controller : MonoBehaviour
{
    public bool is_use = false;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (target) target.SetActive(is_use);
    }

    public void Set_Visible()
    {
        is_use = !is_use;
        if (target) target.SetActive(is_use);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

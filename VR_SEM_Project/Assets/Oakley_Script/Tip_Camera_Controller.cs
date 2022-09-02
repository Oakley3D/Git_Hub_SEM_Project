using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip_Camera_Controller : MonoBehaviour
{
    public static Tip_Camera_Controller instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        GetComponent<Canvas>().worldCamera = Camera.main;           
    }

    public void Show_Tip()
    {
        GetComponent<Animator>().SetTrigger("show");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Canvas>().worldCamera == null)
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}

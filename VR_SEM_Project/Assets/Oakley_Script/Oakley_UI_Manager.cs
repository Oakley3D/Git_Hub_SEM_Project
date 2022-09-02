using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_UI_Manager : MonoBehaviour
{
    public static Oakley_UI_Manager instance;
    public GameObject final_ui;
    public GameObject initial_ui;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

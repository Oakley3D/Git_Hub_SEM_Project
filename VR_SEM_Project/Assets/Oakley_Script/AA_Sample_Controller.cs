using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA_Sample_Controller : MonoBehaviour
{
    public GameObject normal_status, ready_sample;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Change_Normal()
    {
        normal_status.SetActive(true);
        ready_sample.SetActive(false);
    }
    public void Change_Reday()
    {
        ready_sample.SetActive(true);
        normal_status.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

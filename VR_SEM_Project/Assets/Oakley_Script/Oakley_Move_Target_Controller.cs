using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Move_Target_Controller : MonoBehaviour
{

    Camera follow_cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow_cam == null)
        {
            follow_cam = Camera.main;
        }
        else
        {
            Vector3 dir = follow_cam.transform.position - transform.position;
            dir.y = 0;
            dir.Normalize();

            transform.forward = dir;
        }
    }
}

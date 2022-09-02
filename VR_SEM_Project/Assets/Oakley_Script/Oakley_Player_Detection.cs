using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_Player_Detection : MonoBehaviour
{
    public Transform ref_camera;
    public GameObject detect_object;
    
    public string detect_tag;
    bool is_touch = false;
    public bool use_auto_redetect = false;
    public UnityEvent touch_event;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == detect_object || other.tag == detect_tag)
        {

            Debug.Log(other.name);
            if (is_touch == false)
            {
                is_touch = true;
                touch_event.Invoke();
                if (use_auto_redetect) Invoke("Cancel_Touch", 1);
            }

        }
    }

    void Cancel_Touch()
    {
        is_touch = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detect_object || other.tag == detect_tag)
        {
            is_touch = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ref_camera == null)
        {
            if (Camera.main) ref_camera = Camera.main.transform;
        }
        if (ref_camera)
            transform.position = new Vector3(ref_camera.transform.position.x, transform.position.y, ref_camera.transform.position.z);    
    }
}

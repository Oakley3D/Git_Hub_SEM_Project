using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Trasnform_Set_Controller : MonoBehaviour
{
    public Vector3 pos, roi;
    public Transform ref_transform;
    [Header("檢查物件是否低於初始位置")]
    public bool use_detect_obj_pos = false;
    public  float below_value_will_reset = 0.2f;
    [Header("自動檢查物件是否掉落")]
    public bool auto_detect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Set_Transform()
    {
        if (ref_transform != null)
        {
            if (use_detect_obj_pos)
            {
                if (ref_transform.position.y - transform.position.y > below_value_will_reset)
                {
                    transform.position = ref_transform.position;
                    transform.rotation = ref_transform.rotation;
                }
            }
            else
            {
                transform.position = ref_transform.position;
                transform.rotation = ref_transform.rotation;
            }
        }
        else
        {
            transform.position = pos;
            transform.eulerAngles = roi;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (auto_detect)
        {
            if (ref_transform != null)
            {
                if (use_detect_obj_pos)
                {
                    if (ref_transform.position.y - transform.position.y > below_value_will_reset)
                    {
                        transform.position = ref_transform.position;
                        transform.rotation = ref_transform.rotation;
                    }
                }
               
            }
        }
        
    }
}

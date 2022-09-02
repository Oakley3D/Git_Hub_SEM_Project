using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_UI_Drag : MonoBehaviour
{

    public GameObject follow_parent;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        // parent = transform.parent.gameObject;
        if (parent == null)
        {
            if (transform.GetComponentInParent<Oakley_UI_Step_Super_Manager>())
            {
                parent = transform.GetComponentInParent<Oakley_UI_Step_Super_Manager>().transform.gameObject;
            }
        }
    }
    public void PointDown()
    {
        /*
        parent.transform.parent = follow_parent.transform;
        if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("開始_拖曳提示介面");
*/
        //Debug.LogError("point down");
    }

    public void PointUp()
    {
        /*
        parent.transform.parent = null;
        if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("停止_拖曳提示介面");
*/
        //Debug.LogError("point up");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

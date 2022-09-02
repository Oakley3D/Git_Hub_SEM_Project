using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_UI_Browser_Check : MonoBehaviour
{
    public UnityEvent check_event;

    public bool is_selected = false;

    public void Selected()
    {
        is_selected = true;
    }

    public void Check_File()
    {
        if (is_selected) check_event.Invoke();
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

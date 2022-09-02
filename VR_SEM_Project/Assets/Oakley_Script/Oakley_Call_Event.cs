using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_Call_Event : MonoBehaviour
{
    public float repeat_timer = 3;
    public UnityEvent repeat_event;
    public void Play()
    {
        repeat_event.Invoke();
        Debug.Log("Full the liquid");
    }

    public void OnDisable()
    {
        CancelInvoke();        
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating("Play", 0, repeat_timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

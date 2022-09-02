using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_Move_Tutorial : MonoBehaviour
{
    public GameObject[] targets;
    int cur_index = 0;
    public UnityEvent finish_event;
    public void Move_Next()
    {
        foreach (GameObject o in targets) o.SetActive(false);
        cur_index++;
        if (cur_index <= targets.Length - 1)
            targets[cur_index].SetActive(true);
        else
            finish_event.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject o in targets) o.SetActive(false);
        targets[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

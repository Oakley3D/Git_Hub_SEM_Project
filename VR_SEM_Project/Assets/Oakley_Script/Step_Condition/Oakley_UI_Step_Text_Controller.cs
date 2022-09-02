using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Oakley_UI_Step_Text_Controller : MonoBehaviour
{
    public float change_time = 2;
    public int index = 0;
    public float finish_time = 6;
    bool is_finish = false;
    public UnityEvent finish_event;
    float timer = 0;
    public string[] content;
    public Text text_ui;
    float step_time = 0;
    private void OnEnable()
    {
        timer = 0;
        index = 0;
        step_time = 0;
        if (content != null)
        {
            text_ui.text = content[0];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        step_time += Time.deltaTime;
        if (content != null)
        {
            if (timer > change_time)
            {
                timer = 0;
                index++;
                if (index >= content.Length - 1) index = content.Length - 1;
                text_ui.text = content[index];
            }
        }

        if (is_finish == false)
        {
            if (step_time > finish_time)
            {
                is_finish = true;
                finish_event.Invoke();
            }
        }
    }
}

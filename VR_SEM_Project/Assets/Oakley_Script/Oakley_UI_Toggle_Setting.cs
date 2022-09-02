using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Oakley_UI_Toggle_Setting : MonoBehaviour
{
    public Toggle[] selected_toggles;
    [Header("選項都被選取時觸發")]
    public UnityEvent correct_event;
    bool is_correct = false;
    public bool auto_detect = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Check()
    {
        if (is_correct == false)
        {
            int count = 0;
            foreach (Toggle t in selected_toggles)
            {
                if (t.isOn) count++;
            }

            if (count == selected_toggles.Length)
            {
                is_correct = true;
                correct_event.Invoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (auto_detect == false) return;
        if (is_correct == false)
        {
            int count = 0;
            foreach (Toggle t in selected_toggles)
            {
                if (t.isOn) count++;
            }

            if (count == selected_toggles.Length)
            {
                is_correct = true;
                correct_event.Invoke();
            }
        }
    }
}

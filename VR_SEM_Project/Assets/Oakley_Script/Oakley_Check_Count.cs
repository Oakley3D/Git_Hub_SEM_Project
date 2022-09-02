using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Oakley_Check_Count : MonoBehaviour
{
    [Tooltip("檢查觸發的次數是否大於最大值，滿足觸發事件")]
    public int max_count = 3;
    public int init_count = 0;
    public Text info_text;
    public UnityEvent finish_event;
    Oakley_VR_Step_Controller step;
    public void Add_Count()
    {
        
        if (step)
        {
            if (step.gameObject.activeSelf == false) return;
        }
        if (transform.parent.gameObject.activeSelf == false) return;
            init_count++;
            if (init_count >= max_count)
            {
                finish_event.Invoke();
            }
            if (info_text) info_text.text = init_count.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (info_text) info_text.text = init_count.ToString();
    }

    // Update is called once per frame
    void OnEnable()
    {
        step = GetComponentInParent<Oakley_VR_Step_Controller>();
    }
}

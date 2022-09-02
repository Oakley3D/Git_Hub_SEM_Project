using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_UI_Bool_Setting : MonoBehaviour
{
    public bool[] check_count;
    [Header("自動檢查")]
    public bool auto_check = false;
    public UnityEvent finish_event;
    bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Check_Answer()
    {
        int count = 0;
        foreach (bool b in check_count)
        {
            count++;
        }
        if (count >= check_count.Length)
        {
            finish_event.Invoke();
        }
    }

    public void Set_Bool_Index(int i)
    {
        check_count[i] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (auto_check)
        {
            int count = 0;
            foreach (bool b in check_count)
            {
                count++;
            }
            if (count >= check_count.Length)
            {
                if (finish == false)
                {
                    finish_event.Invoke();
                    finish = true;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Events;

public class Oakley_Purge_Setting : MonoBehaviour
{
    public string[] purge_type = new string[4] { "A", "B", "C", "D" };
    public Dropdown dropdown_ui;
    public List<string> finish_type = new List<string>();
    string cur_type_value = "A";
    bool is_purge = false;
    public UnityEvent finish_event;
    bool start = false;
    public GameObject purge_on_btn, purge_off_btn;
    public GameObject warring_page;

    public Line_Type[] lines;
    public UnityEvent a_event, b_event, c_event, d_event;

    [System.SerializableAttribute]
    public struct Line_Type
    {
        public GameObject line;
        public string name;

    }

    public void Initial()
    {
        foreach (Line_Type line in lines)
        {
            
                line.line.SetActive(true);
            
        }
    }

    string temp_line_name = "";

    bool is_purging = false;

    IEnumerator wait_purge;

    public void Update_Value()
    {
        Debug.Log(purge_type[dropdown_ui.value]);
        cur_type_value = purge_type[ dropdown_ui.value];
        if (is_purge)
        {
            if (!finish_type.Contains(cur_type_value))
            {
                finish_type.Add(cur_type_value);
                if (cur_type_value == "A") a_event.Invoke();
                if (cur_type_value == "B") b_event.Invoke();
                if (cur_type_value == "C") c_event.Invoke();
                if (cur_type_value == "D") d_event.Invoke();

            }
        }
    }
    //
    public void Purge_Off()
    {
       // if (is_purging) return;
        is_purge = false;
        purge_on_btn.SetActive(true);
        /*
        if (finish_type.Count >= 4)
        {
            finish_event.Invoke();
            start = false;
        }
        */
    }
    //
    public void Purge_On()
    {

        // if (is_purge) return;
        is_purge = true;


        warring_page.SetActive(true);

        if (cur_type_value != "")
        {

            temp_line_name = cur_type_value;

            if (!finish_type.Contains(cur_type_value))
            {
                finish_type.Add(cur_type_value);
                if (cur_type_value == "A") a_event.Invoke();
                if (cur_type_value == "B") b_event.Invoke();
                if (cur_type_value == "C") c_event.Invoke();
                if (cur_type_value == "D") d_event.Invoke();

            }

           // is_purge = true;

            purge_off_btn.SetActive(true);
           // purge_on_btn.SetActive(false);

            Debug.Log("purge down");

            //如果都按完了 就自動完成
            if (finish_type.Count >= 4)
            {
                finish_event.Invoke();
                start = false;
            }
            //Wait_Purge();
        }
    }
    public void OnEnable()
    {
        start = true;
        wait_purge = IWait_Purge();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Wait_Purge()
    {
        //StartCoroutine(IWait_Purge());
        StopCoroutine(wait_purge);
        wait_purge = IWait_Purge();
        StartCoroutine(IWaitClearLine());
        //Debug.Log("wait ------------- purge");
       // Debug.LogError("");
    }
    IEnumerator IWait_Purge()
    {
        StartCoroutine(IWait_Purge());
        Debug.LogError("wait ------------- purge");
        is_purging = true;
     
        yield return new WaitForSeconds(1);

        Debug.LogError("finish ------------- purge");
      
        is_purging = false;
        purge_on_btn.SetActive(true);
    }

    IEnumerator IWaitClearLine()
    {
       
        yield return new WaitForSeconds(3);

        foreach (Line_Type line in lines)
        {
            if (line.name == temp_line_name)
            {
                line.line.SetActive(false);
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        
    }

    public void Cancel()
    {
      //  finish_type.Clear();
        is_purge = false;
        is_purging = false;
    }

    public void Reset()
    {
        finish_type.Clear();
        is_purge = false;
        is_purging = false;
    }
}

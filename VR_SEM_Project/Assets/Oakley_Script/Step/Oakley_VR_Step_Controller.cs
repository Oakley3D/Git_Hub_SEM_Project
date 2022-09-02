using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum step_tutorial_open
{

    video_finished = 0,
    direct_open,
    no_use

}
public class Oakley_VR_Step_Controller : MonoBehaviour
{
    public VR_Oakley_Step_Condition_Base[] conditions;
    public GameObject[] will_enable;
    public GameObject[] will_disable;
    [Header("啟動時觸發")]
    public UnityEvent start_event;

    public bool is_finish = false;
    [Header("依序完成每個小步驟")]
    public bool must_follow_condition = false;
    int cur_condition_index = 0;
    int prev_condition_index = -1;
    public float wait_to_next_time = 1;
    public video_tutorial video_tutorial_clip;
    public step_tutorial_open open_step_tutorial = step_tutorial_open.video_finished;
    public step_tutorial step_tutorial_ui;
    [Header("結束時直接下一步")]
    public bool auto_finish_and_next = true;
    public Oakley_Step_Success_Tip success_step_tip;
    bool skip = false;
    [Header("等待時間顯示成功畫面")]
    public float wait_success_time = 0;
    public bool is_start = false;
    // Start is called before the first frame update
    void Awake()
    {
        conditions = GetComponentsInChildren<VR_Oakley_Step_Condition_Base>();
        foreach (VR_Oakley_Step_Condition_Base b in conditions) b.Set_Controller(this);
        success_step_tip = GetComponent<Oakley_Step_Success_Tip>();

    }

    private void OnEnable()
    {
        if (must_follow_condition)
        {
            if (conditions.Length > 0)
            {
                for (int i = 0; i <= conditions.Length - 1; i++)
                {
                    if (i == 0) conditions[i].gameObject.SetActive(true);
                    else conditions[i].gameObject.SetActive(false);
                }
            }
        }

        StartCoroutine(Wait_Excute_Event());

        //開啟影片
        if (GameObject.FindObjectOfType<Oakley_Video_Step_Manager>())
            GameObject.FindObjectOfType<Oakley_Video_Step_Manager>().Open_Video(this, video_tutorial_clip);
        //開啟教學步驟
        if (open_step_tutorial == step_tutorial_open.direct_open)
        {
            GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Open_Step_Tutorial(step_tutorial_ui);
        }

        skip = false;
        prev_condition_index = -1;
    }

    IEnumerator Wait_Excute_Event()
    {
        yield return new WaitForSeconds(0.1f);
        start_event.Invoke();
    }

    
    public void Start_Step()
    {
        foreach (GameObject g in will_enable) if (g) g.SetActive(true);
        foreach (GameObject g in will_disable) if (g) g.SetActive(false);

    }

    
    // Update is called once per frame
    public void Update_Step()
    {
        if (is_start == false) return;
        if (must_follow_condition == false)
        {
            int finished_count = 0;
            foreach (VR_Oakley_Step_Condition_Base b in conditions)
            {
                if (b.is_finish) finished_count++;

            }
            if (finished_count == conditions.Length || skip )
            {
                if (auto_finish_and_next)
                {
                    is_finish = true;
                    if (GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>())
                        GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Closed_Step_Tutorial(step_tutorial_ui, wait_success_time);
                }
                else
                {
                    if (GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>())
                        GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Closed_Step_Tutorial(step_tutorial_ui, wait_success_time);
                    if (success_step_tip) success_step_tip.Open_Tip(wait_success_time);
                }
            }
        }
        else //逐步檢查每一個
        {
            if (cur_condition_index < conditions.Length)
            {
                if (cur_condition_index != prev_condition_index)
                {
                    if (prev_condition_index != -1)
                        conditions[prev_condition_index].End_Condition();

                    conditions[cur_condition_index].Start_Condition();

                    prev_condition_index = cur_condition_index;

                }
                if (conditions[cur_condition_index].is_finish )
                {
                   
                    cur_condition_index++;
                    if (cur_condition_index < conditions.Length)
                        conditions[cur_condition_index].gameObject.SetActive(true);

                }

                
            }

            if (cur_condition_index >= conditions.Length - 1)
            {
                int finished_count = 0;
                foreach (VR_Oakley_Step_Condition_Base b in conditions)
                {
                    if (b.is_finish) finished_count++;

                }
                if (finished_count == conditions.Length || skip)
                {
                    if (auto_finish_and_next)
                    {
                        is_finish = true;
                        GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Closed_Step_Tutorial(step_tutorial_ui, wait_success_time);
                    }
                    else 
                    {
                        GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Closed_Step_Tutorial(step_tutorial_ui, wait_success_time);
                        if (success_step_tip) success_step_tip.Open_Tip(wait_success_time);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            skip = true;
            End_Step();
            Debug.Log("skip");
        }
    }

    public void End_Step()
    {
        is_finish = true;
    }

    public void Video_Tutorial_End()
    {
        if (open_step_tutorial == step_tutorial_open.video_finished)
        {
            GameObject.FindObjectOfType<Oakley_UI_Step_Super_Manager>().Open_Step_Tutorial(step_tutorial_ui);
        }
        //Debug.LogError("tutorial is ending");
        is_start = true;
    }

    public void Finish()
    {
        is_finish = true;
    }
}

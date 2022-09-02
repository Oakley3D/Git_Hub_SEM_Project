using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Show_Next_Tip_Btn
{
    no = -1,
    yes ,
    auto_next
}


[System.Serializable]
public class VR_Oakley_Step_Condition_Base:MonoBehaviour
{
    public GameObject[] show_objects;
    public GameObject[] hide_objects;
    [Header("步驟")]
    public Oakley_VR_Step_Controller controller;
    [Header("觸發的次數(滿足才算完成")]
    public int trigger_count = 1;
    [HideInInspector]
    public int cur_trigger_count = 0;
    [Header("條件名稱")]
    public string condition_name = "";
    [Header("步驟完成")]
    public bool is_finish = false;
    [Space(10)]
    [Header("步驟開始呼叫")]
    public UnityEvent start_event;
    [Header("步驟結束呼叫")]
    public UnityEvent end_event;
    public bool use_finish_audio = true, use_finish_tip_ui = true;
   // public GameObject Tip;
    public void Set_Controller(Oakley_VR_Step_Controller _controller)
    {
        controller = _controller;

    }
    /// <summary>
    /// 步驟開始時呼叫
    /// </summary>
    public void Start_Condition()
    {
        foreach (GameObject o in show_objects) o.SetActive(true);
        foreach (GameObject o in hide_objects) o.SetActive(false);
        start_event.Invoke();
    }
    /// <summary>
    /// 步驟結束時呼叫
    /// </summary>
    public void End_Condition()
    {
        
        end_event.Invoke();
    }

}
public class VR_Oakley_Step_Condition_Controller : VR_Oakley_Step_Condition_Base
{
    // [ContextMenu("Finished() 完成  , Trigger() 觸發次數 ")]
    [Space(20)]
    
    [TextArea]
    public string tooltip = "Finish () 完成、 Trigger() 觸發";
    [Header("使用介面來啟動下一個步驟，否則直接下一步")]
    public Show_Next_Tip_Btn show_next_tip_btn = Show_Next_Tip_Btn.no;
    [Header("完成步驟調用事件")]
    public UnityEvent finish_event;

    bool is_play_finish_sound = false;

    public void Trigger()
    {
        if (gameObject.activeSelf == false) return;
        cur_trigger_count++;
        if (cur_trigger_count >= trigger_count)
        {
            Finished();
        }
    }

    //由介面按下下一步才真正完成該動作
    public void Finish_By_UI()
    {
        if (show_next_tip_btn == Show_Next_Tip_Btn.yes)
        {
            is_finish = true;
            gameObject.SetActive(false);
        }
        
    }

    bool is_send_log = false;

    public void Finished()
    {


        if (this.controller) if (this.controller.is_start == false) return;

        if (gameObject.activeSelf == false || transform.parent.gameObject.activeSelf == false) return;
        

        
        if (use_finish_tip_ui)
            Tip_Camera_Controller.instance.Show_Tip();

        finish_event.Invoke();

        if (is_send_log == false)
        {
            is_send_log = true;
            //如果要加入LOG
         //   if (GetComponent<Oakley_Interaction_Setting>())
          //      if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Add_Custom_Event(gameObject, "操作步驟_完成");

        }

        Debug.Log(gameObject.name + "  step is finished ");

        if (show_next_tip_btn == Show_Next_Tip_Btn.yes)
        {
            Oakley_Step_And_UI_Manager.instance.Show_Next_Step_Controller();

            if (Oakley_Audio_Manager.instance)
            {
                if (is_play_finish_sound == false)
                {
                    if (use_finish_audio)
                        Oakley_Audio_Manager.instance.Page_Finish_Sound();
                    is_play_finish_sound = true;
                }
            }
        }
        else if (show_next_tip_btn == Show_Next_Tip_Btn.auto_next)
        {
            Oakley_Step_And_UI_Manager.instance.Auto_Next();
            is_finish = true;
            if (Oakley_Audio_Manager.instance)
            {
                if (is_play_finish_sound == false)
                {
                    if (use_finish_audio)
                        Oakley_Audio_Manager.instance.Page_Finish_Sound();
                    is_play_finish_sound = true;
                }
            }
        }
        else
        {
            is_finish = true;

            if (Oakley_Audio_Manager.instance)
            {
                if (is_play_finish_sound == false)
                {
                    if (use_finish_audio)
                        Oakley_Audio_Manager.instance.Page_Finish_Sound();


                    is_play_finish_sound = true;
                }
            }

            gameObject.SetActive(false);
        }

        
    }

    void OnEnable()
    {
       // Debug.Log(controller.name);
       if (Oakley_Step_And_UI_Manager.instance)
        Oakley_Step_And_UI_Manager.instance.Set_Sub_Controller(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) Finished();
        
    }

    
}

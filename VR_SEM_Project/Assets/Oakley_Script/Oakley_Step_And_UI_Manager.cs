using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Step_And_UI_Manager : MonoBehaviour
{
    public static Oakley_Step_And_UI_Manager instance;
    public VR_Oakley_Step_Condition_Controller sub_step_controller;
    public Oakley_UI_Step_Controller sub_ui_step;
    public void OnEnable()
    {
        if (instance == null) instance = this;
    }
    public void Awake()
    {
        if (instance == null) instance = this;
    }

    public void Set_Sub_Controller(VR_Oakley_Step_Condition_Controller m_sub_step_controller)
    {
        sub_step_controller = m_sub_step_controller;
    }

    public void Set_Sub_UI_Controller(Oakley_UI_Step_Controller m_sub_ui_step)
    {
        sub_ui_step = m_sub_ui_step;
    }
    /// <summary>
    /// 要按下下一步才觸發下一個步驟
    /// </summary>
    public void Show_Next_Step_Controller()
    {
        if (sub_step_controller)
            if (sub_step_controller.show_next_tip_btn == Show_Next_Tip_Btn.yes) sub_ui_step.next_btn.gameObject.SetActive(true); ;
    }

    //自動下一步
    public void Auto_Next()
    {
        if (sub_step_controller)
            if (sub_step_controller.show_next_tip_btn == Show_Next_Tip_Btn.auto_next) sub_ui_step.Next();
    }
    //介面按下下一步時呼叫
    public void Next_Step_Controller()
    {
        if (sub_step_controller)
            if (sub_step_controller.show_next_tip_btn == Show_Next_Tip_Btn.yes) sub_step_controller.Finish_By_UI();
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

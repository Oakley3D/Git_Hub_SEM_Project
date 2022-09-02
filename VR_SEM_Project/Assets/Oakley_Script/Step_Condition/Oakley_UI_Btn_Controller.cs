using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public enum Oakley_Click_Type
{
    finish = 0,
    trigger 
}
[RequireComponent(typeof ( EventTrigger)) ]
public class Oakley_UI_Btn_Controller : MonoBehaviour, IPointerClickHandler
{
    [Header("介面按鈕按下去要執行的行為")]
    public VR_Oakley_Step_Condition_Controller step_controller;

    public Oakley_Click_Type click_type = Oakley_Click_Type.finish;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (step_controller == null) return;
        Debug.Log("------------ui btn clicked ----------------");
        if (click_type == Oakley_Click_Type.finish) step_controller.Finished();
        else step_controller.Trigger();
    }
    
    
}

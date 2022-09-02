using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum step_tutorial
{
    none = -1 ,
 
    step1,
    step2,
    step3,
    step4, step5,step6,step7,step8,step9,step10,step11,step12,step13,step14,step15,step16,step17,step18,step19,step20,step21,step22,step23,step24,step25
}
public class Oakley_UI_Step_Super_Manager : MonoBehaviour
{
    public Oakley_UI_Step_Manager[] ui_managers;

    // Start is called before the first frame update
    void Start()
    {
        ui_managers = gameObject.GetComponentsInChildren<Oakley_UI_Step_Manager>();
        foreach (Oakley_UI_Step_Manager mg in ui_managers)
        {
            mg.gameObject.SetActive(false);
        }
    }

    public void Open_Step_Tutorial(step_tutorial step_index )
    {
        foreach (Oakley_UI_Step_Manager mg in ui_managers)
        {
            mg.gameObject.SetActive(false);
        }
        if (step_index == step_tutorial.none) return;

        foreach (Oakley_UI_Step_Manager mg in ui_managers)
        {
            if (step_index == mg.cur_step_tutorial)
                mg.gameObject.SetActive(true);
        }
    }

    //當該步驟完成時候，關閉教學介面
    public void Closed_Step_Tutorial(step_tutorial step_index , float wait)
    {
        /*
        foreach (Oakley_UI_Step_Manager mg in ui_managers)
        {
            if (step_index == mg.cur_step_tutorial)
                mg.gameObject.SetActive(false);
        }
        */
        StartCoroutine(Wait_Close(step_index , wait ));
    }

    IEnumerator Wait_Close(step_tutorial step_index , float wait )
    {
        yield return new WaitForSeconds(wait);
        foreach (Oakley_UI_Step_Manager mg in ui_managers)
        {
            if (step_index == mg.cur_step_tutorial)
                mg.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oakley_UI_Step_Manager : MonoBehaviour
{
    [Header("介面提示步驟")]
    public step_tutorial cur_step_tutorial = step_tutorial.none;
    public Oakley_UI_Step_Controller[] steps;
    public int index = 0;
    public Transform explain_tip;

    //更新解說文字
    public void Update_Explain_Text(string text)
    {
        if (explain_tip)
        {
            if (text != "") explain_tip.gameObject.GetComponent<Oakley_Tip_Explain_Controller>().Use_Explain(true);
            else explain_tip.gameObject.GetComponent<Oakley_Tip_Explain_Controller>().Use_Explain(false);
            explain_tip.gameObject.GetComponent<Oakley_Tip_Explain_Controller>().explain_text.text = text;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        steps = GetComponentsInChildren<Oakley_UI_Step_Controller>();

        int i = 0;
        foreach (Oakley_UI_Step_Controller ui in steps)
        {
            ui.mg = this;

            if (i == 0)
            {
                if (ui.prev_btn)
                    ui.prev_btn.gameObject.SetActive(false);
                Debug.Log(name + " closed left button");
            }
            if (i == steps.Length - 1)
            {
                if (ui.next_btn)
                    ui.next_btn.gameObject.SetActive(false);
            }
            ui.gameObject.SetActive(false);
            i++;

        }

        explain_tip = transform.Find("操作解說");
    }

    public void OnEnable()
    {
        foreach (Oakley_UI_Step_Controller ui in steps)
        {
            
            ui.gameObject.SetActive(false);
            

        }

        if (index < steps.Length)
        {
            steps[index].gameObject.SetActive(true);
            steps[index].Play();
        }
    }

    public void Next()
    {
        Debug.Log("next ");
        steps[index].gameObject.SetActive(false);
        index++;
        if (index > steps.Length - 1)
        {
            index = steps.Length - 1;

        }
        steps[index].gameObject.SetActive(true);
        steps[index].Play();
    }

    public void Prev()
    {
        Debug.Log("prev  ");
        steps[index].gameObject.SetActive(false);
        index--;
        if (index < 0 )
        {
            index = 0;

        }
        steps[index].gameObject.SetActive(true);
        steps[index].Play();
    }

    public void Closed()
    {
        Debug.Log("closed ");
        gameObject.SetActive(false);
    }

    public void Show_Up_Next_Btn()
    {
        steps[index].next_btn.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Oakley_UI_Step_Controller : MonoBehaviour
{
    public Button next_btn, prev_btn, closed_btn;
    public Oakley_UI_Step_Manager mg;
    public UnityEvent execute_event;
    public UnityEvent disable_event;
    public float delay_excute_event_time = 1;
    [Header("解說文字")]
    [TextArea(3, 10)]
    public string explain_text;

    //public AudioClip open_sound;
    // Start is called before the first frame update
    void Awake()
    {

       
       // next_btn.onClick.AddListener(Next);
       // prev_btn.onClick.AddListener(Prev);
       // closed_btn.onClick.AddListener(Closed);


    }

    public void Play()
    {
        StartCoroutine(Wait());
        //execute_event.Invoke();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay_excute_event_time);
        execute_event.Invoke();
    }

    private void OnEnable()
    {
        if (Oakley_Step_And_UI_Manager.instance)
            Oakley_Step_And_UI_Manager.instance.Set_Sub_UI_Controller(this);
        if (Oakley_Audio_Manager.instance)
            Oakley_Audio_Manager.instance.Play_Page_Sound();

        if (mg)
        {
            mg.Update_Explain_Text(explain_text);
        }

    }
    private void OnDisable()
    {
        // next_btn.onClick.RemoveListener(Next);
        // prev_btn.onClick.RemoveListener(Prev);
        //  closed_btn.onClick.RemoveListener(Closed);
        disable_event.Invoke();
    }
    public void Next()
    {
        mg.Next();
        //回傳要執行下一步
        if (Oakley_Step_And_UI_Manager.instance)
        {
            Oakley_Step_And_UI_Manager.instance.Next_Step_Controller();
        }
    }

    public void Prev()
    {
        mg.Prev();
    }

    public void Closed()
    {
        mg.Closed();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Next();
    }
}

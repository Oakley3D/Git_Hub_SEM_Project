using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oakley_Level_Change_Controller : MonoBehaviour
{
    public Oakley_VR_Step_Manager step_mg;
    public Dropdown level_menu;
    public Toggle enable_video_btn;
    public string cur_scene_name = "";
   
    public void OnEnable()
    {
        StartCoroutine(IStart());
    }

    // Start is called before the first frame update
    IEnumerator IStart()
    {
        yield return new WaitForSeconds(0.5f);
        step_mg = GameObject.FindObjectOfType<Oakley_VR_Step_Manager>();
        level_menu.ClearOptions();
        foreach (Oakley_VR_Step_Controller step in step_mg.steps)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(step.gameObject.name);
            Debug.Log(option.text);
            level_menu.options.Add(option);
           //level_menu.
        }
        
        
    }

    public void Change_Level()
    {
        step_mg.StopAllCoroutines();
        step_mg.cur_step_index = level_menu.value;
        step_mg.Play();
    }

    public void Go_Main()
    {
        step_mg.StopAllCoroutines();
        step_mg.RePlay();
    }

    public void Relpay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(cur_scene_name);
    }
    // Update is called once per frame
    void Update()
    {
        if (enable_video_btn != null)
            step_mg.is_debug_for_video = enable_video_btn.isOn;
    }
}

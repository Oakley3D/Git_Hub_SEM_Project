using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Oakley_VR_Step_Manager : MonoBehaviour
{
    public Oakley_VR_Step_Controller[] steps;
    [Header("目前步驟")]
    public int cur_step_index = 0;
    Rect window = new Rect(0, 0, 400, 1300);
    bool debug = false;
    public bool auto_start = false;
    public float wait_time_to_start = 3;
    // Start is called before the first frame update
    public string next_scene_name = "";
    public bool is_ready = false;
   // public Oakley_Student_History_Controller student_controller;
    public static Oakley_VR_Step_Manager instance;
    [Header("顯示影片控制按鈕")]
    public bool is_debug_for_video = false;
    public void Ready_Play()
    {
        is_ready = true;
    }

    void Start()
    {
        instance = this;
/*
        if (student_controller == null) student_controller = gameObject.GetComponent<Oakley_Student_History_Controller>();
        if (student_controller == null)
        {
            GameObject student_history_obj = new GameObject();
            student_controller = student_history_obj.AddComponent<Oakley_Student_History_Controller>();
        }
*/
        steps = GetComponentsInChildren<Oakley_VR_Step_Controller>();

        foreach (Oakley_VR_Step_Controller step in steps) step.gameObject.SetActive(false);

        if (auto_start)
        {
            Ready_Play();
            Play();
        }


    }

    public string Get_Cur_Step_Name()
    {
        return steps[cur_step_index].gameObject.name;
    }

    IEnumerator Run_Step()
    {
        if (Oakley_UI_Manager.instance) Oakley_UI_Manager.instance.initial_ui.SetActive(false);
        //if (student_controller)  Oakley_Student_History_Controller.instance.Save_Start_Data_To_Sheet(); // 儲存資料到sheet
        yield return null;
        while (is_ready == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(wait_time_to_start);
        while (cur_step_index < steps.Length)
        {
            yield return null;
            steps[cur_step_index].gameObject.SetActive(true);
            steps[cur_step_index].Start_Step();

            //紀錄每個關卡時間
           // Step_Study_History step_data = new Step_Study_History();
           // step_data.step_name = steps[cur_step_index].gameObject.name;

            while (steps[cur_step_index].is_finish == false)
            {
                yield return null;
                steps[cur_step_index].Update_Step();
                //累計總時間
                //if (student_controller)  student_controller.totoal_timer += Time.deltaTime;//

              //  step_data.timer += Time.deltaTime;// 每個步驟的時間
            }

            //if (student_controller) student_controller.steps_data.Add(step_data); //將每個步驟記錄下來
            //if (student_controller) student_controller.Save_Help_Event("步驟完成"); //將步驟存在HELP文件

            yield return null;
            Debug.Log(cur_step_index  + " --- > End ");
            steps[cur_step_index].End_Step();
            yield return new WaitForSeconds(steps[cur_step_index].wait_to_next_time);
            steps[cur_step_index].gameObject.SetActive(false);
            yield return null;
            cur_step_index++;
            Debug.Log(cur_step_index + " --- > Next ");

        }
       //if (student_controller)  Oakley_Student_History_Controller.instance.Save_End_Data_To_Sheet(student_controller.totoal_timer); // 儲存資料到sheet
       // if (student_controller) student_controller.Save_Histroy(); //儲存學習時間資料

        yield return new WaitForSeconds(2);
        if (Oakley_UI_Manager.instance) Oakley_UI_Manager.instance.final_ui.SetActive(true);
    }


    public void RePlay()
    {

       // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Load_Scene();
    }


    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Run_Step());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) debug = !debug;
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.F1))SceneManager.LoadScene(0);
    }

    private void OnGUI()
    {
        if (!debug) return;
        GUI.skin.button.fontSize = 20;
        GUI.Window(0, window, Window, "步驟設定");    
    }

    void Window(int id)
    {
        for (int i = 0; i <= steps.Length - 1; i++)
        {
            if (GUI.Button(new Rect(50, 40+ i * 35, 300, 30), steps[i].gameObject.name))
            {
                cur_step_index = i;
            }
        }
        if (GUI.Button(new Rect(50, 40+ steps.Length * 35, 300, 60), "開始"))
        {
            debug = false;
            Play();
        }

        if (GUI.Button(new Rect(50, 40 + steps.Length * 35 + 60, 300, 60), "重新開始"))
        {
            debug = false;
            RePlay();
        }
    }

    public void Go_To_Next_Scene()
    {
      //  if (next_scene_name != "") SceneManager.LoadScene(next_scene_name);
        Load_Scene();
    }

    public void Load_Scene( )
    {
        GameObject mask = (GameObject)  Resources.Load("mask");
        GameObject runtime_mask = GameObject.Instantiate(mask, Vector3.zero, Quaternion.identity) as GameObject;
        runtime_mask.GetComponent<VR_Menu_Controller>().Change_Scene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Eye_Tracking_Data
{
    public int index;
    public float time;
    public string aoi;
    public Vector3 pos;

}

[System.Serializable]
public class Eye_Fixation_Data
{
    public int index;
    public float time;
    public string aoi;
    public float delta_time;
    public Vector3 pos ;
}
public class Oakley_Eye_Tracking_Controller : MonoBehaviour
{
    [Header("Fixation 偵測範圍")]
    public float range = 0.05f;
    [Header("Fixation 凝視時間")]
    public float fix_time = 0.15f;

    public float fps = 60;

    List<Eye_Tracking_Data> tracking_datas = new List<Eye_Tracking_Data>();
    List<Eye_Fixation_Data> fixation_datas = new List<Eye_Fixation_Data>();
    Eye_Tracking_Data last_tracking_data , cur_tracking_data;

    float timer = 0, tracking_time = 0, fixation_time = 0;
    int index = 0;

    Camera camera;

    GameObject ref_camera;
    // Start is called before the first frame update
    void Start()
    {
        ref_camera = new GameObject("Ref Camera Object");

    }
    /*
    private void OnDrawGizmos()
    {
        if (last_tracking_data != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ref_camera.transform.position, last_tracking_data.pos);
        }
        if (cur_tracking_data != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(ref_camera.transform.position, cur_tracking_data.pos);
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        float update_time = 1.0f / fps;

        if (camera == null) camera = Camera.main;

        timer += Time.deltaTime;
        tracking_time += Time.deltaTime;

        if (camera)
            ref_camera.transform.rotation = camera.transform.rotation;
        
        if (timer > update_time)
        {
            timer = 0;

            Eye_Tracking_Data tracking_data = new Eye_Tracking_Data();
            tracking_data.time = tracking_time;
            tracking_data.index = index;
            Vector3 trace_pos = Get_Camera_Trace_Pos();
            tracking_data.pos = trace_pos;

            cur_tracking_data = tracking_data;

            tracking_datas.Add(tracking_data);

            index++;

            if (last_tracking_data == null) last_tracking_data = tracking_data;

            if (Vector3.Distance(last_tracking_data.pos, tracking_data.pos) > range)
            {
                last_tracking_data = tracking_data;
                fixation_time = 0;
            }
            else
            {
                fixation_time += update_time;
                if (fixation_time >= fix_time)
                {
                    fixation_time = 0;
                    Add_Fixation_Data(last_tracking_data, tracking_data);

                }
            }

        }


    }

    void Add_Fixation_Data(Eye_Tracking_Data begin, Eye_Tracking_Data end)
    {
        List<Eye_Tracking_Data> temp_eye_trackings = new List<Eye_Tracking_Data>();
        for (int i = begin.index; i <= end.index; i++)
        {
            temp_eye_trackings.Add(tracking_datas[i]);
        }
        int index = 0;
        Vector3 center = Vector3.zero; ;
        foreach (Eye_Tracking_Data tracking_data in temp_eye_trackings)
        {
            center += tracking_data.pos;
            index++;
        }

        center = center / index;

        Eye_Fixation_Data fixation_data = new Eye_Fixation_Data();
        fixation_data.index = fixation_datas.Count;
        fixation_data.pos = center;
        fixation_data.time = begin.time;
        fixation_data.delta_time = end.time - begin.time;

        fixation_datas.Add(fixation_data);

       // Debug.Log(fixation_data.time + " / " + fixation_data.delta_time);

        last_tracking_data = end;

        
        
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 10))
        {
          //  if (hit.collider.name == "Video_Collider") Oakley_Student_History_Controller.instance.Save_Tip_Event("觀看_教學影片");
          //  if (hit.collider.name == "Tip_Collider") Oakley_Student_History_Controller.instance.Save_Tip_Event("觀看_操作提示");
         //   if (hit.collider.name == "Explain_Collider") Oakley_Student_History_Controller.instance.Save_Tip_Event("觀看_操作解說");

        }

    }

    Vector3 Get_Camera_Trace_Pos()
    {
        Vector3 center = ref_camera.transform.position;
        Vector3 pos = center + ref_camera.transform.forward * 1;
        return pos;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Events;

public class Oakley_Video_Controller : MonoBehaviour
{
    public VideoPlayer video_player;
    public float start_time = 0;
    public float end_time = 100;
    public Slider video_slider;
    public Slider control_slider;
    public Oakley_Video_Step_Manager manager;
    public GameObject next_btn;
    bool is_finished = false;
    public UnityEvent finish_event;
    public video_tutorial cur_video = video_tutorial.none;
    public float video_speed = 1.0f;
    public float video_volumn = 1;
    public bool auto_play_video = false;
    double current_time = 0;

    public Transform play_btn, pause_btn, stop_btn;

    public void Set_Listener(Oakley_VR_Step_Controller step)
    {
        finish_event.AddListener(step.Video_Tutorial_End);
    }

    private void Start()
    {
       
       
        

    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (play_btn == null) play_btn = transform.Find("btn_play");
        if (pause_btn == null) pause_btn = transform.Find("btn_pause");
        if (stop_btn == null) stop_btn = transform.Find("btn_stop");

        video_player.time = start_time;
        current_time = start_time;
        name = name + "_"+ cur_video.ToString();
        video_player.playbackSpeed = video_speed;
        video_player.SetDirectAudioVolume(0, video_volumn);

        

        if (auto_play_video) Play();

        //關閉

        if (Oakley_VR_Step_Manager.instance)
        {
            if (Oakley_VR_Step_Manager.instance.is_debug_for_video == false)
            {
                control_slider.gameObject.SetActive(false);
                play_btn.gameObject.SetActive(false);
                pause_btn.gameObject.SetActive(false);
                stop_btn.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (video_player.time > end_time)
        {
            video_player.Stop();
           // next_btn.SetActive(true);
            if (is_finished == false)
            {
                is_finished = true;
                finish_event.Invoke();

                control_slider.gameObject.SetActive(true);
                play_btn.gameObject.SetActive(true);
                pause_btn.gameObject.SetActive(true);
                stop_btn.gameObject.SetActive(true);
            }
        }

        video_slider.value = ((float)video_player.time - start_time) / (end_time - start_time);
    }

    public void Pause()
    {
        if (video_player.isPlaying)
        {
            current_time = video_player.time;
            video_player.Pause();
          // if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("暫停影片");
        }
        /*
        else
        {
            video_player.Play();
        }
        */
    }

    public void Replay()
    {
        frame = (long)(start_time * video_player.frameRate);
        video_player.frame = frame;
        video_player.Play();
    }

    public void Stop()
    {
        video_player.time = start_time;

        video_player.Stop();

        //if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("停止影片");

    }

    public void Play()
    {
        
        if (video_player.isPaused )
        {
            frame = (long)(video_player.time * video_player.frameRate);
            video_player.frame = frame;
            video_player.Play();
        }
        else if (video_player.isPlaying == false)
        {
            frame = (long)(start_time * video_player.frameRate);
            video_player.frame = frame;
            video_player.Play();
        }
        Debug.Log("Play time " + current_time);
        //if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("播放影片");

        //video_player.Stop();
        // video_player.time = current_time;

        // video_player.time = current_time;
    }
    long frame = 0;
    public void Change_Slider()
    {
        float value =   control_slider.value;
        float time = start_time +  value  * (end_time - start_time);

        ulong total_frame = video_player.frameCount;
        

        video_player.time = time;
        current_time = video_player.time;
        //Debug.Log("change time " + current_time);
        video_player.Pause();
        frame = (long) (time * video_player.frameRate);
        current_time = video_player.time;


    }

    public void Next()
    {
        Debug.Log("next");
        manager.Next();
    }
}

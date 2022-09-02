using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Audio_Btn_Controller : MonoBehaviour
{
    public bool auto_play = true;
    public float delay_time = 3;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();

        if (auto_play)
        {
            Invoke("Play", delay_time);
        }
        
    }

    void Play()
    {
        audio.Play();
    }


    // Update is called once per frame
    public void Click()
    {
       // if (Oakley_Student_History_Controller.instance)
       // {
       //     Oakley_Student_History_Controller.instance.Save_Help_Event("播放解說語音");
       // }
    }
}

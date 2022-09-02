using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum video_tutorial
{
    none = -1,
    video1,
    video2,
    video3,
    video4,
    video5,
    video6,
    video7,
    video8,
    video9,
    video10,
    video11,
    video12,
    video13,
    video14,
    video15,
    video16,
    video17,
    video18,
    video19,
    video20,
    video21,video22,video23,video24,video25
}
public class Oakley_Video_Step_Manager : MonoBehaviour
{
    public Oakley_Video_Controller[] video_pages;

    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        video_pages = gameObject.GetComponentsInChildren<Oakley_Video_Controller>();
        foreach (Oakley_Video_Controller video in video_pages)
        {
            video.manager = this;
            video.gameObject.SetActive(false);
        }
        /*
        if (index < video_pages.Length  && video_pages.Length > 0)
        {
            video_pages[index].gameObject.SetActive(true);
        }
        */
    }

    public void Next()
    {
        video_pages[index].gameObject.SetActive(false);

        index++;

        if (index < video_pages.Length  && video_pages.Length > 0)
        {
            video_pages[index].gameObject.SetActive(true);
        }
    }

    public void Open_Video(Oakley_VR_Step_Controller step , video_tutorial video_index )
    {
        //Debug.LogError(video_index);
        foreach (Oakley_Video_Controller video in video_pages)
        {
           
            video.gameObject.SetActive(false);
            if (video_index != video_tutorial.none)
            {
                if (video.cur_video == video_index)
                {
                    video.gameObject.SetActive(true);
                    video.Set_Listener(step);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

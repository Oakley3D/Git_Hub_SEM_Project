using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Audio_Manager : MonoBehaviour
{
    public AudioClip btn_sound;
    public AudioClip page_sound;
    public AudioClip page_finish_sound;
    public static Oakley_Audio_Manager instance;
    AudioSource audio_source;
    float timer = 0;
    public void Play_Btn_Sound()
    {
        if (timer < 1) return;
        GameObject runtime = new GameObject();
        audio_source = runtime.AddComponent<AudioSource>();
        audio_source.clip = btn_sound != null ? btn_sound : null;
        audio_source.Play();
        Destroy(runtime, 2);
    }

    public void Play_Page_Sound()
    {
        if (timer < 1) return;
        GameObject runtime = new GameObject();
        audio_source = runtime.AddComponent<AudioSource>();
        audio_source.clip = page_sound != null ? page_sound : null;
        audio_source.Play();
        Destroy(runtime, 2);
    }

    public void Page_Finish_Sound()
    {
        if (timer < 1) return;
        GameObject runtime = new GameObject();
        audio_source = runtime.AddComponent<AudioSource>();
        audio_source.clip = page_finish_sound != null ? page_finish_sound : null;
        audio_source.Play();
        Destroy(runtime, 2);
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}

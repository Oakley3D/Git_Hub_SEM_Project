using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[System.Serializable]
public class Rawimage_Data
{
    public RawImage image;
    public Texture2D[] texture;
    public float change_time = 3;
    int image_index = 0;
    float timer = 0;
    public void Reset()
    {
        timer = 0;
        if (texture.Length > 0)
        {
            image.texture = texture[0];
        }
    }
    public void Loop()
    {
        timer += Time.deltaTime;
        if (timer > change_time)
        {
            timer = 0;
            if (image_index < texture.Length-1)
            {
                image_index++;
                image.texture = texture[image_index];
            }
        }
    }
    
}

public class Image_Data
{
    public Image image;
    public Sprite[] texture;

    public float change_time = 3;
    int image_index = 0;
    float timer = 0;
    public void Reset()
    {
        timer = 0;
        if (texture.Length > 0)
        {
            image.sprite = texture[0];
        }
    }
    public void Loop()
    {
        timer += Time.deltaTime;
        if (timer > change_time)
        {

            timer = 0;
            if (image_index < texture.Length - 1)
            {
                image_index++;
                image.sprite = texture[image_index];
            }
        }
    }
}



public class Oakley_UI_Image_Change_Setting : MonoBehaviour
{
    public Rawimage_Data[] rawimage_datas;
    public Image_Data[] image_datas;
    public float finish_time = 0;
    public float timer = 0;
    bool finish = false;
    public UnityEvent finish_event;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
        if (rawimage_datas != null)
        {
            
                foreach (Rawimage_Data data in rawimage_datas)
                {
                    data.Reset();
                }
            }
        if (image_datas != null)
        {
            foreach (Image_Data data in image_datas)
            {
                data.Reset();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer > finish_time)
        {
            if (finish == false)
            {
                finish = true;
                finish_event.Invoke();
            }
        }
        if (rawimage_datas != null)
        {
            foreach (Rawimage_Data data in rawimage_datas)
            {
                data.Loop();
            }
        }
        if (image_datas != null)
        {
            foreach (Image_Data data in image_datas)
            {
                data.Loop();
            }
        }

        

    }
}

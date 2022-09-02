using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AA_Check_Value_Controller : MonoBehaviour
{
    public Image value_img;
    public float min = 0, max = 1;
    public float max_timer = 5;
    float timer = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > max_timer) return;
        float value = Mathf.Lerp(min, max, timer / max_timer);
        value_img.fillAmount = value;
    }
}

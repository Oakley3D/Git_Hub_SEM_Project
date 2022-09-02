using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AA_Leak_Test_Controller : MonoBehaviour
{
    public Text abs_text;
    public GameObject leak_test_img;
    public Image leak_status_img;

    public float leak_test_time = 3f;
    float timer = 0;
    public float min_value = -1, max_value = -2;
    public float range = 0.05f;
    float update_time = 0;
    // Start is called before the first frame update
    bool is_start = false;
    void OnEnable()
    {
        timer = 0;
        is_start = false;
        leak_test_img.SetActive(false);
        leak_status_img.fillAmount = 0;
    }

    public void Start_Leak()
    {
        leak_test_img.SetActive(true);
        timer = 0;
        is_start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_start == false) return;
        timer += Time.deltaTime;
        float value = Mathf.Min( timer / leak_test_time , 1 );
        if (value > 1)
        {
            abs_text.text = max_value.ToString("F4");
        }
        if (value >= 1) return;

        leak_status_img.fillAmount = value;
        if (timer > update_time)
        {
            float data = Mathf.Lerp(min_value, max_value, value);
            float simulate = data + Random.Range(-range, range);
            abs_text.text = simulate.ToString("F4");
            update_time += 0.4f;
        }
        
    }
}

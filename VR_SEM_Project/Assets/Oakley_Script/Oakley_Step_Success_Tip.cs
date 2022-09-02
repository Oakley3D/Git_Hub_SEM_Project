using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oakley_Step_Success_Tip : MonoBehaviour
{
    public string success_tip = "";
    public Sprite bg_image;
    public Oakley_Success_UI_Tip target;
    bool is_show = false;
    // Start is called before the first frame update
    //public float wait_time = 0;
    void Awake()
    {
        target = GameObject.FindObjectOfType<Oakley_Success_UI_Tip>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        is_show = false;
        if (target)
        {
            target.Set_Target(gameObject);
            if (bg_image)
                target.Set_Image(bg_image);
            target.Set_Text(success_tip);
        }
    }

    IEnumerator Show(float wait)
    {
        yield return new WaitForSeconds(wait);

        if (target)
            target.Open_Tip();
    }

    public void Open_Tip(float wait)
    {
        if (is_show) return;

        StartCoroutine(Show(wait));

        is_show = true;
    }
}

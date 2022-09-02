using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oakley_Success_UI_Tip : MonoBehaviour
{
    public Image bg;
    public Text text;
    GameObject target;
    public GameObject tip_panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Set_Text(string txt)
    {
        text.text = txt;
    }

    public void Set_Image(Sprite img)
    {
        bg.sprite = img;
    }

    public void Submit()
    {
        if (target)
        {
            target.SendMessage("Finish", SendMessageOptions.DontRequireReceiver);
           
        }

        tip_panel.SetActive(false);
    }

    public void Set_Target(GameObject _target)
    {
        target = _target;

    }

    public void Open_Tip()
    {
        tip_panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

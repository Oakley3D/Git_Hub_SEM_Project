using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oakley_UI_Image_Change_Manual : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] datas;
    public Image image;

    public void Cheng(int index)
    {
        if (index >= 0 && index < datas.Length) image.sprite = datas[index];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

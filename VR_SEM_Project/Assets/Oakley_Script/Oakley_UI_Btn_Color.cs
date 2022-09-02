using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class Oakley_UI_Btn_Color : MonoBehaviour ,IPointerEnterHandler , IPointerExitHandler
{
    public Color normal_color = Color.white;
    public Color over_color = Color.white;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = over_color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = normal_color;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

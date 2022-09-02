using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Oakley_Btn_Sound_Controller : MonoBehaviour, IPointerClickHandler
{
   
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Oakley_Audio_Manager.instance.Play_Btn_Sound();
    }
}

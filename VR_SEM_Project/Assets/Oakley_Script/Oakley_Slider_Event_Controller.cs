using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Oakley_Slider_Event_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<EventTrigger>();
        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.PointerClick, OnPointClick);
        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.BeginDrag, OnStartDrag);
        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.EndDrag, OnEndDrag);
    }

    void OnStartDrag(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Debug.Log("Start: pointerEventData=" + pointerEventData);

        //if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("設定影片進度");

    }

    void OnPointClick(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Debug.Log("Start: pointerEventData=" + pointerEventData);

      //  if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("開始拖曳影片進度");

    }

    void OnEndDrag(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData)eventData;
        Debug.Log("End: pointerEventData=" + pointerEventData);
       // if (Oakley_Student_History_Controller.instance) Oakley_Student_History_Controller.instance.Save_Help_Event("停止拖曳影片進度");

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddEventTriggerListener(EventTrigger trigger,
                                            EventTriggerType eventType,
                                            System.Action<BaseEventData> callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
        trigger.triggers.Add(entry);
    }
}

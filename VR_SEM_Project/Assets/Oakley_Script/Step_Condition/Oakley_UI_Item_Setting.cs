using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class Toggle_Manager
{
    public Toggle[] toggles;
    public bool is_correct = false;
    public bool Check()
    {
        int count = 0;
        foreach (Toggle toggle in toggles) if ( toggle.isOn) count++;

        if (count == toggles.Length)
            is_correct = true;
        else is_correct = false;

        return is_correct;

    }
}

[System.Serializable]
public class Item_Data_Manager
{
    public Item_Data[] items;

    public bool is_correct = false;

    public bool Check()
    {
        int count = 0;
        foreach (Item_Data item in items)
        {
            if (item.item.value == item.answer)
            {
                item.is_corrected = true;
                count++;
            }
            else
            {
                item.is_corrected = false;
            }
        }

        if (count == items.Length) is_correct = true;
        else is_correct = false;

        return is_correct;
    }

}

[System.Serializable]
public class Item_Data
{
    public Dropdown item;
    public int answer = 0;
    public bool is_corrected = false;

    

}
public class Oakley_UI_Item_Setting : MonoBehaviour
{
    [Header("下拉選單")]
    public Item_Data[] item_datas;
    [Header("Toggle選項")]
    public Toggle[] selected_toggles;
    
    public bool finish = false;
    public bool auto_check = true;
    [Header("選項都被選取時觸發")]
    public UnityEvent finish_event;
    
  //  bool start_check = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Item_Data data in item_datas)
        {
            data.item.onValueChanged.AddListener(delegate
            {
                Manual_Check();
            }
            );
        }
    }
    public void Manual_Check()
    {
        if (auto_check) return;
        int finish_count = 0;
        int finish_toggle_count = 0;
        foreach (Item_Data data in item_datas)
        {
            if (data.item.value == data.answer)
            {
                finish_count++;
            }
        }

        foreach (Toggle data in selected_toggles)
        {
            if (data.isOn)
            {
                finish_toggle_count++;
            }
        }

        
            if (finish_count >= item_datas.Length)
            {
                if (finish_toggle_count >= selected_toggles.Length)
                {
                    if (finish == false)
                    {
                        finish = true;
                        finish_event.Invoke();
                    }
                }
            }
        

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 2f) return;

        int finish_count = 0;
        int finish_toggle_count = 0;
        foreach (Item_Data data in item_datas)
        {
            if (data.item.value == data.answer)
            {
                finish_count++;
            }
        }

        foreach (Toggle data in selected_toggles)
        {
            if (data.isOn)
            {
                finish_toggle_count++;
            }
        }

        if (auto_check)
        {
            if (finish_count >= item_datas.Length)
            {
                if (finish_toggle_count >= selected_toggles.Length)
                {
                    if (finish == false)
                    {
                        finish = true;
                        finish_event.Invoke();
                    }
                }
            }
        }
    }
}

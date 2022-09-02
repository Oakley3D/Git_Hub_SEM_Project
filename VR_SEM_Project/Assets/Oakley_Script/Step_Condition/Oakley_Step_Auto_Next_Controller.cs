using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Oakley_Step_Auto_Next_Controller : MonoBehaviour
{
    [Header("時間到會自動觸發")]
    public float auto_next_time = 3;
    public UnityEvent finish_event;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Auto_Next());
    }

    IEnumerator Auto_Next()
    {
        yield return new WaitForSeconds(auto_next_time);
        finish_event.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

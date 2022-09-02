using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Menu_Controller : MonoBehaviour
{

    public string[] scene_name;
    public SpriteRenderer mask;
    public bool auto_snap = false;
    public void Change_Scene(int index)
    {
        StartCoroutine(Change(index));
    }

    IEnumerator Change(int index)
    {
        float timer = 0;
        Color mask_color = mask.color;
        while (timer < 2)
        {
            timer += Time.deltaTime;
            yield return null;
            mask_color.a = Mathf.Lerp(0, 1, timer / 2);
            mask.color = mask_color;
        }
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name[index]);
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Exit();

        if (auto_snap)
        {
            if (Camera.main != null)
            {
                transform.parent = Camera.main.transform;
                transform.localPosition = Vector3.zero;
                transform.forward = Camera.main.transform.forward;
                transform.localPosition = transform.localPosition  + Camera.main.transform.forward * -0.35f;
            }

        }
    }
}

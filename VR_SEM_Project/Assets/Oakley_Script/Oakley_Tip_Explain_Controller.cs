using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oakley_Tip_Explain_Controller : MonoBehaviour
{
    public Text explain_text;
    public GameObject explain_ui, open_btn;

    public void Use_Explain(bool b )
    {
        if (b == true)
        {
            explain_ui.gameObject.SetActive(false);
            open_btn.SetActive(true);
        }
        else
        {
            explain_ui.gameObject.SetActive(false);
            open_btn.SetActive(false);
        }
    }

    public void Click()
    {
        /*
        if (Oakley_Student_History_Controller.instance)
        {
            Oakley_Student_History_Controller.instance.Save_Help_Event("開啟_操作解說");
        }
        */
    }

    public void Close()
    {
        /*
        if (Oakley_Student_History_Controller.instance)
        {
            Oakley_Student_History_Controller.instance.Save_Help_Event("關閉_操作解說");
        }
        */
    }

    public void OnEnable()
    {
        explain_ui.gameObject.SetActive(false);
        open_btn.SetActive(true);

        
    }

    // Start is called before the first frame update
    void Start()
    {
        open_btn.GetComponent<Button>().onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenScript : MonoBehaviour
{
    public GameObject panel;
    public bool changecolor = false;
    Color32 objColor;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        //objColor = panel.GetComponent<Image>().color;       
    }
    // Update is called once per frame
    void Update()
    {
        if (changecolor)
        {
            if(check)
            {
                objColor = panel.GetComponent<Image>().color;
                check = false;
            }

            if (objColor.a >= 255)
            {
                changecolor = false;
            }
            else
            {
                objColor.a += 3;
                panel.GetComponent<Image>().color = objColor;                
            }
        }

    }
}

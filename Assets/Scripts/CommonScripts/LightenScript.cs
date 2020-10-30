using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightenScript : MonoBehaviour
{
    public GameObject panel;
    bool changecolor = false;
    Color32 objColor;
    // Start is called before the first frame update
    void Start()
    {
        objColor = panel.GetComponent<Image>().color;
        changecolor = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (changecolor)
        {
            if (objColor.a <= 0)
            {
                changecolor = false;
            }
            else
            {
                objColor.a -= 3;
                panel.GetComponent<Image>().color = objColor;
            }
        }
        
    }
}

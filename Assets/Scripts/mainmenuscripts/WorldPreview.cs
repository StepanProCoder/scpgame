using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldPreview : MonoBehaviour
{
    int level;
    float timer = 0;
    public TextMeshProUGUI text;
    DarkenScript dark;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        dark = GetComponent<DarkenScript>();
        using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
        {

            level = Convert.ToInt32(reader.ReadLine());
            reader.Close();


        }

        //if (level == 0)
        //{
        //    using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt", false))
        //    {
        //        level++;
        //        writer.WriteLine(level);
        //        writer.Close();
        //        Debug.Log(level);
        //    }
        //}


        switch(level)
        {
            case 1:
                text.SetText("Subject arrived in complete darkness, leading it to assume that the current location was indoors or subterranean.");
                break;

            case 2:
                text.SetText("bruh2");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3)
        {
            if(check)
            {
                dark.changecolor = true;
                check = false;
            }

            if (!dark.changecolor)
            {
                switch (level)
                {
                    case 1:
                        SceneManager.LoadScene("World1", LoadSceneMode.Single);
                        break;

                    case 2:
                        //SceneManager.LoadScene("World1", LoadSceneMode.Single);                   
                        break;
                }

                timer = 0;
            }
        }
        timer += Time.deltaTime;
    }


    

}

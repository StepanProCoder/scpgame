using AndroidNativeCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasButtons : MonoBehaviour
{
    Button newgamebtn, continuebtn, aboutbtn;
    public GameObject panel;
    Color32 objColor;
    bool changecolor = false;
    bool about = false;
    
    // Start is called before the first frame update
    void Start()
    {
        newgamebtn = GameObject.Find("newgamebtn").GetComponent<Button>();
        continuebtn = GameObject.Find("continuebtn").GetComponent<Button>();
        aboutbtn = GameObject.Find("aboutbtn").GetComponent<Button>();
        objColor = panel.GetComponent<Image>().color;
        newgamebtn.onClick.AddListener(NewGame);
        continuebtn.onClick.AddListener(Continue);
        aboutbtn.onClick.AddListener(About);       
    }

    // Update is called once per frame
    void Update()
    {
        if(changecolor)
        {
            if(objColor.a >= 255)
            {
                changecolor = false;
                if (about)
                {
                    SceneManager.LoadScene("About", LoadSceneMode.Single);
                    about = false;
                }
                else
                {
                    SceneManager.LoadScene("WorldPreview", LoadSceneMode.Single);
                }
            }
            else
            {
                objColor.a+=3;
                panel.GetComponent<Image>().color = objColor;                
            }
        }
    }

    void NewGame()
    {
        
        try
        {
           
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
            {

                int level = Convert.ToInt32(reader.ReadLine());
                reader.Close();
                if (level >= 1)
                {
                    NewGameAlert();
                }                
                
            }

        }
        catch(Exception e)
        {            
            File.Create(Application.persistentDataPath + "/save.txt").Close();
            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt", false))
            {
                writer.WriteLine("1");
                writer.Close();
            }

            changecolor = true;
            //SceneManager.LoadScene("WorldPreview", LoadSceneMode.Additive);
        }
    }
   
    void Continue()
    {
        try
        {
            
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.txt", true))
            {

                int level = Convert.ToInt32(reader.ReadLine());
                reader.Close();
                

            }
            changecolor = true;
            //SceneManager.LoadScene("WorldPreview", LoadSceneMode.Additive);

        }
        catch (Exception e)
        {
            Toast.make("No saves found", Toast.LENGTH_SHORT);
        }
    }

    void About()
    {
        about = true;
        changecolor = true;
    }

    void NewGameAlert()
    {
        AlertDialog alertDialog = new AlertDialog();

        alertDialog.build(AlertDialog.THEME_HOLO_DARK)
        .setTitle("New Game")
        .setMessage("Do you want to start a new game? All progress will be lost")
        .setNegativeButtion("No", () => {  })
        .setPositiveButtion("Yes", () => {
            using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/save.txt", false))
            {
                writer.WriteLine("1");
                writer.Close();

            }
            changecolor = true;
            //SceneManager.LoadScene("WorldPreview", LoadSceneMode.Additive);
        })
        .show();
    }

}

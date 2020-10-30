using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voice : MonoBehaviour
{
    AudioSource voice;
    public AudioClip phrase1;
    public AudioClip phrase2;
    public bool say1 = false;
    bool say2 = false;
    bool presaid = false;
    float time = 0;

    SaveScript save;
    DarkenScript dark;
    GameObject canvas;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        save = GetComponent<SaveScript>();
        canvas = GameObject.Find("Canvas");
        dark = canvas.GetComponent<DarkenScript>();
        voice = GetComponents<AudioSource>()[1];
        voice.clip = phrase1;
        voice.Play();
    }

    public void CollidePhrase()
    {
       
            voice.clip = phrase2;
            voice.Play();
            say2 = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(voice.isPlaying && !presaid && voice.clip == phrase1)
        {
            presaid = true;
        }        
        else if(presaid && !voice.isPlaying && time > 20)
        {
            say1 = true;
        }

        if(say2 && !voice.isPlaying)
        {
            if (check)
            {
                dark.changecolor = true;
                check = false;
            }
            if (!dark.changecolor)
            {                
                save.Save();
                SceneManager.LoadScene("WorldPreview", LoadSceneMode.Single);
            }
           
        }
    }
}

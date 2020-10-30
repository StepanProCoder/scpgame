using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    AudioSource audio;
    bool active = false;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying && active)
        {
            audio.volume = Random.Range(0.8f, 1);
            audio.pitch = Random.Range(1, 1.1f);
            audio.Play();
        }
    }

    public void Breathe()
    {
        active = true;
    }

    

}

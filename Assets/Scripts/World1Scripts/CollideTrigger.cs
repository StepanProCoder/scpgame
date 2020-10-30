using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
    Breathing breath;
    Voice voice;
    CharacterController controller;
    bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        breath = GameObject.Find("breath").GetComponent<Breathing>();
        controller = GetComponent<CharacterController>();
        voice = GetComponent<Voice>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {        
        if (hit.collider.name == "breath" && check && voice.say1)
        {
            breath.Breathe();
            voice.CollidePhrase();
            check = false;
        }

    }

}

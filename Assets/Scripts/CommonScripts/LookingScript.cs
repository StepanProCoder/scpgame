using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookingScript : MonoBehaviour
{
    //public enum RotationAxes
    //{
    //    MouseXAndY = 0,
    //    MouseX = 1,
    //    MouseY = 2
    //}
    //public RotationAxes axes = RotationAxes.MouseXAndY;
    //public float sensitivityHor = 1.5f;
    //public float sensitivityVert = 1.5f;
    //public float minimumVert = -45.0f;
    //public float maximumVert = 45.0f;
    //private float _rotationX = 0;
    //int lastcount = 0;

    //FixedJoystick joystick;
    //Vector2 defdirection;

    //void Start()
    //{
    //    Rigidbody body = GetComponent<Rigidbody>();
    //    if (body != null)
    //    {
    //        body.freezeRotation = true;
    //    }

    //    Input.multiTouchEnabled = true;
    //    joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    //    defdirection = joystick.Direction;

    //}
    //void Update()
    //{
    //    //if (!((Input.mousePosition.x - laststatex > 250 || Input.mousePosition.x - laststatex < -250) || (Input.mousePosition.y - laststatey > 250 || Input.mousePosition.y - laststatey < -250)))
    //    if (Input.touchCount > 0)
    //    {

    //        if (!(Input.touchCount == 1 && joystick.Direction != defdirection) && Input.touchCount >= lastcount && !(Input.touchCount > 1 && joystick.Direction == defdirection)) 
    //        { 

    //        if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Moved)
    //        {

    //            if (axes == RotationAxes.MouseX)
    //            {
    //                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
    //            }
    //            else if (axes == RotationAxes.MouseY)
    //            {
    //                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
    //                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
    //                float rotationY = transform.localEulerAngles.y;
    //                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    //            }
    //            else
    //            {
    //                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
    //                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
    //                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
    //                float rotationY = transform.localEulerAngles.y + delta;
    //                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    //            }


    //        }
    //    }


    //    }

    //    lastcount = Input.touchCount;


    //}

    FixedJoystick joystick;
    

    
    public float sensitivityVert = 170f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }        
        joystick = GameObject.Find("CameraJoystick").GetComponent<FixedJoystick>();
    }

    void Update()
    {
        _rotationX -= joystick.Vertical * sensitivityVert * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
           
}


}

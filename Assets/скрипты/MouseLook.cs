using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour{
    public enum RotationAxes{
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor = 9.0f;
    //вот когда учишь к прммеру матешу, то грызешь гранит науки, а что грызут программисты? компы?
    public float sensitivityVert = 9.0f;

    public float minmumVert = -45.0f;
    public float maxmumVert = 45.0f;

    private float _rotationX = 0;

 
    void Start(){
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) 
        body.freezeRotation = true;
    }
    

    void Update()
    {
        if (axes == RotationAxes.MouseX) {
        

            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

            float rotarionY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotarionY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}

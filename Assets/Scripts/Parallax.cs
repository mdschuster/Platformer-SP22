using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Camera parallaxCamera;
    public float parallaxAmount;

    private Vector3 previousPosition;


    // Start is called before the first frame update
    void Start()
    {
        previousPosition = parallaxCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //the difference in position from where the camera was to where it is now (this will be small)
        Vector3 diff = parallaxCamera.transform.position- previousPosition;
        //moving "this" by that same amount
        this.transform.position += diff*parallaxAmount*0.01f;
        //updating the previous postion
        previousPosition = parallaxCamera.transform.position;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Eyes : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

//A camera exists
    private Camera DaCamera;     
//Interact event
    public static event Action <string>Interacted;


    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Recognising camera
        //I had to set the tag on PlayerCam to "MainCamera" I also layered player to ignore raycast so it stopped hiting the player every time.
        DaCamera = Camera.main;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //Checking for interact
        if (Input.GetKeyDown(KeyCode.E)){
            // Debug.Log ("Ya pressed E, Bukko");
            ShootInteractBeam();
        };
    }

//Adam trying to figure out Raycast for interact
    private void ShootInteractBeam(){
        //where to shoot (straight)
    Ray InteractBeam = DaCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

    //It hits what it hits
    RaycastHit WhatItHit;

    //FIRE!
    // Right now it's firing 100 float value away, and kinda hard to see with no retical or anything.
    if (Physics.Raycast(InteractBeam, out WhatItHit, 100f)){
        string TargetStruck = WhatItHit.collider.gameObject.name;
        Debug.Log(TargetStruck);
        Interacted?.Invoke(TargetStruck);
    };
    }












}
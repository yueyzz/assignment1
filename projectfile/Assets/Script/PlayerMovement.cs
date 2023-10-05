using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
  
    public float speed = 5f;
    public Animator anim;
    public Rigidbody rb;
    public Text GyroText;
    public Text AccText;
    private void Start()
    {
        Input.gyro.enabled = true;
       anim.SetBool("Walk",false);
     
    }

    void Update()
    {

        PlayerMove();
        PlayerRotate();
        GyroText.text = Input.gyro.attitude.ToString();
      //print gyro
    }
  /// <summary>
  /// player move 
  /// use animator
  /// from https://docs.unity3d.com/2022.1/Documentation/Manual/class-Animator.html
  /// </summary>
    public void PlayerMove()
    {
        // Detect finger touching screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

           // moving direction
                Vector3 movement = transform.forward * speed * Time.deltaTime;

                // moving 
                transform.position += movement;
              print("w");
              //Play walking animation
              anim.SetBool("Walk",true);
        
        }
        else
        {
            anim.SetBool("Walk",false);
        }
    }
    /// <summary>
    /// Use acceleration to determine character rotation
    /// </summary>
    public void PlayerRotate()
    {
        Vector3 dir = Vector3.zero;
        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis

        // dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;
        
       
        if(dir.z>0.015)
        {
         //Let the characters rotate
            gameObject.transform.Rotate(0,1,0); 
            AccText.text = dir.z.ToString();
          //  print acceleration
        }
        if(dir.z<-0.015)
        {
            //Let the characters rotate
            gameObject.transform.Rotate(0,-1,0); 
            //  print acceleration
            AccText.text = dir.z.ToString();
        }
    }
}

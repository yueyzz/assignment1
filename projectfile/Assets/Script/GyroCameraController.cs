using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCameraController : MonoBehaviour
{
    private Gyroscope gyro;
    /// <summary>
/// Turn on gyroscope and use gyro
/// </summary>
    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            
        }
        else
        {
            Debug.LogError("Device does not support gyroscope");
        }
    }
/// <summary>
/// Control camera rotation
/// </summary>
    private void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            if (Input.gyro.attitude.x>-0.3f)
            {
                //rotate camera
                gameObject.transform.Rotate(1,0,0); 
            }
            if (Input.gyro.attitude.x<-0.6f)
            {
                //rotate camera
                gameObject.transform.Rotate(-1,0,0); 
            }
        }
    }

}

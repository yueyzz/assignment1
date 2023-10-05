using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

/// <summary>
/// Use the collision body to determine whether the player collides
/// form https://docs.unity3d.com/2022.1/Documentation/Manual/class-MonoBehaviour.html
/// </summary>
/// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(gameObject);
            //Record quantity
            UIManager.Instance.coinNum += 1;
        }
    }
}

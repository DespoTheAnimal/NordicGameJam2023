using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTest : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetButtonDown("Shoot_P1"))
        {
            Debug.Log("Player one shoot");
        }
        if (Input.GetButtonDown("Shoot_P2"))
        {
            Debug.Log("Player two shoot");
        }
    }
}

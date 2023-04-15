using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    public string otherCollider;

    private void OnTriggerEnter(Collider other)
    {
        otherCollider = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        otherCollider = null;
    }
}

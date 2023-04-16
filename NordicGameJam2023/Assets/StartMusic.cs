using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    private void OnDisable()
    {
        audioSource.Play();
    }
    private void OnEnable()
    {
        audioSource.Stop();
    }
}

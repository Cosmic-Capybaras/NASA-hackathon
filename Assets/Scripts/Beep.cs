using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beep : MonoBehaviour
{
    public AudioSource audioSource;
    public void Boop()
    {
        audioSource.Play();
    }
}

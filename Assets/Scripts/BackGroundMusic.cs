using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public static BackGroundMusic instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //AudioSource audioSource = GetComponent<AudioSource>();
        //audioSource.Play(audioSource.clip.);
        DontDestroyOnLoad(gameObject);
    }
}

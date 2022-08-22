using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public static BackGroundMusic instance;

    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        //audioSource.Play(audioSource.clip.);
        DontDestroyOnLoad(gameObject);
    }
}

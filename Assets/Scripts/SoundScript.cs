using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip anySound;

    [SerializeField]
    private AudioSource audiSource;

    public void PlayThatSound()
    {
        audiSource.PlayOneShot(anySound);
    }
}

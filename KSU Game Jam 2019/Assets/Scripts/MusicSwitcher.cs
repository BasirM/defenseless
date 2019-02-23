using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip BGM;
    public Rigidbody2D Player;
    private bool hasLeftHome = false;
    private float startVolume = 0;

    // Start is called before the first frame update
    void Start()
    {
        startVolume = audio.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLeftHome && Player.position.y < 5)
        {
            hasLeftHome = true;
            audio.clip = BGM;
            audio.volume = startVolume;
            audio.Play();
        }
        else if (!hasLeftHome && Player.position.y < 8.5)
        {
            if (audio.volume > 0.01f)
            {
                audio.volume -= startVolume * .015f;
            }
            else audio.Stop();
        }
    }

}

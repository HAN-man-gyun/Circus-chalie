using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource coinAudio;
    //public AudioClip coinClip;
    private SpriteRenderer coinRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //coinAudio.clip = coinClip;
        coinRenderer = GetComponent<SpriteRenderer>();
        coinAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            GameManager.instance.score += 100;
            coinAudio.Play();
            coinRenderer.enabled =false;
        }
    }
}

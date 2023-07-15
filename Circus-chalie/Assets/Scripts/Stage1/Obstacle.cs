using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameObject.transform.position.x <-20)
        //{
        //    Destroy(gameObject);
        //}
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.life -= 1;
            Debug.LogFormat("현재라이프{0}", GameManager.instance.life);
            if(GameManager.instance.life == 0)
            {
                player.Die();
            }
        }
    }*/
}

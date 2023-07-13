using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;
using UnityEngine.XR;

public class ScrollingBackGround : MonoBehaviour
{
    public float speed = 2f;
    private float xInput;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover == false)
        {
            Debug.LogFormat("상태입니다.{0}", GameManager.instance.isGameover);
            Debug.Log("좌우로움직이기");
            xInput = Input.GetAxisRaw("Horizontal");
            //playerRenderer.flipX = xInput == -1;

            if (!GameManager.instance.isGameover)
            {
                if (xInput == 1)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                if (xInput == -1)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObstacles : MonoBehaviour
{
    public float Speed  = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}

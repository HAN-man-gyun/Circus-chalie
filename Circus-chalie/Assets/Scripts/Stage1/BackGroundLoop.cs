using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <=-width)
        {
            Reposition();
        }
        else if(transform.position.x >=width)
        {
            BackPosition();
        }
    }
    private void Reposition()
    {
        Vector2 offset = new Vector2(width* 2f, 0);
        transform.position = (Vector2)transform.position + offset;
        GameManager.instance.meter += 10;
    }
    private void BackPosition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position - offset;
        GameManager.instance.meter -= 10;
    }
}

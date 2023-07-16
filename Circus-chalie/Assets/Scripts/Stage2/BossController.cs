using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D BossRigidbody;
    public GameObject Target;
    float h;
    private void Awake()
    {
        BossRigidbody = GetComponent<Rigidbody2D>();
        Target = GetComponent<GameObject>();

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        h = Target.transform.position.x;
        if (h > gameObject.transform.position.x)
        {
            Invoke("Think", 3);
            BossRigidbody.velocity = new Vector2(h * (-1), BossRigidbody.velocity.y);
        }
        else if(h < gameObject.transform.position.x)
        {
            Invoke("Think", 3);
            BossRigidbody.velocity = new Vector2(h, BossRigidbody.velocity.y);
        }
    }

   
}

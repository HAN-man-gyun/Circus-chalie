using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public AudioClip Skill1;
    public AudioClip Skill2;
    public AudioClip DeathClip;
    public AudioClip ClearClip;
    private float speed = 5f;
    private int jumpCount = 2;
    private float jumpForce = 500f;
    // Start is called before the first frame update

    private bool isGrounded = false;
    private bool isDead = false;

    private SpriteRenderer renderer;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private AudioSource audio;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
       
        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            //����Ƚ������
            jumpCount++;
            //AddForce�� �����ϱ�
            rigidbody.AddForce(new Vector2(0, jumpForce));

            //������ҽ����
            audio.Play();
            //
            Debug.LogFormat("����ī���ʹ�{0}��.", jumpCount);
        }
        if (isGrounded == true)
        {
            rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
        }
        animator.SetBool("Grounded", isGrounded);
    }
    public void Die()
    {
        Debug.Log("���⼭ ����ǥ�ð��ɰ��̴�.");
        animator.SetTrigger("Die");
        audio.clip = DeathClip;
        audio.Play();
        rigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    public void Clear()
    {
        Debug.Log("���⼭ �¸�ǥ�ð��ɰ��̴�.");
        animator.SetTrigger("Die");
        audio.clip = ClearClip;
        audio.Play();
        rigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnClearGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Dead" && isDead == false)
        {

            Debug.LogFormat("���������{0}", Static.life);

            Die();
            Static.life -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "End" && isDead == false)
        {
            Clear();
        }
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

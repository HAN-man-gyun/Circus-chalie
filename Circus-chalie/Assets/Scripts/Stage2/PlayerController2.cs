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
    private int jumpCount = 0;
    private float jumpForce = 10f;
    private float maxSpeed = 5f;
    // Start is called before the first frame update

    private bool isMoving = false;
    private bool isDead = false;

    private SpriteRenderer playerRenderer;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetButtonDown("Jump")&&(animator.GetBool("isJumping")==false))
        {
            playerRigidbody.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.normalized.x * 0.5f, playerRigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            playerRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        if(Mathf.Abs(playerRigidbody.velocity.normalized.x) <0.3f)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
    }
    private void FixedUpdate()
    {
        float xSpeed = Input.GetAxisRaw("Horizontal");
        playerRigidbody.AddForce(xSpeed * Vector2.right, ForceMode2D.Impulse);
        if (playerRigidbody.velocity.x > maxSpeed)
        {
            playerRigidbody.velocity = new Vector2(maxSpeed, playerRigidbody.velocity.y);
        }
        else if (playerRigidbody.velocity.x < maxSpeed * -1)
        {
            playerRigidbody.velocity = new Vector2(maxSpeed * -1, playerRigidbody.velocity.y);
        }

        if (playerRigidbody.velocity.y < 0)
        {
            Debug.DrawRay(playerRigidbody.position, Vector2.down, Color.black);
            RaycastHit2D rayHit = Physics2D.Raycast(playerRigidbody.position, Vector2.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.5f)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }
    }
    public void Die()
    {
        Debug.Log("여기서 죽음표시가될것이다.");
        animator.SetTrigger("Die");
        playerAudio.clip = DeathClip;
        playerAudio.Play();
        playerRigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    public void Clear()
    {
        Debug.Log("여기서 승리표시가될것이다.");
        animator.SetTrigger("Die");
        playerAudio.clip = ClearClip;
        playerAudio.Play();
        playerRigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnClearGame();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "End" && isDead == false)
        {
            Clear();
        }
        if (collision.collider.tag == "Boss" && isDead == false)
        {

            Debug.LogFormat("현재라이프{0}", Static.life);

            Static.life -= 1;
        }
    }
}

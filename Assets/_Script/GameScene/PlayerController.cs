using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce;

    [SerializeField]
    bool isGround = false;

    [SerializeField]
    Animator playerAnim;

    [SerializeField]
    bool AnimIsJump;

    public static bool isHittedInSummer;
    public float _SummerSpikeHitForce;

    public float _bounceForce;




    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isHittedInSummer = false;
    }

    void Start()
    {
        //AnimIsJump = playerAnim.GetBool("isJump");
        AnimIsJump = false;

    }

    void Update()
    {
        Debug.Log(rb.velocity.x);
        Jump();

        if (isHittedInSummer)
        {
            SummerSpikeHitMovement();
            //if(isGround) rb.AddForce(Vector2.right * _SummerSpikeHitForce, ForceMode2D.Impulse);
            //if(isGround) rb.velocity = new Vector2(0, rb.velocity.y);
            //isHittedInSummer = false;
        }

    }

    private void Jump()
    {
        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Stamina.Instance._slider.value >= Stamina.Instance._staminaUse)
            {
                //rb.AddForce(new Vector2(0, jumpForce));
                rb.AddForce(Vector2.up* jumpForce);
                isGround = false;
                AnimIsJump = true;
                playerAnim.SetBool("isJump", true);

                //Using stamina
                Stamina.Instance.UsingStamina(Stamina.Instance._staminaUse);

                //play jump sound
                AudioMg.Instance.playSoundEffect(0);

            }
            else
            {
                playerAnim.SetBool("isJump", false);
                AnimIsJump = false;
            }
        }

    }

    // When hit by spikes in summer, player will not die, instead, apply a force to player rigidbody.
    void SummerSpikeHitMovement()
    {
        rb.AddForce(Vector2.left * _SummerSpikeHitForce + Vector2.up * _SummerSpikeHitForce, ForceMode2D.Impulse);
        isGround = false;
        isHittedInSummer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            
        }
        if (collision.gameObject.CompareTag("OC_wall"))
        {
            isGround = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (collision.gameObject.CompareTag("FinalCheckPt"))
        {
            Debug.Log("To next scene");
            var scene = SceneManager.GetActiveScene().buildIndex;
            // When finishing the 'winter' scene, jumps back to 'spring'
            if (scene == 5)
            {
                scene = 0;
            }
            SceneManager.LoadScene(scene + 1);
        }
        if(collision.gameObject.CompareTag("OC_bounceFloor"))
        {
            rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);
            isGround = false;
        }

        // play sound effect in each situation.
        switch (collision.gameObject.tag)
        {
            case "OC_bounceFloor":
                AudioMg.Instance.playSoundEffect(1);
                break;
            case "OC_spike":
                AudioMg.Instance.playSoundEffect(2);
                break;
            case "OC_wall":
                AudioMg.Instance.playSoundEffect(3);
                break;

        }
    }
}


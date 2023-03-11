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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        //AnimIsJump = playerAnim.GetBool("isJump");
        AnimIsJump = false;

    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Stamina.Instance._slider.value >= Stamina.Instance._staminaUse)
            {
                rb.AddForce(new Vector2(0, jumpForce));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("OC_wall"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("FinalCheckPt"))
        {
            Debug.Log("To next scene");
            var scene = SceneManager.GetActiveScene().buildIndex;
            // When finishing the 'winter' scene, jumps back to 'spring'
            if (scene == 4)
            {
                scene = 0;
            }
            SceneManager.LoadScene(scene + 1);
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


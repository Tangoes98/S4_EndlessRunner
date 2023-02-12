using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float _speed;

    void Update()
    {
        obsMovement();
        //Debug.Log(gameObject.tag);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // if collide with player, pause the game and show the score page.
        if (gameObject.tag == "OC_spike")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneController.InGameMenu();
                Time.timeScale = 0;
            }
        }

        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            Destroy(this.gameObject);

        }
    }

    void obsMovement()
    {
        transform.Translate(-_speed * Time.deltaTime, 0f, 0f);
    }


}

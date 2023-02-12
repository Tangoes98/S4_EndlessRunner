using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutsideChecker : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneController.InGameMenu();
            Time.timeScale = 0;
        }
    }
}

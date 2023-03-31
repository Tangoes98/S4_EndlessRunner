using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float _speed;

    [System.Serializable]
    struct Data
    {
        public string name;
        public Vector3 position;
        public float currentStamina;

    }


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
            if (collision.gameObject.CompareTag("Player"))  // when hitting player & game over
            {
                SceneController.InGameMenu();
                Time.timeScale = 0;

                var data = new Data();
                data.name = collision.gameObject.name;
                data.position = collision.transform.position;
                data.currentStamina = Stamina.Instance.CurrentStamina();

                TelemetryLogger.Log(this, "kill", data); // Telemetry log

            }
        }

        if (gameObject.tag == "OC_SummerSpike")
        {
            PlayerController.isHittedInSummer = true;
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

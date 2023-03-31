using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float _speed;

    [System.Serializable]
    struct KillingStaminaData
    {
        public int currentStamina;
    }


    void Update()
    {
        obsMovement();

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

                var data = new KillingStaminaData();
                data.currentStamina = Mathf.RoundToInt(Stamina.Instance.CurrentStamina());
                var scene = SceneManager.GetActiveScene().buildIndex;
                var deathGamePercentage = EndingCheckPoint._disToPercent.ToString() + "%";

                TelemetryLogger.Log(this, "KillingScene", scene); // Telemetry log killing scene
                TelemetryLogger.Log(this, "KillingStaminaData", data); // Telemetry log killing remaining Stamina
                TelemetryLogger.Log(this, "KillingScoreData", deathGamePercentage); // Telemetry log killing percentage of the game.

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

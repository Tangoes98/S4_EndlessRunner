using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    // A timer function designed for record time for each level.
    // For telemetry use.

    float _timer = 0;
    int _level;

    public static bool _levelFinished;

    // count player death times.

    public int deathCount = 0;
    public double playtime;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        _level = SceneManager.GetActiveScene().buildIndex;

        switch (_level)
        {
            case 2:
                LogResetPlaytimeDeathcount();
                break;
            case 3:
                LogResetPlaytimeDeathcount();
                break;
        }
    }

    void LogResetPlaytimeDeathcount()
    {
        _timer += Time.deltaTime;
        playtime = System.Math.Round(_timer, 2);
        if (_levelFinished)
        {
            // Debug.Log("PlayTime is: " + playtime);
            // Debug.Log("Deathcount: " + deathCount);
            deathCount = 0;
            _levelFinished = false;
            _timer = 0;
        }
    }


}

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    // declare score
    float score = 0;


    void Update()
    {
        // reference the text
        var scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        // score plus plus
        score += 1f * Time.deltaTime * 3f;

        // text score
        if (EndingCheckPoint._disToPercent <= 100)
        {
            scoreText.text = "Process: " + EndingCheckPoint._disToPercent.ToString() + "% / 100%";

        }
        else
        {
            scoreText.text = "Process: " + "Please enter next level";
        }

    }

    public float currentScore()
    {
        return score;
    }

}

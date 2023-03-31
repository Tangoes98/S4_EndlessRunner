using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextController : MonoBehaviour
{
    public float textShowTime;
    public float textIntervalTime;
    public List<GameObject> textObjects;
    public GameObject backgroundPanel;


    void Awake()
    {
        // hide all text
        for (int i = 0; i < textObjects.Count; i++)
        {
            textObjects[i].SetActive(false);
        }

        // hide text background panel
        backgroundPanel.SetActive(false);
    }
    IEnumerator ShowTutorialText()
    {
        Debug.Log("start coroutine");
        int textSlide = 0;
        while (textSlide < textObjects.Count)
        {
            textObjects[textSlide].SetActive(true);
            ShowBgPanel(true);
            yield return new WaitForSeconds(textShowTime);
            textObjects[textSlide].SetActive(false);
            ShowBgPanel(false);
            yield return new WaitForSeconds(textIntervalTime);
            textSlide++;
        }

    }

    public void RunTutorialText()
    {
        StartCoroutine("ShowTutorialText");
    }


    // Show background panel when text is enabled
    void ShowBgPanel(bool isTextEnabled)
    {
        if (isTextEnabled) backgroundPanel.SetActive(true);
        else backgroundPanel.SetActive(false);
    }

}

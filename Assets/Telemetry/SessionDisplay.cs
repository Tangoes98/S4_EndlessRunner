using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionDisplay : MonoBehaviour
{
    public TextMeshProUGUI textfield;
    public void OnSuccess(int sessionIndex)
    {
        //var field = GetComponent<TMPro.TextMeshPro>();
        textfield.text = $"Session: {sessionIndex}";

    }

    public void OnFail(string error)
    {
        //var field = GetComponent<TMPro.TextMeshPro>();
        textfield.text = $"Session: {error}";
    }
}

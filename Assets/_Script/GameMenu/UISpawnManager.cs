using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnManager : MonoBehaviour
{
    public List<GameObject> _UIobjects;
    public List<Transform> _UISpawnPos;

    void Start()
    {
        for (int i = 0; i < _UIobjects.Count; i++)
        {
            for (int j = 0; j < _UISpawnPos.Count; j++)
            {
                if (i == j)
                {
                    _UIobjects[i].transform.position = _UISpawnPos[j].position;
                    //Debug.Log("i:" + i + "j:" + j);
                }
            }
        }
    }
}

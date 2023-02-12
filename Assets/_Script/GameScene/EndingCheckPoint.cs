using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheckPoint : MonoBehaviour
{
    public Transform p_player;
    public Transform p_endingPointMesh;
    Vector3 _startPosition;
    public float m_speed;
    float p_distance;
    float p_totalDistance;
    public static int _disToPercent;

    void Awake()
    {
        p_distance = Vector3.Distance(transform.position, p_player.position);
        p_totalDistance = p_distance;
        _startPosition = transform.position;
    }
    void Update()
    {
        Movement();
        
        p_distance = Vector3.Distance(transform.position, _startPosition);
        _disToPercent = Mathf.RoundToInt(p_distance / p_totalDistance * 100f);

        //Debug.Log(_disToPercent + " %");
    }

    void Movement()
    {
        p_endingPointMesh.Translate(-m_speed * Time.deltaTime, 0f, 0f);
    }
}

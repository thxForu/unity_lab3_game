using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;


    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time/speed, 1));
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // if lives > 1 --> lives--
            // else {}
            Destroy(col.gameObject);

        }
    }
}

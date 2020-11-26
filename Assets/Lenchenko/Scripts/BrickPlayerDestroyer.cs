using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPlayerDestroyer : MonoBehaviour
{

    public float speed;
    public float distance;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>= distance || transform.position.y <= -distance){
            direction *=-1;
        }
        transform.Translate(direction*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && Enemy.damageAble){
            Destroy(other.gameObject);
        }
    }
}

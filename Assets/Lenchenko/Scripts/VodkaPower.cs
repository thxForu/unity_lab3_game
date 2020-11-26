using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VodkaPower : MonoBehaviour
{
    public GameObject OffMePls;
    public float sec;
    private void Start() {
        GameEvents.current.invulerAb += InvulerAb;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,60,0) * Time.deltaTime);
    }

    private void InvulerAb(){
        OffMePls.SetActive(false);
        StartCoroutine(WaitCoroutine());

    }

    private IEnumerator WaitCoroutine(){
        Enemy.damageAble = false;
        yield return new WaitForSeconds(sec);
        Enemy.damageAble = true;
    }
}

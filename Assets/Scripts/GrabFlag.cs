using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFlag : MonoBehaviour
{
    public GameObject youWinText;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Freeze), 0.1f);
            print("bruh");
        } 

    }

    public void Freeze()
    {
        youWinText.SetActive(true);
        Time.timeScale = 0f;
    }
}

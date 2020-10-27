using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFlag : MonoBehaviour
{
    public GameObject youWinText;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("Freeze", 0.1f);
    }

    public void Freeze()
    {
        youWinText.SetActive(true);
        Time.timeScale = 0f;
    }
}

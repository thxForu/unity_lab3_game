using System.Collections;
using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    // Start is called before the first frame update
    private void Awake() 
    {
        current = this;    
    }

    public event Action invulerAb;
    public void InvulerAb(){
        if(invulerAb != null){
            invulerAb();
        }
    }
}

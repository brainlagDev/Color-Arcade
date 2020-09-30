using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBotLogic : MonoBehaviour
{
    public GameObject gun;

    private void Update()
    {
        gun.GetComponent<GunScript>().Fire();        
    }
}

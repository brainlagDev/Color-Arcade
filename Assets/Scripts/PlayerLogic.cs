using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject gun;
   
    private void Update()
    {
        
        Debug.Log("Fire");
        gun.GetComponent<GunScript>().Fire();            
        
    }
}

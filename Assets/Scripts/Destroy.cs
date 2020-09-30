using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyParticle", 0.1f);
    }

    private void DestroyParticle()
    {
        Destroy(this.gameObject);
    }
}

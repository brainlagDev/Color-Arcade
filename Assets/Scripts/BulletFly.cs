using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem part;
    public float force = 300f;
    public float lifetime = 3f;
    public float vec;
    private bool shoot = false;
    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        vec = GameObject.Find("Player Variant").GetComponent<Transform>().localScale.x / 5;
        Debug.Log(vec);
        if(shoot == false)
        {
            rb.AddForce(new Vector2(vec + Random.Range(-0.2f, 0.2f), 0.5f) * force, ForceMode2D.Force);
            shoot = true;
        }
    }
    void DestroyBullet()
    {
        Instantiate(part, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    public float DealDamage()
    {
        Debug.Log("DamageDelt");
        float score = GameObject.Find("Player Variant").GetComponent<Movement>().Score;
        return score + 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(part, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.1f);
        }
    }
}

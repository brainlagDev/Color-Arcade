using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float Score { set; get; }
    public Text txt;
    public CharacterController2D controller;
    public Animator anim;
    public Rigidbody2D rb;
    public float speed = 10f;
    public float horSpd = 0f;
    public string scene;
    public bool jump = false;
    private void Awake()
    {
        Score = 0;
    }
    void Update()
    {
        if(Score > 20)
        {
            SceneManager.LoadScene(scene);
        }
        horSpd = Input.GetAxisRaw("Horizontal") * speed;
        anim.SetFloat("Speed", Mathf.Abs(horSpd));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        txt.text = "Score: " + Score;
        Debug.Log(Score);
    }
    private void FixedUpdate()
    {
        controller.Move(horSpd * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void OnLand()
    {
        anim.SetBool("IsJumping", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log(Score + "Collision");
        if (collision.gameObject.tag == "EnemyBullet")
            Score++;
        if (collision.gameObject.tag == "PlayerBullet")
            Score--;
        //GameObject.Find("HealthBar").GetComponent<SliderScript>().HealthSet(Health);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}

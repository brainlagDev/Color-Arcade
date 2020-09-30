using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIBotMovement : MonoBehaviour
{
    public float speed = 10f;
    public float horSpd = 0f;
    public float changeTimeInterval;
    public int EnemyScore { set; get; }
    public int directionMove;
    public bool jump = false;
    public CharacterController2D controller;
    private GameObject _timer;
    public GameObject tempTimer;
    public Text txt;
    private Action _сhangeDirection;
    private void Start()
    {
        directionMove = 1;
        _сhangeDirection += ChangeDirectionMove;
        _timer = Instantiate(tempTimer);
        _timer.GetComponent<Timer>().StartTimer(changeTimeInterval, _сhangeDirection);
        EnemyScore = 0;
    }

    void Update()
    {
        txt.text = "Enemy Score: " + EnemyScore;
        horSpd = directionMove * speed;//Заменить на рандом рендж через несколько сек по таймеру
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horSpd * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void ChangeDirectionMove()
    {
        directionMove = UnityEngine.Random.Range(-1,2);
        _timer.GetComponent<Timer>().StartTimer(changeTimeInterval, _сhangeDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Let")
        {
            int numberEventVariant = UnityEngine.Random.Range(1, 4);
            //Три варианта развития события при столкновении с препятствием,
            //1 - меняем направление движения 
            //2 - прыгаем 
            //3 - прыгаем и меняем направление
            if (numberEventVariant == 1)
            {
                directionMove *= -1;
            }
            else if(numberEventVariant == 2)
            {
                jump = true;
            }
            else
            {
                directionMove *= -1;
                jump = true;
            }
        }
        if(collision.gameObject.tag == "PlayerBullet")
        {
            EnemyScore++;
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            EnemyScore--;
        }
    }

}

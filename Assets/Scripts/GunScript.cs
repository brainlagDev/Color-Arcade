using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject tempTimer;
    public GameObject aimPoint;
    [Range(0,1)] public float bulletTimeInterval;//Интервал времени между выстрелами в секундах
    [Range(0,1)] public float speedRotateGun;//Скорость вращения оружия

    private Action _chargeBullet;
    private GameObject _timer;
    private bool _bulletIsLoaded;

    private void Start()
    {
        _chargeBullet += ChargeBullet;
        _timer = Instantiate(tempTimer);
        _bulletIsLoaded = true;
    }

    void Update()
    {
    //    var aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    var aimDir = aimTarget - transform.position;
    //    aimDir.z = transform.up.z;
    //    aimDir = aimDir.normalized;
    //    transform.right = Vector3.MoveTowards(transform.right, aimDir, speedRotateGun * Time.fixedDeltaTime);
    }

    public void Fire()
    {
        if (_bulletIsLoaded)
        {
            CreateBullet();
        }                 
    }

    private void CreateBullet()
    {
        
        Instantiate(bulletPrefab, aimPoint.transform.position, transform.rotation);
        _bulletIsLoaded = false;
        _timer.GetComponent<Timer>().StartTimer(bulletTimeInterval, _chargeBullet);
    }

    private void ChargeBullet()
    {
        _bulletIsLoaded = true;
    }
}

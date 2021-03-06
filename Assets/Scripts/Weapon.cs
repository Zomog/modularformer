﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate;
    public float damage = 10;
    public LayerMask ToHit;

    float timeToFire = 0;
    Transform firePoint;

    void Start () {

        firePoint = transform.Find("FirePoint");

	}

	void Update () {
    
        if(fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if(Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1/fireRate;
                Shoot();
            }
        }

	}

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, ToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100);

        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
			Debug.Log ("pow");
        }
    }
}

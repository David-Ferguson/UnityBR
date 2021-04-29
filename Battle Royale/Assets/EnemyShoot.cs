﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject Bullet = null;
    public float shotCooldown = 0f;
    void Update()
    {
        shotCooldown = shotCooldown - Time.deltaTime;
        if (shotCooldown <= 0)
        {   
            var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            float angle = Mathf.Acos(this.gameObject.GetComponent<EnemyAI>().targetDirection.x);
            if (this.gameObject.GetComponent<EnemyAI>().targetDirection.y < 0)
            {
               angle = angle + (Mathf.PI - angle) * 2;
            }
            if (transform.position.x > 500)
            {
                angle = Convert.ToSingle(GameObject.Find("Players").GetComponent<Spawner>().rand.NextDouble()) * 360;
            }
            bullet.GetComponent<Bullet>().angle = angle;
            if (transform.position.x < 500)
            {
                shotCooldown = 0.1f;
            } else
            {
                shotCooldown = 1;
            }
            bullet.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<Renderer>().material.color;
            bullet.GetComponent<Bullet>().shooter = this.gameObject;
            bullet.tag = "Bullet";
        }
    }
}

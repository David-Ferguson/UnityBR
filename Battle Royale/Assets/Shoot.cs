using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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
        if (Input.GetMouseButton(0))
        {
            if (shotCooldown <= 0)
            {
                var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().angle = this.gameObject.GetComponent<Players>().angle;
                shotCooldown = 0.1f;
                bullet.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<Renderer>().material.color;
                bullet.GetComponent<Bullet>().shooter = this.gameObject;
                bullet.tag = "Bullet";
            }
        }
    }
}
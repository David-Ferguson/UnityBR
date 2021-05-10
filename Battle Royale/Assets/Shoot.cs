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
                shotCooldown = 1f / this.GetComponent<Players>().bulletsPerSecond[this.GetComponent<Players>().powers[2]];
                bullet.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<Renderer>().material.color;
                bullet.GetComponent<Bullet>().shooter = this.gameObject;
                bullet.tag = "Bullet";
                bullet.GetComponent<Bullet>().health = this.GetComponent<Players>().bulletHealth[this.GetComponent<Players>().powers[1]];
                bullet.GetComponent<Bullet>().timeToLive = this.GetComponent<Players>().bulletTimeToLive[this.GetComponent<Players>().powers[3]];
            }
        }
    }
}
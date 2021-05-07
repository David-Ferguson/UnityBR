using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public int health = 150;
    public float angle = 0f;
    float circleTickCooldown = 0.1f;
    public int score = 1;
    public float regenCooldown = 1;
    float regenTick = int.MaxValue;
    public int[] powers = new int[] { 0, 0, 0, 0, 0, 0 }; //[Health, Bullet Health, Fire Rate, Bullet Time to Live, Bullet Size, Regen], max: [20, 20, 20, 20, 10, 10]
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<Bullet>().shooter != this.gameObject)
            {
                health = health - 10;
                if (health <= 0)
                {
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().score = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().score + score;
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[0] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[0] + powers[0];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[1] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[1] + powers[1];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[2] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[2] + powers[2];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[3] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[3] + powers[3];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[4] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[4] + powers[4];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[5] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[5] + powers[5];
                    score = 0;
                    powers = new int[] { 0, 0, 0, 0, 0, 0 };
                }
            }
        }


    }
    void Update()
    {
        switch (powers[5]) {
            case 0:
                regenCooldown = int.MaxValue;
                break;
            case 1:
                regenCooldown = 1f;
                break;
            case 2:
                regenCooldown = .5f;
                break;
            case 3:
                regenCooldown = .33f;
                break;
            case 4:
                regenCooldown = .25f;
                break;
            case 5:
                regenCooldown = .2f;
                break;
            case 6:
                regenCooldown = .17f;
                break;
            case 7:
                regenCooldown = .15f;
                break;
            case 8:
                regenCooldown = .13f;
                break;
            case 9:
                regenCooldown = .12f;
                break;
            case 10:
                regenCooldown = .11f; //slightly less regen than 1/regenCooldown per second at high values so 10 dps storm eventually kills all, even with 10 regen
                break;
            default:
                Debug.Log("TOO MUCH REGEN AAAA");
                break;
        };
        if (regenTick <= 0) {
            health += 1;
                regenTick = regenCooldown;
        } else if (regenTick > regenCooldown)
        {
            regenTick = regenCooldown;
        } else 
        {
            regenTick -= Time.deltaTime;
        }
        if (health <= 0)
        {
            transform.position = new Vector3(1000, 0, 0);
            GameObject.Find("Players").GetComponent<Spawner>().playersLeft = GameObject.Find("Players").GetComponent<Spawner>().playersLeft - 1;
            Debug.Log(GameObject.Find("Players").GetComponent<Spawner>().playersLeft + " Left");
            health = 1000;
            score = 0;
        }
        if (Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25 && circleTickCooldown <= 0)
        {
            health = health - 1;
            circleTickCooldown = 0.1f;
        } else if (Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25) {
            circleTickCooldown -= Time.deltaTime;
        } else
        {
            circleTickCooldown = 0.1f;
        }
        if (health > 150 && health < 500)
        {
            health = 150;
        }
        if (health > 500) {
            transform.position = new Vector3(1000, 0, 0);
            health = 1000;
        }

    }
}

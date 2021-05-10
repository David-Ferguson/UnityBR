using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Players : MonoBehaviour
{
    public int health = 100;
    public float angle = 0f;
    public int score = 1;
    public float regenCooldown = 1;
    float regenTick = int.MaxValue;
    public int previousMaxHealth = 70;
    public int[] powers = new int[] { 0, 0, 0, 0, 0 }; //[Health, Bullet Health, Fire Rate, Bullet Time to Live, Regen], max: [20, 20, 20, 20, 10, 10]

    public int[] maxHealth = new int[] { 100, 110, 121, 134, 148, 163, 180, 198, 218, 240, 264, 291, 321, 354, 390, 429, 472, 520, 572, 630, 693 };

    public int[] bulletHealth = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23, 25, 27, 29, 31 };

    public int[] bulletsPerSecond = new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

    public float[] bulletTimeToLive = new float[] { .5f, .6f, .7f, .8f, .9f, 1f, 1.1f, 1.2f, 1.3f, 1.4f, 1,5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f, 2.1f, 2.2f, 2.3f, 2.4f, 2.5f };
    int[] regen = new int[] { 5, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19, 21, 24, 27, 30, 33, 37, 41, 46, 51, 57 }; //see spreadsheet for wtf these numbers are, I promise I put thought into these :)

    float timeInCircle = 0;
    public int kills = 0;

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
                health = health - collision.gameObject.GetComponent<Bullet>().health;
                if (health <= 0)
                {
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().score = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().score + score;
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[0] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[0] + powers[0];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[1] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[1] + powers[1];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[2] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[2] + powers[2];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[3] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[3] + powers[3];
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[4] = collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().powers[4] + powers[4];
                    score = 0;
                    powers = new int[] { 0, 0, 0, 0, 0 };
                    collision.gameObject.GetComponent<Bullet>().shooter.GetComponent<Players>().kills += 1;
                }
            }
        }


    }
    void Update()
    {

        int newMaxHealth = maxHealth[powers[0]];
        health = newMaxHealth / previousMaxHealth * health;

        previousMaxHealth = newMaxHealth;
        regenCooldown = 1f / Convert.ToSingle(regen[powers[4]]);
        if (regenTick <= 0) {
            health += 1;
                regenTick = regenTick + regenCooldown;
        } else if (regenTick > regenCooldown)
        {
            regenTick = regenCooldown;
        }
        regenTick -= Time.deltaTime;

        if (Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25)
        {
            health = health - 1 - (int) Mathf.Floor(timeInCircle);
            timeInCircle += Time.deltaTime;
        }

        if (health > previousMaxHealth && health < 600)
        {
            health = previousMaxHealth;
        }
        if (health > 50000) {
            transform.position = new Vector3(1000, 0, 0);
            health = 700000;
        }
        if (health <= 0)
        {
            transform.position = new Vector3(1000, 0, 0);
            GameObject.Find("Players").GetComponent<Spawner>().playersLeft = GameObject.Find("Players").GetComponent<Spawner>().playersLeft - 1;
            Debug.Log(GameObject.Find("Players").GetComponent<Spawner>().playersLeft + " Left");

            health = 100000;

        }
    }
}

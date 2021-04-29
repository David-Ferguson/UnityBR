using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public int health = 100;
    public float angle = 0f;
    float circleTickCooldown = 0.2f;
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
            }
        }

    }
    void Update()
    {
        if (health <= 0)
        {
            transform.position = new Vector3(1000, 0, 0);
            GameObject.Find("Players").GetComponent<Spawner>().playersLeft = GameObject.Find("Players").GetComponent<Spawner>().playersLeft - 1;
            Debug.Log(GameObject.Find("Players").GetComponent<Spawner>().playersLeft);
            health = 1000;
        }
        if (Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25 && circleTickCooldown <= 0)
        {
            health = health - 1;
            circleTickCooldown = 0.1f;
        } else if (Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25) {
            circleTickCooldown -= Time.deltaTime;
        } else
        {
            circleTickCooldown = 0.2f;
        }
        if (health > 100 && health < 500)
        {
            health = 100;
        }
        if (health > 500) {
            transform.position = new Vector3(1000, 0, 0);
            health = 1000;
        }
    }
}

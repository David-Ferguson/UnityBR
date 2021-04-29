using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    //object parent = transform.parent.gameObject;
    //object doubleParent = transform.parent.parent.gameObject;
    //float angle = parent.angle + doubleParent.rand.NextDouble(10) - 5;
    public float speed = 15f;
    public float angle = 0.0f;
    public float timeToLive = 1.0f;
    public GameObject shooter = null;
    void Start()
    {
        Destroy(gameObject, 1);
        angle = angle + Convert.ToSingle(GameObject.Find("Players").GetComponent<Spawner>().rand.NextDouble()) / 2 - 0.25f;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && transform.position.x < 500)
        {
            if (shooter != collision.gameObject.GetComponent<Bullet>().shooter && transform.position.x < 500)
            {
                Destroy(gameObject);
            }
        } else if (collision.gameObject != shooter && transform.position.x < 500)
        {
            shooter.GetComponent<Players>().health = shooter.GetComponent<Players>().health + 10;
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (Convert.ToSingle(Math.Cos(Convert.ToDouble(angle))) * speed * Time.deltaTime, Convert.ToSingle(Math.Sin(Convert.ToDouble(angle))) * speed * Time.deltaTime, 0.0f);
        timeToLive = timeToLive - Time.deltaTime;
    }
}

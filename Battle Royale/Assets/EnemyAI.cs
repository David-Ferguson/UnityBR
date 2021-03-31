using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0f;
    void Start()
    {
            speed = GameObject.Find("Players").GetComponent<Spawner>().speed;
    }
    private System.Random rand = new System.Random();
    // Update is called once per frame
    private float angle = 0f;
 
    void Update()
    {
        int action = rand.Next(200);
        if (action == 1) {
            angle = Convert.ToSingle(rand.NextDouble()) * 360f;
        }
        transform.position += new Vector3(speed * Convert.ToSingle(Math.Cos(angle)), speed * Convert.ToSingle(Math.Sin(angle)), 0.0f) * Time.deltaTime;
    }
}

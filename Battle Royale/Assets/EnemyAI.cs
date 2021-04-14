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
    private float moveAngle = 0f;

    void Update()
    {
        int action = GameObject.Find("Players").GetComponent<Spawner>().rand.Next(200);
        if (action == 1) {
            moveAngle = Convert.ToSingle(GameObject.Find("Players").GetComponent<Spawner>().rand.NextDouble()) * 360f;
        }
        transform.position += new Vector3(speed * Convert.ToSingle(Math.Cos(moveAngle)), speed * Convert.ToSingle(Math.Sin(moveAngle)), 0.0f) * Time.deltaTime;
    }
}

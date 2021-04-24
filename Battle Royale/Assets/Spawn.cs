using System.Collections;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public float spawnRadius = 150f;
    
    // Start is called before the first frame update
    void Start()
    {
        double distance = GameObject.Find("Players").GetComponent<Spawner>().rand.NextDouble() * spawnRadius * spawnRadius;
        double angle = GameObject.Find("Players").GetComponent<Spawner>().rand.Next(0, 360);
        distance = Math.Sqrt(distance);
        transform.position = new Vector3 (Convert.ToSingle(distance * Math.Cos(angle)), Convert.ToSingle(distance * Math.Sin(angle)), 0.0f);
        gameObject.GetComponent<Renderer>().material.color = new Color(GameObject.Find("Players").GetComponent<Spawner>().rand.Next(30, 255)/255f, GameObject.Find("Players").GetComponent<Spawner>().rand.Next(30, 255)/255f, GameObject.Find("Players").GetComponent<Spawner>().rand.Next(30, 255)/255f, 1.0f);
    }

}

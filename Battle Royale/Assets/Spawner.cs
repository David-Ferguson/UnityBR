using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public System.Random rand = new System.Random();
    public float speed = 3f;
    public Transform[] children = null;
    public int playersLeft = 1000;
    Transform[] GetEnemies() {
        Transform[] enemies = GetComponentsInChildren<Transform>();
        return enemies;
    }

    void Start()
    {
        playersLeft = GetEnemies().Length-1;
        children = GetEnemies();
    }
}

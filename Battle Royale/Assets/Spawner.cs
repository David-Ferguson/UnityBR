using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public System.Random rand = new System.Random();
    public float speed = 3f;
    public Transform[] children = { };
    public int playersLeft = 1000;
    Transform[] GetEnemies() {
        Transform[] enemies = GetComponentsInChildren<Transform>();
        return enemies;
    }

    void Start()
    {
        playersLeft = GetEnemies().Length-303; //303 accounts for grandchildren of Players
        children = GetEnemies();
        int[] bonusDist = new int[] { 0, 2, 22, 42, 62, 82 };
        int[] bonuses = new int[] { 0, 0, 0, 0, 0, 0 };
        int i = 0;
        foreach (Transform child in transform)
        {
            i += 1;
            if (i >= bonusDist[5])
            {
                child.gameObject.GetComponent<Players>().powers[4]++;
                bonuses[4]++;
            }
            else if (i >= bonusDist[4])
            {
                child.gameObject.GetComponent<Players>().powers[3]++;
                bonuses[3]++;
            }
            else if (i >= bonusDist[3])
            {
                child.gameObject.GetComponent<Players>().powers[2]++;
                bonuses[2]++;
            }
            else if (i >= bonusDist[2])
            {
                child.gameObject.GetComponent<Players>().powers[1]++;
                bonuses[1]++;
            }
            else if (i >= bonusDist[1])
            {
                child.gameObject.GetComponent<Players>().powers[0]++;
                bonuses[0]++;
            } else
            {
                Debug.Log("Player: " + children[i].gameObject.name);
            }

        }
        GameObject.Find("Player").GetComponent<Player_Movement>().killExtra();
    }
}

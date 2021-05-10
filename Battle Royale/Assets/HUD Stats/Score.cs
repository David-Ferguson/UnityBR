using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Sprite[] spriteArray = { };
    // Start is called before the first frame update
    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("0-100");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Players>().score != 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteArray[GameObject.Find("Player").GetComponent<Players>().score];
        }
    }
}

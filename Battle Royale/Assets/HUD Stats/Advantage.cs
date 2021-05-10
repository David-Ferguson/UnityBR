using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advantage : MonoBehaviour
{
    public Sprite[] spriteArray = { };
    // Start is called before the first frame update
    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("Advantage");
    }

    // Update is called once per frame
    void Update()
    {
        int advantage = GameObject.Find("Player").GetComponent<Players>().score - this.transform.parent.gameObject.GetComponent<Players>().score;
        if (advantage < -10)
        {
            advantage = -10;
        }
        if (advantage > 10)
        {
            advantage = 10;
        }
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[advantage+10];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot: MonoBehaviour
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
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[GameObject.Find("Player").GetComponent<Players>().kills];    }
}

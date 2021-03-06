using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHealthStat : MonoBehaviour
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
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[GameObject.Find("Player").GetComponent<Players>().powers[1]];
        transform.localScale = new Vector3(GameObject.Find("Player").GetComponent<Players>().powers[1] / 5 + 3, GameObject.Find("Player").GetComponent<Players>().powers[1] / 5 + 3, 1);
    }
}

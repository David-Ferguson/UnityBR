using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3 (this.transform.parent.gameObject.GetComponent<Players>().health * 2f / this.transform.parent.gameObject.GetComponent<Players>().maxHealth[this.transform.parent.gameObject.GetComponent<Players>().powers[0]], .3f, 1);
        transform.localPosition = new Vector2(Convert.ToSingle(this.transform.parent.gameObject.GetComponent<Players>().health * 1.3f / this.transform.parent.gameObject.GetComponent<Players>().maxHealth[this.transform.parent.gameObject.GetComponent<Players>().powers[0]] - 1.3), -2.23f);
    }
}

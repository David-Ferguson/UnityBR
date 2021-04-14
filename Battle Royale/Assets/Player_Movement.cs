using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0f;
    void Start()
    {
        speed = GameObject.Find("Players").GetComponent<Spawner>().speed;
        Vector2 mousePos = Input.mousePosition;
    }

    // Update is called once per frame
 
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        this.gameObject.GetComponent<Players>().angle = Mathf.Acos(mouseDirection.x);
        if (mousePos.y - transform.position.y < 0) {
            this.gameObject.GetComponent<Players>().angle = this.gameObject.GetComponent<Players>().angle + (Mathf.PI - this.gameObject.GetComponent<Players>().angle) * 2;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        float posChangex = transform.position.x - pos.x;
        float posChangey = transform.position.y - pos.y;
        if (Input.GetKey("a") & Input.GetKey("w") & !Input.GetKey("s") & !Input.GetKey("d") ||
            Input.GetKey("d") & Input.GetKey("w") & !Input.GetKey("s") & !Input.GetKey("a") ||
            Input.GetKey("d") & Input.GetKey("s") & !Input.GetKey("w") & !Input.GetKey("a") ||
            Input.GetKey("a") & Input.GetKey("s") & !Input.GetKey("w") & !Input.GetKey("d"))
        {
            posChangex *= 1f/Convert.ToSingle(Math.Sqrt(2));
            posChangey *= 1f/Convert.ToSingle(Math.Sqrt(2));
            pos = transform.position - new Vector3(posChangex, posChangey, 0f);
        }
        transform.position = pos;
    }
}

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
    public bool killExtra()
    {
        int bonus = GameObject.Find("Players").GetComponent<Spawner>().rand.Next(0, 10);
        if (bonus == 0 || bonus == 1)
        {
            bonus = 0;
        }
        else if (bonus == 2 || bonus == 3)
        {
            bonus = 1;
        }
        else if (bonus == 4 || bonus == 5)
        {
            bonus = 2;
        }
        else if (bonus == 6 || bonus == 7)
        {
            bonus = 3;
        }
        else if (bonus == 8)
        {
            bonus = 4;
        }
        else if (bonus == 9)
        {
            bonus = 5;
        }
        this.gameObject.GetComponent<Players>().powers[bonus] = this.gameObject.GetComponent<Players>().powers[bonus] + 1;
        Debug.Log("Bonus");
        if (this.gameObject.GetComponent<Players>().powers[0] == 1)
        {
            GameObject.Find("Enemy (20)").GetComponent<Players>().health = 0;
            Debug.Log("1asdf");
        }
        else if (this.gameObject.GetComponent<Players>().powers[1] == 1)
        {
            GameObject.Find("Enemy (40)").GetComponent<Players>().health = 0;
            Debug.Log("2asdf");
        }
        else if (this.gameObject.GetComponent<Players>().powers[2] == 1)
        {
            GameObject.Find("Enemy (60)").GetComponent<Players>().health = 0;
            Debug.Log("3asdf");
        }
        else if (this.gameObject.GetComponent<Players>().powers[3] == 1)
        {
            GameObject.Find("Enemy (80)").GetComponent<Players>().health = 0;
            Debug.Log("4asdf");
        }
        else if (this.gameObject.GetComponent<Players>().powers[4] == 1)
        {
            GameObject.Find("Enemy (90)").GetComponent<Players>().health = 0;
            Debug.Log("5asdf");
        }
        else if (this.gameObject.GetComponent<Players>().powers[5] == 1)
        {
            GameObject.Find("Enemy (100)").GetComponent<Players>().health = 0;
            Debug.Log("6asdf");
        }
        return true;
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
            posChangex *= 1f / Convert.ToSingle(Math.Sqrt(2));
            posChangey *= 1f / Convert.ToSingle(Math.Sqrt(2));
            pos = transform.position - new Vector3(posChangex, posChangey, 0f);
        }
        transform.position = pos;
        /*Debug.Log(this.gameObject.GetComponent<Players>().powers[0]);
        Debug.Log(this.gameObject.GetComponent<Players>().powers[1]); 
        Debug.Log(this.gameObject.GetComponent<Players>().powers[2]);
        Debug.Log(this.gameObject.GetComponent<Players>().powers[3]); 
        Debug.Log(this.gameObject.GetComponent<Players>().powers[4]);
        Debug.Log(this.gameObject.GetComponent<Players>().powers[5]);*/
        Debug.Log(this.gameObject.GetComponent<Players>().health);
        Debug.Log(this.gameObject.GetComponent<Players>().powers[5]);
        Debug.Log(this.gameObject.GetComponent<Players>().regenCooldown);
    }
}

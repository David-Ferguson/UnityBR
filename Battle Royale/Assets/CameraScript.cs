using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (GameObject.Find("Player").transform.position - transform.position) * 5f * Time.deltaTime + new Vector3(0.0f, 0.0f, -1.0f);
    }
}

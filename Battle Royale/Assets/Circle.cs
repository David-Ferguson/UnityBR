using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float oneSecondChange = transform.localScale.x * .99f;
        float deltaScale = (transform.localScale.x - oneSecondChange) * Time.deltaTime + 0.005f * Time.deltaTime;
        transform.localScale = new Vector3 (transform.localScale.x - deltaScale, transform.localScale.y - deltaScale, transform.localScale.z);
        
    }
}

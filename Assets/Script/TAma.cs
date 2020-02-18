using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAma : MonoBehaviour
{
    float speed = 3;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = gameObject.transform.forward * speed * -1;
        gameObject.transform.position += velocity * Time.deltaTime;
        time += Time.deltaTime;
        if (time > 3)
        {
            Destroy(gameObject);
        }
    }
}

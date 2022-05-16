using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
    float move;
    float move2;
    float value;
    float value2;
    // [SerializeField]
    // GameObject centerCamera;

    void Start()
    {
        value = Random.Range(-7.0f, -33.0f);
        value2 = Random.Range(-19.0f, 7.0f);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        // pos.x = Mathf.Clamp(pos.x, -19f, 9f);
        // pos.z = Mathf.Clamp(pos.x, -8f, 33f);
        Rigidbody rb = this.GetComponent<Rigidbody> ();

        if(pos.z > value - 0.04f && pos.z < value + 0.04f)
        {
            value = Random.Range(-7.0f, -33.0f);
            Debug.Log(value);
        }
        if(pos.z < value)
        {
            move = 0.02f;
        }
        if(pos.z > value)
        {
            move = -0.02f;
        }
        pos.z += move;


        if(pos.x > value2 - 0.04f && pos.x < value2 + 0.04f)
        {
            value2 = Random.Range(-19.0f, 7.0f);
            Debug.Log(value2);
        }
        if(pos.x < value2)
        {
            move2 = 0.02f;
        }
        if(pos.x > value2)
        {
            move2 = -0.02f;
        }
        pos.x += move2;
        transform.position = pos;

    }
   

}



 


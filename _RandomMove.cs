using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RandomMove : MonoBehaviour
{
    float move;
    float value;
    float value2;
    float value3;
    float value4;
    // [SerializeField]
    // GameObject centerCamera;

    public int index;
    [SerializeField]
    GameObject OriginObj;
    float Angle = 10.0f;
    GameObject RandomRange;
    RandomRange RandomRan;
    GameObject Target;
    Vector3 Rot;

    void Start()
    {
        value = Random.Range(-18.0f, 9.0f);
        value2 = Random.Range(2.0f, 10.0f);
        value3 = Random.Range(-10.0f, 5.0f);
        value4 = Random.Range(-25.0f, -7.0f);
        index = Random.Range(1, 4);
        RandomRange = GameObject.Find("RandomRange");
        RandomRan = RandomRange.GetComponent<RandomRange>();
        Target = GameObject.Find("Target");
    }

    void Update()
    {
        if(index == 1)
        {
            RoundTripMove();
        }
        else if(index == 2)
        {
            UpDownMove();
        }
        else if(index == 3)
        {
            rightlowerRoundTrip();
        }
        // else if(index == 3)
        // {
        //     Revolution();
        // }
        Rot = Target.transform.localEulerAngles;
    }

    void RoundTripMove()
    {
        Vector3 pos = transform.position;
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if(Rot.y == 180.0f){
            if(pos.x > value - 0.020f && pos.x < value + 0.020f)
            {
                value = Random.Range(-18.0f, 9.0f);
            }
            if(pos.x < value)
            {
                move = 0.015f;
            }
            if(pos.x > value)
            {
                move = -0.015f;
            }

            pos.x += move;
            transform.position = pos;
        }

        if(Rot.y == 90.0f || Rot.y == 270.0f)
        {
            if(pos.z > value - 0.020f && pos.z < value + 0.020f)
            {
                value = Random.Range(-18.0f, 9.0f);
            }
            if(pos.z < value)
            {
                move = 0.015f;
            }
            if(pos.z > value)
            {
                move = -0.015f;
            }

            pos.z += move;
            transform.position = pos;
        }

    }

    void UpDownMove()
    {
        Vector3 pos = transform.position;
        Rigidbody rb = this.GetComponent<Rigidbody> ();

        if(pos.y > value2 - 0.020f && pos.y < value2 + 0.020f)
        {
            value2 = Random.Range(2.0f, 10.0f);
        }
        if(pos.y < value2)
        {
            move = 0.015f;
        }
        if(pos.y > value2)
        {
            move = -0.015f;
        }

        pos.y += move;
        transform.position = pos;
    }

    void rightlowerRoundTrip()
    {
        Vector3 pos = transform.position;
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if(Rot.y == 180.0f){
            if(pos.x > value3 - 0.020f && pos.x < value3 + 0.020f)
            {
                value3 = Random.Range(-10.0f, 5.0f);
            }
            if(pos.x < value3)
            {
                move = 0.010f;
            }
            if(pos.x > value3)
            {
                move = -0.010f;
            }
            pos.x += move;
            transform.position = pos;

            if(pos.y > value2 - 0.020f && pos.y < value2 + 0.020f)
            {
                value2 = Random.Range(2.0f, 10.0f);
            }
            if(pos.y < value2)
            {
                move = 0.010f;
            }
            if(pos.y > value2)
            {
                move = -0.010f;
            }

            pos.y += move;
            transform.position = pos;
        }

        if(Rot.y == 90.0f || Rot.y == 270.0f)
        {
            if(pos.z > value4 - 0.020f && pos.z < value4 + 0.020f)
            {
                value4 = Random.Range(-25.0f, -7.0f);
            }
            if(pos.z < value4)
            {
                move = 0.010f;
            }
            if(pos.z > value4)
            {
                move = -0.010f;
            }

            pos.z += move;
            transform.position = pos;

            if(pos.y > value2 - 0.020f && pos.y < value2 + 0.020f)
            {
                value2 = Random.Range(2.0f, 10.0f);
            }
            if(pos.y < value2)
            {
                move = 0.010f;
            }
            if(pos.y > value2)
            {
                move = -0.010f;
            }

            pos.y += move;
            transform.position = pos;
        }

    }

    void Revolution()
    {
        Vector3 orbitOrigin = OriginObj.transform.position;
        
        transform.RotateAround(orbitOrigin, -Vector3.up, Angle*Time.deltaTime);

        // 公転原点オブジェクトの方を向く
        transform.LookAt(OriginObj.transform);
    }

    

    void FixedUpdate()
    {
    
    }
}

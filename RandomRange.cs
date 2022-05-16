using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomRange : MonoBehaviour
{
    [SerializeField]
    private Transform rangeA;
    [SerializeField]
    private Transform rangeB;

    public GameObject Target;

    public Vector3 new_pos;
    

    // Start is called before the first frame update
    void Start()
    {
        // ray = GameObject.Find("ray");
        // Ray = ray.GetComponent<ray>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomRan()
    {
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        float z = Random.Range(rangeA.position.z, rangeB.position.z);
        
        // GameObjectを上記で決まったランダムな場所に生成
        // Instantiate(target, new Vector3(x,y,z), target.transform.rotation);
        new_pos = new Vector3(x,y,z);
        Target.transform.position = new_pos;

        if(new_pos.x >= 7.0f && new_pos.z <= -10.0f)
        {
            Target.transform.rotation = Quaternion.Euler(0, 270.0f, 0);
        }
        else if(new_pos.x < 7.0f && new_pos.x > -7.0f)
        {
            Target.transform.rotation = Quaternion.Euler(0, 180.0f, 0);
            if(new_pos.z <= -22.0f)
            {
                Target.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if(new_pos.x <= -18.0f && new_pos.z <= -10.0f)
        {
            Target.transform.rotation = Quaternion.Euler(0, 90.0f, 0);
        }
    }
    
}

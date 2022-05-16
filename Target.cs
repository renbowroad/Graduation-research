using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;    
using System.IO; 

public class Target : MonoBehaviour
{

    public GameObject HPUI;
    public GameObject HPBar;
    private Slider hpSlider;
    public Vector3 center_pos;

    public float HP_value;
    // Start is called before the first frame update
    void Start()
    {
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1.0f;
        center_pos = GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        center_pos = GetComponent<Renderer>().bounds.center;
        // CenterPos();
    }

    public float SetHP()
    {
        hpSlider.value = Mathf.Lerp(hpSlider.value, 0.0f, Time.deltaTime);
        HP_value = hpSlider.value;
        return HP_value;
    }

    public void RecoveryHP()
    {
        hpSlider.value = 1.0f;
    }

    // public Vector3 CenterPos()
    // {
    //     center_pos = GetComponent<Renderer>().bounds.center;
    //     return center_pos;
    // }
}

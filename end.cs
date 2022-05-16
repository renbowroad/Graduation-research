using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{

    GameObject obj;
    CountDown var;
    string time;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("GameObject");
        var = obj.GetComponent<CountDown>();
        time = var.timerText.text;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(time);
        if(time == "時間")
        {
            SceneManager.LoadScene("end");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float time = 120.0f;
    public Text timerText;
    public bool isTimeUp;
 
    void Start()
    {
        isTimeUp = false;
    }
 
    void Update()
    {
        if (0 < time) {
            time -= Time.deltaTime;
            timerText.text = time.ToString("F1");
        }
         else if (time < 0){
            SceneManager.LoadScene("End");
            isTimeUp = true;

        }
    }
}
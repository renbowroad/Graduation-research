using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンマネジメントを有効にする
using UnityEngine.UI;

public class Title : MonoBehaviour {

    [SerializeField]
	private Text _textCountdown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
           StartCoroutine(CountdownCoroutine());
        }
    }
    IEnumerator CountdownCoroutine()
	{
 	    _textCountdown.gameObject.SetActive(true);
         
		_textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);
 
        SceneManager.LoadScene("Shoot");
		_textCountdown.text = "";
		_textCountdown.gameObject.SetActive(false);
	}
}
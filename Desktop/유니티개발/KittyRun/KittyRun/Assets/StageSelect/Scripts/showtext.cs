using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showtext : MonoBehaviour {
    public Text starttext;
	// Use this for initialization
	void Start () {
        StartCoroutine(ShowTexts());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator ShowTexts()
    {
        print(Time.time);
        yield return new WaitForSeconds(6);
        starttext.text = "화면을 눌러주면 시작한다 냥!";
        print(Time.time);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Cinemachine.Utility;
using Cinemachine.Blackboard;
using Cinemachine.Timeline;

public class cameramove : MonoBehaviour {
    public CinemachineFreeLook freelook;

	// Use this for initialization
	void Start () {
        freelook.Priority = 13;
        StartCoroutine(Setpr());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Setpr()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        freelook.Priority = 1;
        print(Time.time);
    }
}

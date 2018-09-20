using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camera2move : MonoBehaviour {
    public CinemachineFreeLook freelook;

    // Use this for initialization
    void Start()
    {
        freelook.Priority = 12;
        StartCoroutine(Setpr());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Setpr()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        freelook.Priority = 1;
        print(Time.time);
    }
}

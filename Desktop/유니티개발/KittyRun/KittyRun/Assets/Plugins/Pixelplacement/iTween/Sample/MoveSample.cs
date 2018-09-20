using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
    public float to = 2.5f;
    public string a = "x";
    public int timedl = 2;
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash(a, to, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", timedl));
	}
}


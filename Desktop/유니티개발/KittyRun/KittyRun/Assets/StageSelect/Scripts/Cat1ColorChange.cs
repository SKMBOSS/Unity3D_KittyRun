using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat1ColorChange : MonoBehaviour {

    public gamemanger slot;
    public Renderer rend;
    public Material[] materials;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        slot = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        rend.sharedMaterial = materials[slot.firstcat[1]];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

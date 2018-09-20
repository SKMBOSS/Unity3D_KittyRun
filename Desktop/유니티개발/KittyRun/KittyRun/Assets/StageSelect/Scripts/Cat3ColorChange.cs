using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat3ColorChange : MonoBehaviour {
    
    public gamemanger slot;
    public Renderer rend;
    public Material[] materials;
    
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        slot = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        rend.sharedMaterial = materials[slot.firstcat[3]];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

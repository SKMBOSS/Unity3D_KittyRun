using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gamemanger : MonoBehaviour {

    public int[] availables = { 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1 ,1};
   
    public int selectedSlots = 2;
    public int[] firstcat = { 2, 3, 4, 7 };
   
    
        // Use this for initialization
        
	void Start () {
        
        

       availables[firstcat[0]] = 0;
        availables[firstcat[1]] = 0;
        availables[firstcat[2]] = 0;
        availables[firstcat[3]] = 0;
    } 
	
	// Update is called once per frame
	void Update () {
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);

    }
}

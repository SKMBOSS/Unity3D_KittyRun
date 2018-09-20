using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot1Change : gamemanger {
    public GameObject[] C;
    public GameObject BG;
	// Use this for initialization
	void Start () {
       

	}
	public void B1act()
    {
        BG.SetActive(true);
        for (int i = 0; i < 11; i++)
        {
            if (availables[i] == 1)
            {
                C[i].SetActive(true);

            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}

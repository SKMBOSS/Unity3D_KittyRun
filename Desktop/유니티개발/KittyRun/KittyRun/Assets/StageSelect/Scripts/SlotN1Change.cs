using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotN1Change : gamemanger {
    public GameObject[] C;
    public GameObject BG;
    public gamemanger sets;
	// Use this for initialization
	void Start () {
       

	}
	public void B1act()
    {
        sets = GameObject.Find("gamemanger").GetComponent<gamemanger>(); 
        BG.SetActive(true);
        for (int i = 0; i < 12; i++)
        {
            if (sets.availables[i] == 1)
            {
                C[i].SetActive(true);

            }
        }
    }
    public void SelectedSlot1()
    {
        sets = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        sets.selectedSlots = 1;
    }
    public void SelectedSlot2()
    {
        sets = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        sets.selectedSlots = 2;
    }
    public void SelectedSlot3()
    {
        sets = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        sets.selectedSlots = 3;
    }
    public void SelectedSlot4()
    {
        sets = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        sets.selectedSlots = 4;
    }
    // Update is called once per frame
    void Update () {
		
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterchange4 : MonoBehaviour { 

    public Material[] materials;
    public Renderer rend;
    public GameObject popup;
    public GameObject[] buttons;
    public gamemanger slot;
    void Start()
    {
        
    }
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        slot = GameObject.Find("gamemanger").GetComponent<gamemanger>();
        rend.sharedMaterial = materials[slot.firstcat[3]];
    }
    void Update()
    {
        
    }

    public void changecolor(int a)
    {
        if (slot.selectedSlots== 4) {

            slot = GameObject.Find("gamemanger").GetComponent<gamemanger>();
            slot.availables[slot.firstcat[3]] = 1;
            slot.firstcat[3] = a;
            rend.sharedMaterial = materials[a];
            slot.availables[a] = 0;
            for (int i = 0; i < 12; i++)
              buttons[i].SetActive(false);
              popup.SetActive(false);
         }
    }

}

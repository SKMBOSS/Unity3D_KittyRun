using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Move : MonoBehaviour {

    public float moveSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        MoveObj();
    }

    void MoveObj()
    {
        float moveAmount = Time.smoothDeltaTime * moveSpeed;
        transform.Rotate(0f, moveAmount, 0f );
    }
}

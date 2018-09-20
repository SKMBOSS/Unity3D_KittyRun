using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    public float jumpForce = 1000f;         // Amount of force added when the player jumps.
    public bool grounded = false;
    private bool jump;
    public bool isClick = false;
    public Rigidbody rb;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckGround(); // 밑이 땅인지 확인

        if (isClick && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {

        if (jump)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f));
            jump = false;
            isClick = false;
        }
    }

    void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            if (hit.transform.tag == "GROUND")
            {
                grounded = true;
                return;
            }
        }
        grounded = false;
    }

}

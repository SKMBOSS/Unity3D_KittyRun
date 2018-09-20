using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner_C_Jump : MonoBehaviour
{

    public float jumpForce = 1000f;         // Amount of force added when the player jumps.
    public Rigidbody rb;
    public Material[] Faces = new Material[7];
    public AudioClip[] sounds = new AudioClip[3];

    public bool islive = true;

    private bool grounded = false;
    private bool jump;
    private bool damage;

    Animator animator;
    AudioSource audioSource;
    GameObject child;

    private GameObject target;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!islive)
        {
            StartCoroutine(GameOver(0.0f));
        }

        CheckGround(); // 밑이 땅인지 확인

        if (Input.GetKeyDown("l") && grounded && islive)
        {
            jump = true;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && grounded && islive)
            {
                target = GetClickedObject(i);

                if (target.Equals(gameObject))
                {
                    jump = true;
                }

            }
        }

    }

    void FixedUpdate()
    {

        if (jump)
        {
            animator.SetBool("isJUMP", true);
            this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[1];
            rb.AddForce(new Vector3(0f, jumpForce, 0f));
            audioSource.clip = sounds[0];
            audioSource.Play();
            jump = false;
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
                animator.SetBool("isJUMP", false);

                if (!damage && islive)
                    this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[2];
                return;
            }
        }
        grounded = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(MeshOnOff(0.3f));
        animator.SetBool("isDamged", true);

        audioSource.clip = sounds[1];
        audioSource.Play();

        GameManager.Instance().DisHearts();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TRAP")
            SceneManager.LoadScene(0);
    }

    IEnumerator MeshOnOff(float waittime)
    {
        damage = true;

        //this.gameObject.transform.Find("Mesh").gameObject.SetActive(false);
        this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[0];
        iTween.ColorTo(this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Cat").gameObject, new Color(0, 0, 0, 0.5f), 0.3f);
        yield return new WaitForSeconds(0.3f);

        iTween.ColorTo(this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Cat").gameObject, new Color(1, 1, 1, 0.5f), 0.3f);
        //this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[1];
        yield return new WaitForSeconds(0.3f);

        iTween.ColorTo(this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Cat").gameObject, new Color(0, 0, 0, 0.5f), 0.3f);
        yield return new WaitForSeconds(0.3f);

        iTween.ColorTo(this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Cat").gameObject, new Color(1, 1, 1, 1.0f), 0.3f);
        animator.SetBool("isDamged", false);
        this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[2];
        damage = false;

    }

    IEnumerator GameOver(float waittime)
    {
        this.gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Faces[3];
        animator.SetBool("isGameOver", true);
        yield return new WaitForSeconds(1.1f);
        animator.speed = 0.0f;
    }

    private GameObject GetClickedObject(int i)
    {
        RaycastHit hit;
        GameObject target = null;


        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position); //마우스 포인트 근처 좌표를 만든다. 


        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }

        return target;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

//게임 매니저 (싱글톤)
public class GameManager : MonoBehaviour
{

    public bool ready = true; //레디 상태 중인지 체크한다.
    public GameObject Runner_A;
    public GameObject Runner_B;
    public GameObject Runner_C;
    public GameObject Runner_D;
    public GameObject MainCamera;
    public GameObject Goal;
    public GameObject PauseBotton;
    public GameObject HeartsBox;
    public GameObject[] Hearts = new GameObject[3];
    public Sprite[] Hearts_status = new Sprite[3];


    private int timer = 0;
    private int heartsCount = 3;
    private bool isClear = false;

    public Text CountDown;
    public Text Distance;
    public GameObject Distance_obj;
    public GameObject GameOverWindow;
    public GameObject FinishWindow;
    public GameObject GoalMessage;
    public RuntimeAnimatorController WinController;
    public int text;


    //싱글톤으로 만든다
    static GameManager instance;

    public static GameManager Instance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {
        instance = this; //싱글톤완료
        StartPause();
        StartCoroutine(ChangeCountDown(0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountDown.IsActive() && ready == true)
        {
            StartPause_End();
            ready = false;
        }

        if(!isClear)
        CheckDistance();

    }

    public void StartPause()
    {
        Runner_A.GetComponent<Runner_Move>().enabled = false;
        Runner_B.GetComponent<Runner_Move>().enabled = false;
        Runner_C.GetComponent<Runner_Move>().enabled = false;
        Runner_D.GetComponent<Runner_Move>().enabled = false;
        MainCamera.GetComponent<CameraMove>().enabled = false;
    }


    public void StartPause_End()
    {
        Runner_A.GetComponent<Runner_Move>().enabled = true;
        Runner_B.GetComponent<Runner_Move>().enabled = true;
        Runner_C.GetComponent<Runner_Move>().enabled = true;
        Runner_D.GetComponent<Runner_Move>().enabled = true;
        MainCamera.GetComponent<CameraMove>().enabled = true;
        PauseBotton.SetActive(true);
        Distance_obj.SetActive(true);
        HeartsBox.SetActive(true);

    }


    IEnumerator ChangeCountDown(float waittime)
    {
        CountDown.text = "5";
        yield return new WaitForSeconds(0.65f);
        CountDown.text = "4";
        yield return new WaitForSeconds(0.65f);
        CountDown.text = "3";
        yield return new WaitForSeconds(0.65f);
        CountDown.text = "2";
        yield return new WaitForSeconds(0.65f);
        CountDown.text = "1";
        yield return new WaitForSeconds(0.65f);
        CountDown.fontSize = 120;
        CountDown.text = "Go!";
    
    }


    private void CheckDistance()
    {
        int result = (int)Vector3.Distance(Goal.transform.position, MainCamera.transform.position);
        Distance.text = result.ToString() + "M";

        if (result == 0)
        {
            StartCoroutine(FinishOver(0.0f));
        }
    }

    public void DisHearts()
    {
        if (heartsCount > 0)
        {
            StartCoroutine(HeartOnOff(0.3f, heartsCount));
            if (heartsCount-- == 1) StartCoroutine(GameOver(0.0f));
        }
    }

    IEnumerator HeartOnOff(float waittime, int heart_num)
    {

        Hearts[heart_num - 1].GetComponent<Image>().sprite = Hearts_status[1];
        yield return new WaitForSeconds(0.3f);
        Hearts[heart_num - 1].GetComponent<Image>().sprite = Hearts_status[2];
        yield return new WaitForSeconds(0.3f);
        Hearts[heart_num - 1].GetComponent<Image>().sprite = Hearts_status[1];
        yield return new WaitForSeconds(0.3f);
        Hearts[heart_num - 1].SetActive(false);
    }

    IEnumerator GameOver(float waittime)
    {
        PauseBotton.SetActive(false);

        Runner_A.GetComponent<Runner_A_Jump>().islive = false;
        Runner_B.GetComponent<Runner_B_Jump>().islive = false;
        Runner_C.GetComponent<Runner_C_Jump>().islive = false;
        Runner_D.GetComponent<Runner_D_Jump>().islive = false;

        Runner_A.GetComponent<Runner_Move>().enabled = false;
        Runner_B.GetComponent<Runner_Move>().enabled = false;       
        Runner_C.GetComponent<Runner_Move>().enabled = false;      
        Runner_D.GetComponent<Runner_Move>().enabled = false;
        
        MainCamera.GetComponent<CameraMove>().enabled = false;
        MainCamera.GetComponent<EnvironmentSound>().enabled = true;
        yield return new WaitForSeconds(1.0f);

        Runner_A.GetComponent<Runner_A_Jump>().enabled = false;
        Runner_B.GetComponent<Runner_B_Jump>().enabled = false;
        Runner_C.GetComponent<Runner_C_Jump>().enabled = false;
        Runner_D.GetComponent<Runner_D_Jump>().enabled = false;

        GameOverWindow.SetActive(true);

    }

    IEnumerator FinishOver(float waittime)
    {
        isClear = true;
        MainCamera.GetComponent<GameClearSound>().enabled = true;
        Goal.gameObject.transform.Find("Finish").gameObject.GetComponent<GoalSound>().enabled = true;
        GoalMessage.SetActive(true);
        //Goal.SetActive(false);
        PauseBotton.SetActive(false);
        HeartsBox.SetActive(false);
        Distance.text = "";

        Runner_A.GetComponent<Runner_A_Jump>().enabled = false;
        Runner_A.GetComponent<Runner_A_Jump>().gameObject.GetComponent<Animator>().runtimeAnimatorController = WinController;
        Runner_A.GetComponent<Runner_A_Jump>().gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Runner_A.GetComponent<Runner_A_Jump>().Faces[1];

        Runner_B.GetComponent<Runner_B_Jump>().enabled = false;
        Runner_B.GetComponent<Runner_B_Jump>().gameObject.GetComponent<Animator>().runtimeAnimatorController = WinController;
        Runner_B.GetComponent<Runner_B_Jump>().gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Runner_B.GetComponent<Runner_B_Jump>().Faces[1];

        Runner_C.GetComponent<Runner_C_Jump>().enabled = false;
        Runner_C.GetComponent<Runner_C_Jump>().gameObject.GetComponent<Animator>().runtimeAnimatorController = WinController;
        Runner_C.GetComponent<Runner_C_Jump>().gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Runner_C.GetComponent<Runner_C_Jump>().Faces[1];

        Runner_D.GetComponent<Runner_D_Jump>().enabled = false;
        Runner_D.GetComponent<Runner_D_Jump>().gameObject.GetComponent<Animator>().runtimeAnimatorController = WinController;
        Runner_D.GetComponent<Runner_D_Jump>().gameObject.transform.Find("Mesh").gameObject.transform.Find("Face01").gameObject.GetComponent<SkinnedMeshRenderer>().material = Runner_D.GetComponent<Runner_D_Jump>().Faces[1];

        yield return new WaitForSeconds(3.0f);

        GoalMessage.SetActive(false);
        FinishWindow.SetActive(true);
        Runner_A.GetComponent<Runner_Move>().enabled = false;
        Runner_B.GetComponent<Runner_Move>().enabled = false;
        Runner_C.GetComponent<Runner_Move>().enabled = false;
        Runner_D.GetComponent<Runner_Move>().enabled = false;
        MainCamera.GetComponent<CameraMove>().enabled = false;

    }
}

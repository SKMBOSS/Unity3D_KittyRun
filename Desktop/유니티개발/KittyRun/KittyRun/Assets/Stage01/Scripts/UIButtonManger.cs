using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonManger : MonoBehaviour
{
    public GameObject pauseWindow;
    public GameObject pauseBotton;
    public GameObject goToMenuWindow;
 
    public GameObject Runner_A;
    public GameObject Runner_B;
    public GameObject Runner_C;
    public GameObject Runner_D;
    public GameObject MainCamera;


    public void ClickPauseButton()
    {

        Runner_A.SetActive(false);
        Runner_B.SetActive(false);
        Runner_C.SetActive(false);
        Runner_D.SetActive(false);

        MainCamera.GetComponent<CameraMove>().enabled = false;

        pauseBotton.SetActive(false);
        pauseWindow.SetActive(true);
       
    }

    public void ClickPausePlayButton()
    {
        Runner_A.SetActive(true);
        Runner_B.SetActive(true);
        Runner_C.SetActive(true);
        Runner_D.SetActive(true);

        MainCamera.GetComponent<CameraMove>().enabled = true;

        pauseWindow.SetActive(false);
        pauseBotton.SetActive(true);
    }

    public void ClickGoToMenu()
    {
        pauseWindow.SetActive(false);
        goToMenuWindow.SetActive(true);
    }

    public void ClickCancle()
    {
        goToMenuWindow.SetActive(false);
        pauseWindow.SetActive(true);
    }

    public void ClickReStart()
    {
        SceneManager.LoadScene("Stage01/Stage01");
    }

    public void ClickReStart_Stage2()
    {
        SceneManager.LoadScene("Stage01/Stage02");
    }

    public void SceenChangeMenu()
    {
        SceneManager.LoadScene("StageSelect/StageSelect");
    }

    public void GotoStage2()
    {
        SceneManager.LoadScene("Stage01/Stage02");
    }

}

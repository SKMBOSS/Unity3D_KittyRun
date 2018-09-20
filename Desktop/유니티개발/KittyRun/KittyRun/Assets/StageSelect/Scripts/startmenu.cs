using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour {

	public void SceenChangeMenu()
    {
        SceneManager.LoadScene("StageSelect/StageSelect");
    }
    public void ScennChangeSelect()
    {
        SceneManager.LoadScene("StageSelect/selectcharacter");
    }
    public void SceneChangeStage1()
    {
        SceneManager.LoadScene("Stage01/Stage01");
    }

    /////////////////////////

    public void SceneChangeStage2()
    {
        SceneManager.LoadScene("Stage01/Stage02");
    }
}

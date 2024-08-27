using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("BabyRoom");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void BabyRoom()
    {
        SceneManager.LoadScene("BabyRoom");
    }
    public void LivingRoom()
    {
        SceneManager.LoadScene("LivingRoom");
    }
    public void ParentsRoom()
    {
        SceneManager.LoadScene("ParentsRoom");
    }
    public void CastleBoss()
    {
        SceneManager.LoadScene("CastleBoss");
    }
    public void WashingMachineBoss()
    {
        SceneManager.LoadScene("WashingMachineBoss");
    }
    public void DrawerBoss()
    {
        SceneManager.LoadScene("DrawerBoss");
    }

}

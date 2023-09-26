using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void MainSceneButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartSceneButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
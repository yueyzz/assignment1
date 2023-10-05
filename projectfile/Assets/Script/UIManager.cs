using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
/// <summary>
/// create a Singleton Script
/// </summary>
    private void Awake()
    {
        Instance = this;
    }

   
    public Text Cointxt;
    public int coinNum;

    private void Start()
    {
        coinNum = 0;
    }

    private void Update()
    {
        Cointxt.text = "Coin:"+coinNum.ToString();
    }

    public void ReatartScene()
    {
        //Get the current scene serial number
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Reload current scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}

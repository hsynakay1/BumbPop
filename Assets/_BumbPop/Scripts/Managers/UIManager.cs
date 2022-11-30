using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas endCanvas;
    public Canvas loseCanvas;
    public Canvas rewardCanvas;

    private void Start()
    {
        EventManager.Instance.levelStart += GameStart;
        EventManager.Instance.levelEnd += GameEnded;
        EventManager.Instance.playerReward += GameReward;
        EventManager.Instance.levelLose += GameLose;
    }
    public void Click_Play()
    {
        EventManager.Instance.LevelStart(); 
        DisableAllCanvases();
    }
    public void Click_Reward()
    {
        EventManager.Instance.PlayerReward();
    }
    public void GameStart(bool firstTouch = true)
    {
        DisableAllCanvases();
        startCanvas.enabled = firstTouch;
    }
    public void GameEnded(int a,int b)
    {
        DisableAllCanvases();
        endCanvas.enabled = true;
    }
    public void GameLose()
    {
        DisableAllCanvases();
        loseCanvas.enabled = true;
    }
    public void GameReward()
    {
        DisableAllCanvases();
        rewardCanvas.enabled = true;
    }
    private void DisableAllCanvases()
    {
        endCanvas.enabled = false;
        loseCanvas.enabled = false;
        rewardCanvas.enabled = false;
    } 
}

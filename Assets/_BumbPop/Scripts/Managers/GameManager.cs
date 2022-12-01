using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Aim,
    Action,
    UI
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void AimState()
    {
        
    }

    public void ActionStade()
    {
        
    }

    public void UIStade()
    {
        
    }
}

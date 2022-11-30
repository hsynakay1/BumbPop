using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
   public static EventManager Instance;
   
   public delegate void GameAction();

   public delegate void GameActionInt(int number1, int number2);

   public delegate void GameActionBool(bool bool1);

   public event GameActionBool levelStart;
   public event GameAction levelLose;
   public event GameAction playerReward;
   public event GameActionInt levelEnd;
   
   private void Awake()
   {
      Instance = this;
   }

   public void LevelStart()
   {
      if (levelStart == null)
         return;
      levelStart.Invoke(true);
      
   }
   public void LevelLoss()
   {
      if (levelLose == null)
         return;
      levelLose.Invoke();
   }
   public void LevelEnd(int score,int gold)
   {
      if (levelEnd == null)
         return;
      levelEnd.Invoke(score,gold);
   }
   public void PlayerReward()
   {
      if (playerReward == null)
         return;
      playerReward.Invoke();
   }
}

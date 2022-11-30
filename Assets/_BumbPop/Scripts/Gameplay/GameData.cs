using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int BestScore
    {
        get { return PlayerPrefs.GetInt("BestScore", 0); }
        set { PlayerPrefs.SetInt("BestScore", value); }
    }
    public static int PlayerLevel
    {
        get { return PlayerPrefs.GetInt("PlayerLevel", 1); }
        set { PlayerPrefs.SetInt("PlayerLevel", value); }
    }
    public static int Score
    {
        get { return PlayerPrefs.GetInt("Save_Score", 0); }
        set { PlayerPrefs.SetInt("Save_Score", value); }
    }
    public static int Coin
    {
        get { return PlayerPrefs.GetInt("GOLD_SAVE_STRING", 0); }
        set
        {
            PlayerPrefs.SetInt("GOLD_SAVE_STRING", value);
            PlayerPrefs.Save();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameConfig
{
    private int previousScene;
    public int PreviousScene { get => previousScene; set => previousScene = value; }
    private static GameConfig instance;

    private GameConfig() 
    { 
        previousScene = 0;
    }

    public static GameConfig Instance() 
    {
        return instance ??= new GameConfig();
    }

}

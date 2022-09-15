using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd = false;

 
    void Update()
    {
       if(gameEnd)
        {
            return;
        }
       if(PlayerStats.lives <= 0)
        {
            EndGame();
        } 
    }

    void EndGame()
    {
        gameEnd = true;
        Debug.Log("Game Over!");
    }
}

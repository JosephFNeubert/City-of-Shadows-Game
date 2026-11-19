using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Game State Functions
    private static int gameState;
    
    private void Start()
    {
        gameState = 0;
    }

    internal static void incrementGameState()
    {
        gameState++;
    }

    internal static int getGameState()
    {
        return gameState;
    }

    // Scene Management Functions
    public void changeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

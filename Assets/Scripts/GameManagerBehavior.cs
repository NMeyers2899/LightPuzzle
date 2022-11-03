using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The boxes in the current scene.")]
    private List<LightBoxBehavior> _boxes;

    [SerializeField]
    [Tooltip("The screen that appears when the player completes a level.")]
    private Canvas _winScreen;

    [Tooltip("Checks to see every box in the scene has its on material.")]
    private bool _levelCompleted = false;

    /// <summary>
    /// Loads the next level in the game.
    /// </summary>
    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Loads the menu where the player can choose which level to go into.
    /// </summary>
    public static void LoadSceneMenu()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    /// <summary>
    /// Loads a given level.
    /// </summary>
    /// <param name="levelID"> The ID of the level to be loaded. </param>
    public static void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public static void QuitGame()
    {
        Debug.Log("Game Quit");

        Application.Quit();
    }

    /// <summary>
    /// Loads the first scene in the build order.
    /// </summary>
    public static void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            QuitGame();

        // If the level is completed...
        if (_levelCompleted)
        {
            // ...let the win screen pop up.
            _winScreen.gameObject.SetActive(true);
            return;
        }

        foreach (LightBoxBehavior box in _boxes)
        {
            // If any box in the scene does not have the on material, the level is not complete.
            if (box.LightIsOn == 0)
                return;       
        }

        _levelCompleted = true;
    }
}

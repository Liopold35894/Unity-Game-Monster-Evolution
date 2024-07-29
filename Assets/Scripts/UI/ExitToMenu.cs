using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{

    PauseManager pauseManager;

    private void Awake() {
        pauseManager = GetComponent<PauseManager>();
    }

    public void BackToMenu()
    {
        pauseManager.UnPauseGame();
        SceneManager.LoadScene("MainMenu");
    }
}

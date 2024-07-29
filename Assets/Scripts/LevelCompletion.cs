using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;
    [SerializeField] GameWinPanel levelCompletePenel;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelCompletePenel = FindObjectOfType<GameWinPanel>(true);
    }

    public void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelCompletePenel.gameObject.SetActive(true);
        }
    }
}

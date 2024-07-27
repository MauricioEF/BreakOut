using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public BlockManager blockManager;
    public GameManager gameManager;
    public void NextLevel()
    {
        //var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        //if (SceneManager.sceneCountInBuildSettings > nextLevel)
        //{
        //    SceneManager.LoadScene(nextLevel);
        //}
        //else
        //{
        //    LoadMainMenu();
        //}
        blockManager.Reset();
        GameObject.Find("LevelCompletedMenu").SetActive(false);
        var player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-0.2f, player.transform.position.y, player.transform.position.z);
        GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().Reset();
        gameManager.Resume();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

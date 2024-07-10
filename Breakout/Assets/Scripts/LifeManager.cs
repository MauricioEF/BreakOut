using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> Lives;
    public GameObject ballPrefab;
    private Ball ballScript;
    public GameObject GameOverMenu;


    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            Lives.Add(child.gameObject);
        }
    }

    public void LoseLife()
    {
        var objectToDelete = Lives[^1];
        Destroy(objectToDelete);
        Lives.Remove(Lives[^1]);
        Debug.Log($"Lives: {Lives.Count}");
        if(Lives.Count == 0)
        {
            GameOverMenu.SetActive(true);
            return;
        }
        var ball = Instantiate(ballPrefab) as GameObject;
        ballScript = ball.GetComponent<Ball>();
        ballScript.BallDestroyed.AddListener(this.LoseLife);
        Debug.Log($"Remaining lives: {Lives.Count}");
    }
}

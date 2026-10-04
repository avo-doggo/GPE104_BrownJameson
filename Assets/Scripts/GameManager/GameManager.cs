using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public PlayerController playerController;

    public List<Obstacle> obstacleList;

    public int score;

    public TMP_Text text;

    public void Awake()
    { // singleton pattern- this ensures there is onl y one instance of this code
      //pros- saves space/memory
      //cons- can become messy and hard to maintin if not properly planned
        obstacleList = new List<Obstacle>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   /*     if (obstacleList != null)
        {
            if (obstacleList.Count <= 0 && playerController != null)
            {
                if (playerController.pawn != null)
                {
                    Debug.Log("Victory!");
                }
            }*/
        if (score == 100)
        {
            Debug.Log("You Win!");

        }
        if (playerController != null)
            {
                if (playerController.pawn == null)
                {
                    Debug.Log("You Lose!");
                }
            }
        if (text != null)
        {
            text.text = "" + score;
        }
    }
}

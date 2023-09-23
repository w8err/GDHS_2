using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    // ΩÃ±€≈Ê
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (instance == null)
                    Debug.Log("instance is null");
            }
            return instance;
        }
    }

    public void SetScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        //SceneManager.LoadScene(1);
    }
}

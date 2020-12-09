using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // объект для связи объекта в юнити с кодом
    Text scoreText;
    // объект для связи текущей игровой сессии с кодом
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        // связли юнити с кодом
        scoreText = GetComponent<Text>();
        // связали текущую сессию с кодом
        gameSession = FindObjectOfType<GameSession>();
    }


    void Update()
    {
        // пока идёт игра меняем значения счета в углу экрана
        scoreText.text = gameSession.GetScore().ToString();
    }

}

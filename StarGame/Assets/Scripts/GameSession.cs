using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    // Awake вызывается до Start`a
    void Awake()
    {
        // Singleton - позволяет использовать один и тот же компонент повторно между сценами
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // если в игру играл хотябы раз (счёт изменялся), то удаляем счёт
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        // иначе не удаляем
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // функция-гетер для получения счёта
    public int GetScore()
    {
        return score;
    }

    // функция-модификатор для изменения счёта
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    // функция для удаления объекта GameSession
    public void ResetGame()
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float timeToLoad = 2f;

    // функция для загрузки стартового меню
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // функция для загрузки основной сцены с игрой
    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }

    // функция для загрузки экаран конца игры
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(2);
    }

    public void LoadSettingScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadAboutScene()
    {
        SceneManager.LoadScene(4);
    }

    // функция для выхода из игры
    public void QuitGame()
    {
        Application.Quit();
    }

}

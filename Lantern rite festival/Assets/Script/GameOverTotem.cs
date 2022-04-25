using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTotem : MonoBehaviour
{
    public GameObject _gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}

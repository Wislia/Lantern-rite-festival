using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{

    public GameObject lantern1, lantern2, lantern3, lantern1Off, lantern2Off, lantern3Off, gameOver;
    public static int health = 3;

    #region les conneries d'enzo
    public SpriteRenderer[] _healthRenderer;
    public Sprite _light;
    public Sprite _dark;

    public bool _gameOver;
    public AudioSource _osu;

    public void Start()
    {
        _gameOver = false;
        health = 3;
    }

    public void Healthbar()
    {   

        for (int i = 0; i < _healthRenderer.Length; i++)
        {
            if(health == 3)
            {
                _healthRenderer[i].sprite = _light;
            }
            if(health == 2)
            {
                _healthRenderer[0].sprite = _light;
                _healthRenderer[1].sprite = _light;
                _healthRenderer[2].sprite = _dark;
            }
            if (health == 1)
            {
                _healthRenderer[0].sprite = _light;
                _healthRenderer[1].sprite = _dark;
                _healthRenderer[2].sprite = _dark;
            }
            if (health == 0)
            {
                _healthRenderer[i].sprite = _dark;

                _gameOver = true;
                Time.timeScale = 0f;
                _osu.Pause();
            }
        }

    }

    #endregion

    public void MaggleHealth()
    {
       if(health > 3)
        {
            health = 3;
        }

        if (health == 3)
        {
            lantern1.gameObject.SetActive(true);
            lantern2.gameObject.SetActive(true);
            lantern3.gameObject.SetActive(true);
            lantern1Off.gameObject.SetActive(false);
            lantern2Off.gameObject.SetActive(false);
            lantern3Off.gameObject.SetActive(false);
            //Debug.Log("3 vies");
        }

        if (health == 2)
        {
            lantern1.gameObject.SetActive(true);
            lantern2.gameObject.SetActive(true);
            lantern3.gameObject.SetActive(false);
            lantern1Off.gameObject.SetActive(false);
            lantern2Off.gameObject.SetActive(false);
            lantern3Off.gameObject.SetActive(true);
            //Debug.Log("2 vies");
        }

        if (health == 1)
        {
            lantern1.gameObject.SetActive(true);
            lantern2.gameObject.SetActive(false);
            lantern3.gameObject.SetActive(false);
            lantern1Off.gameObject.SetActive(false);
            lantern2Off.gameObject.SetActive(true);
            lantern3Off.gameObject.SetActive(true);
            //Debug.Log("1 vie");
        }

        if (health == 0)
        {
            lantern1.gameObject.SetActive(false);
            lantern2.gameObject.SetActive(false);
            lantern3.gameObject.SetActive(false);
            lantern1Off.gameObject.SetActive(true);
            lantern2Off.gameObject.SetActive(true);
            lantern3Off.gameObject.SetActive(true);
            //gameOver.gameObject.SetActive(true);
            //Debug.Log("GAME OVER");
        }
    }

    void Update()
    {
        if (health < 0)
            health = 0;

        if (health > 3)
            health = 3;
        //MaggleHealth();
        Healthbar();

        if (_gameOver == true)
        {
            gameOver.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            gameOver.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

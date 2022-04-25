using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    public static bool GameIsPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}

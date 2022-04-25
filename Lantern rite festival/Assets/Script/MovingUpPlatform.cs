using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpPlatform : MonoBehaviour
{
    public float _speed;

    void Update()
    {
        transform.position += transform.up* _speed * Time.deltaTime;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFight : MonoBehaviour
{
    public Vector2 position1;
    public Vector2 position2;
    public Vector2 position0;
    public float speed;
    public int deplacement;
    public Animator _attaques;

    public GameObject _particule0, _particule1, _particule2 ;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (deplacement == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, position1, speed * Time.deltaTime);
            _attaques.Play("Position2");
            _particule1.gameObject.SetActive(true);
            _particule2.gameObject.SetActive(false);
            _particule0.gameObject.SetActive(false);
        }

        if (deplacement == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, position2, speed * Time.deltaTime);
            _attaques.Play("Position3");
            _particule2.gameObject.SetActive(true);
            _particule1.gameObject.SetActive(false);
            _particule0.gameObject.SetActive(false);
        }

        if (deplacement == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, position0, speed * Time.deltaTime);
            _attaques.Play("Position1");
            _particule0.gameObject.SetActive(true);
            _particule1.gameObject.SetActive(false);
            _particule2.gameObject.SetActive(false);
        }
    }
}

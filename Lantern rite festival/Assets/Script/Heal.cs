using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject _particule;
    public AudioSource _ranad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                GameManager.instance.Heal();
                Instantiate(_particule, transform.position, _particule.transform.rotation);
                _ranad.Play();

                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

        if (other.tag == "Miss")
        {
            canBePressed = false;
        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Miss")
        {
            canBePressed = false;
        }
    }*/
}
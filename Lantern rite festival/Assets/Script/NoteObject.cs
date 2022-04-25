using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hit, good, perfect, miss;

    float perfectPosition = -4.13f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                GameManager.instance.IncreaseCharacterPosition();
                //GameManager.instance._totalNotes --;
                Destroy(this.gameObject);
                //gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                /*if(Mathf.Abs(transform.position.y) > -4.2)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hit, transform.position, hit.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > -5.6f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(good, transform.position, good.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfect, transform.position, perfect.transform.rotation);
                }*/

                float distance = Mathf.Abs(transform.position.y - perfectPosition);

                //Debug.Log(distance);

                if (distance < 0.08f)
                {
                    //Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfect, transform.position, perfect.transform.rotation);
                }
                else if (distance < 0.20f)
                {
                    //Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(good, transform.position, good.transform.rotation);
                }
                else
                {
                    //Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hit, transform.position, hit.transform.rotation);
                }
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

            GameManager.instance.NoteMissed();
            Instantiate(miss, transform.position, miss.transform.rotation);

            LivesCounter.health -= 1;

        }
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Miss")
        {
            canBePressed = false;

            GameManager.instance_2.NoteMissed();

            LivesCounter.health -= 1;

        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteObjectEnd : MonoBehaviour
{
    
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hit, good, perfect, miss;

    float perfectPosition = -4.13f;

    public SpriteRenderer _theSR;

    public Animator _fade, _disolve;

    public bool _touche;

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
                _theSR.enabled = false;
                _touche = true;

                float distance = Mathf.Abs(transform.position.y - perfectPosition);

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

        

        if (other.tag == "Miss" && _touche == true)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            

            StartCoroutine(Coroutine());
        }
        else if (other.tag == "Miss" && _touche == false)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(miss, transform.position, miss.transform.rotation);
            LivesCounter.health -= 1;

            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        _disolve.Play("Stop");
        yield return new WaitForSeconds(0.5f);
        _disolve.Play("Disolve");
        yield return new WaitForSeconds(1f); //temps à la fin de la chanson
        _fade.Play("FadeIn");
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene("Ayato");
    }
}

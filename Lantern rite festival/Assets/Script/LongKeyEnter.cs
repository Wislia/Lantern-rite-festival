using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongKeyEnter : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hit, good, perfect, miss;

    float perfectPosition = -4.13f;

    public LongKey _longKey;

    public bool _hit, _good, _perfect, _true;
    public BoxCollider2D _colliderToDespawn;



    // Start is called before the first frame update
    void Start()
    {
        _colliderToDespawn = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            _longKey._stopPress = false;

            if (canBePressed == true)
            {
                GameManager.instance.IncreaseCharacterPosition();
                

                float distance = Mathf.Abs(transform.position.y - perfectPosition);
                _colliderToDespawn.enabled = false;

                if (distance < 0.08f)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfect, transform.position, perfect.transform.rotation);
                    _longKey._perfect = true;
                    _perfect = true;
                }
                else if (distance < 0.20f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(good, transform.position, good.transform.rotation);
                    _longKey._good = true;
                    _good = true;
                }
                else
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hit, transform.position, hit.transform.rotation);
                    _longKey._hit = true;
                    _hit = true;
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
            _longKey._stopPress = true;
            _longKey._stopPress = true;

            GameManager.instance.NoteMissed();
            Instantiate(miss, transform.position, miss.transform.rotation);

            LivesCounter.health -= 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongKey : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hit, good, perfect, miss;

    public bool _pressed;
    public bool _stopPress;

    public bool _hit, _good, _perfect;

    public LongKeyEnter _longKeyEnter;

    private float _timer;
    public float _timerDuration;

    public GameObject _particuleLeft, _particuleUp, _particuleDown, _particuleRight;

    public enum ArrowType
    {
        Left = 0,
        Up = 1, 
        Down = 2,
        Right = 3
    }
    public ArrowType _arrowType;


    // Start is called before the first frame update
    void Start()
    {
        _timer = _timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (_arrowType == ArrowType.Up)
            Debug.Log("ksbfhjfhgbqehr");
        if(_pressed == true)
        {
            Debug.Log("vaniquertagrossedaronnelachiennasse");

            _timer -= Time.deltaTime;

            if (_arrowType == ArrowType.Up)
            {
                _particuleUp.gameObject.SetActive(true);
                Debug.Log("yee");
            }
            if (_arrowType == ArrowType.Left)
            {
                _particuleLeft.gameObject.SetActive(true);
            }
            if (_arrowType == ArrowType.Down)
            {
                _particuleDown.gameObject.SetActive(true);
            }
            if (_arrowType == ArrowType.Right)
            {
                _particuleRight.gameObject.SetActive(true);
            }

            if (_timer <= 0)
            {
                GameManager.instance.IncreaseCharacterPosition();

                if (_longKeyEnter._perfect == true)
                {
                    GameManager.instance.PerfectHit();
                    Debug.Log("perfect");
                }
                if (_longKeyEnter._good == true)
                {
                    GameManager.instance.GoodHit();
                    Debug.Log("good");
                }
                if (_longKeyEnter._hit == true)
                {
                    GameManager.instance.NormalHit();
                    Debug.Log("hit");
                }
                _timer = _timerDuration;
            }

        }

            if (_stopPress == true)
            {
                _particuleDown.gameObject.SetActive(false);
                _particuleUp.gameObject.SetActive(false);
                _particuleLeft.gameObject.SetActive(false);
                _particuleRight.gameObject.SetActive(false);
            }

        if (Input.GetKey(keyToPress))
        {
            
            if (canBePressed == true && _stopPress == false)
            {
                _pressed = true;
            }
           
        }

        if (canBePressed == true && _pressed == true)
        {
            if(Input.GetKeyUp(keyToPress))
            {
                _pressed = false;
                _stopPress = true;
                canBePressed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
}

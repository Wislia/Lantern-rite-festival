using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMode : MonoBehaviour
{
    public GameObject _vie, _heal;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("easy = " + GameManager.instance.GetEasyMode());

        if (GameManager.instance.GetEasyMode() == false)
        {
            _vie.gameObject.SetActive(false);
            _heal.gameObject.SetActive(false);
        }
        else
        {
            _vie.gameObject.SetActive(false);
            _heal.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

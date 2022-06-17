using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Animator _appear;
    public Animator _textAnim;
    public GameObject _shake;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2f);
        _shake.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _appear.Play("IntroJeu");
        _textAnim.Play("Fade");
    }
}

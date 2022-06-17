using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chargement : MonoBehaviour
{
    public Animator _phewww, _fade;
    public float _bruh;
    public AudioSource _ranad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnMouseDown();
            _bruh++;
        }

        if (_bruh == 1)
        {
            _phewww.Play("phewwwwww");
        }

        if (_bruh == 2)
        {
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        //yield return new WaitForSeconds(1f);
        _fade.Play("FadeIn");
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnMouseDown()
    {
        _ranad.Play();
    }
}

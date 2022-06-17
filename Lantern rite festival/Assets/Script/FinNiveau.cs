using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    public GameObject _vcamFin;
    public MovementCamera _character;

    public Animator _fade;

    public Animator _idle, _boss;

    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Fin();
        }
    }

    void Fin()
    {
        _vcamFin.SetActive(true);
        _character.enabled = false;
        StartCoroutine(Coroutine());

        _idle.Play("idle");
        _boss.Play("CaramboleBoss1");
        
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3f);
        _fade.Play("FadeIn");
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene(3);
    }
}

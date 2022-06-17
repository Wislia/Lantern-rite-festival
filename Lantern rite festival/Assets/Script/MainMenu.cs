using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public Slider _musicSlider;
    public Slider _sfxSlider;

    public AudioSource _ranad;


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Scene2()
    {
        SceneManager.LoadScene(4);
    }

    public void Scene1()
    {
        SceneManager.LoadScene(2);
    }

    private void Awake()
    {
        _audioMixer.GetFloat("MusicVolume", out float _vMusique);
        _musicSlider.value = _vMusique;
        _audioMixer.GetFloat("SFXVolume", out float _vSFX);
        _musicSlider.value = _vSFX;
    }

    public void SetMusic(float music)
    {
        _audioMixer.SetFloat("MusicVolume", music);
    }
    public void SetSFX(float sfx)
    {
        _ranad.Play();
        _audioMixer.SetFloat("SFXVolume", sfx);
    }

}

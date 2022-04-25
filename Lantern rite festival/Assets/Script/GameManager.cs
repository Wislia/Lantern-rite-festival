using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour

{
    public AudioSource theMusic;
    public AudioSource _ranad;
    public bool startPlaying;
    public BeatsScroller theBS;

    //public static GameManager instance_2;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfect = 150;

    public TextMeshProUGUI scoreText = null;
    public TextMeshProUGUI multiText=  null;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public float _totalNotes;
    public float _normalHits;
    public float _goodHits;
    public float _perfectHits;
    public float _missedHits;
    public float _totalHits;
    public float _percentHits;

    public static float _staticnormalHits;
    public static float _staticGoodHits;
    public static float _staticPerfectHits;
    public static float _staticMissedHits;
    public static float _staticTotalScore;
    public static float _staticComboMax;

    public TextMeshProUGUI _combosText, _normalsText, _goodsText, _perfectText, _missedText, _rankText, _finalScoreText = null;

    public static float _staticTotalNotes;
    public static float _staticPercentHit;
    public static float _staticTotalHits;

    public CharacterFight _personnage =null;
    private static GameManager _instance;

    private int _combo;
    public static GameManager instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;

        }
    }

    internal void Heal()
    {
        LivesCounter.health++;

        Debug.Log("+1");
    }

    internal void IncreaseCharacterPosition()
    {
        _personnage.deplacement++;
        if (_personnage.deplacement == 3)
        {
            _personnage.deplacement = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        //scoreText.text = "Score: 0";
        currentMultiplier = 1;

        _totalNotes = FindObjectsOfType<NoteObject>().Length;

        _rankText.text = "F";
    }

    // Update is called once per frame
    void Update()
    {
        /* if (!startPlaying)
         {
             if (Input.anyKeyDown)
             {
                 startPlaying = true;
                 theBS.hasStarted = true;
                 theMusic.Play();
             }
         }*/

        

        //Debug.Log("pourcentage " + _staticPercentHit);
        //Debug.Log("Total " + _staticTotalNotes); 

        if (_staticPercentHit > 40)
        {
            _rankText.text = "D";
            if (_staticPercentHit > 55)
            {
                _rankText.text = "C";
                if (_staticPercentHit > 70)
                {
                    _rankText.text = "B";
                    if (_staticPercentHit > 85)
                    {
                        _rankText.text = "A";
                        if (_staticPercentHit > 95)
                        {
                            _rankText.text = "S";
                            if (_staticPercentHit > 100)
                            {
                                _rankText.text = "SS";
                            }
                        }
                    }
                }
            }
        }

        if (currentMultiplier > _staticComboMax)
        {
            _staticComboMax = currentMultiplier;
        }

        _finalScoreText.text = _staticTotalScore.ToString();
        _normalsText.text = _staticnormalHits.ToString();
        _goodsText.text = _staticGoodHits.ToString();
        _perfectText.text = _staticPerfectHits.ToString();
        _missedText.text = _staticMissedHits.ToString();
        _combosText.text = _staticComboMax.ToString();
    }

    public void NoteHit()
    {
        //Debug.Log("Hit On Time");

        _ranad.Play();
         _combo++;

       for (int i = 0; i < multiplierThresholds.Length; i++)
        {
            if (_combo == multiplierThresholds[i])
            {
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;

        _staticTotalScore = currentScore;



        _totalHits = _normalHits + _goodHits + _perfectHits;
        _staticTotalHits = _totalHits;

        _percentHits = (_totalHits / _totalNotes) * 100f;
        _staticPercentHit = _percentHits;


        /*Debug.Log("pourcentage " + _staticPercentHit);
        Debug.Log("Total " + _totalNotes);
        Debug.Log("Hits " + _totalHits);*/


    }

    public void NormalHit()
    {
        _combo++;
        //Debug.Log("HitGM");
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        _normalHits++;

        _staticnormalHits = _normalHits;
        
    }

    public void GoodHit()
    {
        _combo++;
        //Debug.Log("GoodGM");
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        _goodHits++;

        _staticGoodHits = _goodHits;
    }

    public void PerfectHit()
    {
        _combo++;
        //Debug.Log("PerfectGM");
        currentScore += scorePerPerfect * currentMultiplier;
        NoteHit();
        _perfectHits++;

        _staticPerfectHits = _perfectHits;
    }

    public void NoteMissed()
    {
        //Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        _missedHits++;

        _personnage.deplacement = 0;

        _staticMissedHits = _missedHits;
    }

    public void Setter(float _normal)
    {
        _normalHits = _normal;
    }
}

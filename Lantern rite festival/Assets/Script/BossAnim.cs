using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    public Sprite[] _alphaArray;
    public Material _material;
    private int _animStep;
    public Sprite _defaultSprite;

    

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimPlus()
    {
        if (_animStep < 7)
        {
            _animStep++;
            _material.SetTexture("_Alpha", _alphaArray[_animStep].texture);
        }
    }

    public void AnimMoins()
    {
        if (_animStep > 0)
        {
            _animStep--;
            _material.SetTexture("_Alpha", _alphaArray[_animStep].texture);
        }
    }

    public void SetForAnim()
    {
        _material.SetTexture("_Alpha", _alphaArray[0].texture);
    }

    public void Reset()
    {
        _material.SetTexture("_Alpha", _defaultSprite.texture);
        _animStep = 0;

    }
}

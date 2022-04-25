using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLanterns : MonoBehaviour
{

    public Image[] _lantern;
    public Sprite _light;
    public Sprite _dark;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _lantern.Length; i++)
        {
            if (AllLanterns.NumberOfLanterns == 8)
            {
                _lantern[i].sprite = _light;
            }
            if (AllLanterns.NumberOfLanterns == 7)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _light;
                _lantern[3].sprite = _light;
                _lantern[4].sprite = _light;
                _lantern[5].sprite = _light;
                _lantern[6].sprite = _light;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 6)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _light;
                _lantern[3].sprite = _light;
                _lantern[4].sprite = _light;
                _lantern[5].sprite = _light;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 5)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _light;
                _lantern[3].sprite = _light;
                _lantern[4].sprite = _light;
                _lantern[5].sprite = _dark;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 4)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _light;
                _lantern[3].sprite = _light;
                _lantern[4].sprite = _dark;
                _lantern[5].sprite = _dark;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 3)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _light;
                _lantern[3].sprite = _dark;
                _lantern[4].sprite = _dark;
                _lantern[5].sprite = _dark;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 2)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _light;
                _lantern[2].sprite = _dark;
                _lantern[3].sprite = _dark;
                _lantern[4].sprite = _dark;
                _lantern[5].sprite = _dark;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 1)
            {
                _lantern[0].sprite = _light;
                _lantern[1].sprite = _dark;
                _lantern[2].sprite = _dark;
                _lantern[3].sprite = _dark;
                _lantern[4].sprite = _dark;
                _lantern[5].sprite = _dark;
                _lantern[6].sprite = _dark;
                _lantern[7].sprite = _dark;
            }
            if (AllLanterns.NumberOfLanterns == 0)
            {
                _lantern[i].sprite = _dark;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

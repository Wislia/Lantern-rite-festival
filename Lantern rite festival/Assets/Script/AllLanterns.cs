using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AllLanterns : MonoBehaviour
{
    public static int NumberOfLanterns;
    public TextMeshProUGUI lanternCount;

    private void Update()
    {
        //Debug.Log(NumberOfLanterns);
        lanternCount.text = "Lanterns: " + NumberOfLanterns;
    }

    private void Start()
    {
        NumberOfLanterns = 0;
    }
}

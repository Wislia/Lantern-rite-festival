using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesTesMorts : MonoBehaviour
{
    public ParallaxBackground[] _parallax;
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

        if (other.tag == "Particules")
        {
            for (int i = 0; i < _parallax.Length; i++)
            {
                _parallax[i]._isDecreasing = true;
            }
        }
    }
}

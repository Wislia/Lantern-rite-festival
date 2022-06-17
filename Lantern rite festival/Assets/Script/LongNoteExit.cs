using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteExit : MonoBehaviour
{
    public LongKey _longKey;

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
        if (other.tag == "Miss")
        {
            _longKey._pressed = false;
            Destroy(this.transform.parent.gameObject);
        }
    }
}

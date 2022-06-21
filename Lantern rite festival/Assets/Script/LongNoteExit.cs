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
        if (other.tag == "Miss" && Input.GetKey(_longKey.keyToPress) == true)
        {
            Debug.Log("with key");
            _longKey._pressed = false;
            _longKey._stopPress = true;
            _longKey._particuleLeft.SetActive(false);
            _longKey._particuleRight.SetActive(false);
            _longKey._particuleUp.SetActive(false);
            _longKey._particuleDown.SetActive(false);

            Destroy(this.transform.parent.gameObject);

        }

        if (other.tag == "Miss")
        {
            Debug.Log("without key");
            _longKey._pressed = false;
            _longKey._stopPress = true;
            _longKey._particuleLeft.SetActive(false);
            _longKey._particuleRight.SetActive(false);
            _longKey._particuleUp.SetActive(false);
            _longKey._particuleDown.SetActive(false);

            Destroy(this.transform.parent.gameObject);
        }
    }
}

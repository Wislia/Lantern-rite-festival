using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLantern : MonoBehaviour
{
    [SerializeField] private HingeJoint2D hingeJoint2D;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private Sprite sprite;
    [SerializeField] private ParticleSystem particule;
    [SerializeField] private Rigidbody2D lanternRB;
     private bool LanternTaken = true;

    public float _maxSpeed;

    public AudioSource _fiou;

    private void OnMouseDown()
    {
        if (LanternTaken == true)
        {
            _fiou.Play();
            AllLanterns.NumberOfLanterns++;
            spriteR.sprite = sprite;
            
            //hingeJoint2D.enabled = true;
            particule.Play();
            LanternTaken = false;
            lanternRB.velocity = new Vector2(0, 0);
            lanternRB.gravityScale = -0.3f;
        }
        
    }

    private void Update()
    {
        if (lanternRB.velocity.magnitude > _maxSpeed)
        {
            lanternRB.velocity = Vector2.ClampMagnitude(lanternRB.velocity, _maxSpeed);
        }
        //Debug.Log(lanternRB.velocity.y);
    }
}

using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody2D;

    public Animator _animation;

    public GameObject _groundCheck;
    public float _minDistance;

    private Ray2D _ray;

    public LayerMask _layerMask;

    private bool _isJumping;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;*/

        //Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f
        //

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

            _isJumping = true;
        }

        if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _isJumping = false;
        }
        /*else
        {
            _isJumping = true;
        }*/

        _animation.SetFloat("yVelocity", _rigidbody2D.velocity.y);

        /*if (Physics2D.Raycast(_groundCheck.transform.position, Vector3.down, _minDistance, _layerMask))
        {
            _isJumping = false;
        }*/

        Debug.Log(_isJumping);
        Debug.DrawRay(_groundCheck.transform.position, _groundCheck.transform.TransformDirection(Vector3.down) * _minDistance, Color.magenta);
        _animation.SetBool("Jump", _isJumping);
    }


}
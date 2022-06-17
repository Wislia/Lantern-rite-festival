using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private Rigidbody2D _rigidbody2D;

    public Animator _animation;

    public GameObject _groundCheck;
    public float secondGroundCheckOffset;
    public float _minDistance;

    private Ray2D _ray;

    public LayerMask _layerMask;

    private bool _isOnGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _isOnGround = (Physics2D.Raycast(_groundCheck.transform.position, Vector3.down, _minDistance, _layerMask));
        _isOnGround |= (Physics2D.Raycast(_groundCheck.transform.position + Vector3.right * secondGroundCheckOffset, Vector3.down, _minDistance, _layerMask));
        _isOnGround &= Mathf.Abs(_rigidbody2D.velocity.y) < 0.1f;
    }

    private void Update()
    {
        /*var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;*/

        if (Input.GetButtonDown("Jump") && _isOnGround)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        _animation.SetFloat("yVelocity", _rigidbody2D.velocity.y);
        _animation.SetBool("grounded", _isOnGround);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_groundCheck.transform.position, _groundCheck.transform.position + Vector3.down * _minDistance);
        Gizmos.DrawLine(_groundCheck.transform.position + Vector3.right * secondGroundCheckOffset, _groundCheck.transform.position + Vector3.right * secondGroundCheckOffset + Vector3.down * _minDistance);
    }

}
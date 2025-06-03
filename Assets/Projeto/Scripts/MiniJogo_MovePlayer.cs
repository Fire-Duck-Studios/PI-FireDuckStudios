using UnityEngine;
using UnityEngine.InputSystem;

public class MiniJogo_MovePlayer : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _forceJump;

    Vector2 _move;
    Rigidbody2D _rig;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();  
    } 

    
    void Update()
    {
        Move();
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rig.linearVelocity = new Vector2(_move.x * _speed, _rig.linearVelocity.y); 
    }

    void Jump()
    {
        if (_rig.linearVelocityY <= 0)
        {
            _rig.linearVelocityY = 0;
            _rig.AddForceY(_forceJump);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpOrb"))
        {
            Jump();
            Debug.Log("Entrou");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpOrb"))
        {
            Debug.Log("Saiu");
        }
    }
}

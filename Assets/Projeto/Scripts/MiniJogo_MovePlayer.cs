using UnityEngine;
using UnityEngine.InputSystem;

public class MiniJogo_MovePlayer : MonoBehaviour
{
    [SerializeField] float _speed;

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

}

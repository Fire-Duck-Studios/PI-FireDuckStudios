using UnityEngine;
using UnityEngine.InputSystem;

public class Main_MovePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;

    // Input
    Vector2 _moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocity = new Vector2(_moveInput.x * _speed, _moveInput.y * _speed);
    }
    public void SetMove(InputAction.CallbackContext value)
    {
        //Debug.Log("entrou ao clicar");
        _moveInput = value.ReadValue<Vector2>();
    }
}

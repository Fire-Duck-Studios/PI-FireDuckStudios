using UnityEngine;
using UnityEngine.InputSystem;

public class Main_MovePlayer : MonoBehaviour
{
    // Componentes
    Rigidbody2D _rb;

    // Input
    Vector2 _moveInput;

    //Movimento
    [SerializeField] float _speed;

    void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        Debug.Log("Player Index: " + playerInput.playerIndex);

        // seta o componente rigidbody na variavel
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Acessa o game componente rigidbody e seta novas velocidades lineares
        _rb.linearVelocity = new Vector2(_moveInput.x * _speed, _moveInput.y * _speed);
    }
    public void SetMove(InputAction.CallbackContext value)
    {
        //Ao clicar adiciona 1 no vector, ou seja, conseguimos enviar sinais quando clicar
        _moveInput = value.ReadValue<Vector2>();
    }
}

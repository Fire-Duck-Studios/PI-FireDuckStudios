using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    // Componentes
    MJ_GameControl _gameControl;
    Rigidbody2D _rb;
    Animator _anim;

    // Input
    Vector2 _moveInput;

    // Movimento e pulo
    [SerializeField] float _speed;
    [SerializeField] float _jumpPulos;
    [SerializeField] float _forceJump;
    public int _numberJumps = 0;
    public int _MaximoJump = 2;

    // Estado do personagem
    [SerializeField] bool _checkGround;
    [SerializeField] bool _facingRight;
    [SerializeField] bool _morte;
    [SerializeField] bool _podePular = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
    }

    void FixedUpdate()
    {
        if (_gameControl._gameStay)
        {
            _rb.linearVelocity = new Vector2(_moveInput.x * _speed, _rb.linearVelocity.y);
            _podePular = true;
        }

        if (_gameControl.certo)
        {
            _gameControl._gameStay = false;
            _gameControl._fimGame = true;

            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.linearVelocity = Vector2.zero;

            _gameControl._panelFimGame.gameObject.SetActive(true);
            _gameControl._panelFimGame.transform.localScale = Vector3.one;

            _gameControl.GameStay(false);
        }

        if (!_morte) 
        {
            if (_moveInput.x > 0 && _facingRight)
            {
                Flip();
            }
            else if (_moveInput.x < 0 && !_facingRight)
            {
                Flip();
            }

            Anim();


        }  
        
    }

    private void Anim()
    {
        float moveX = Mathf.Abs(_moveInput.x);
        _anim.SetFloat("MoveH", moveX);
        _anim.SetFloat("MoveY", _rb.linearVelocity.y);
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _moveInput = value.ReadValue<Vector2>();
    }

    public void SetJump(InputAction.CallbackContext value)
    {
        if (!_podePular) return;

        if (value.performed && _checkGround && _jumpPulos == 0)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
            _numberJumps++;
            _jumpPulos = 1;
        }
        else if (value.performed && !_checkGround && _numberJumps <= _MaximoJump && _jumpPulos == 1)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
            _rb.AddForce(Vector2.up * _forceJump, ForceMode2D.Impulse);
            _numberJumps++;
            _jumpPulos = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _checkGround = true;
            _numberJumps = 0;
            _jumpPulos = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _checkGround = false;
        }

        if (collision.CompareTag("Limbo"))
        {
            _gameControl._gameStay = false;
            _gameControl._fimGame = true;

            _gameControl._panelFimGame.gameObject.SetActive(true);
            _gameControl._panelFimGame.transform.localScale = Vector3.one;

            _gameControl.GameStay(false);
            Morte();
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Morte()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.linearVelocity = Vector2.zero;
        _morte = true;
    }
}

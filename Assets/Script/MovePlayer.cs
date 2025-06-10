using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    MJ_GameControl _gameControl;
    Rigidbody2D _rb;
    Vector2 _moveInput,center;
    [SerializeField] float _speed;
    [SerializeField] float _forceJump;
    [SerializeField] bool _checkGround, _facingRight, morte, popular = false;
    MJ_Enemy mJ_Enemy;
    Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb =GetComponent<Rigidbody2D>();
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        mJ_Enemy = GameObject.FindWithTag("Enemy").GetComponent<MJ_Enemy>();    
    }

    void Update()
    {
     
       
        if (_gameControl._gameStay == true) 
        {
            _rb.linearVelocity = new Vector2(_moveInput.x * _speed, _rb.linearVelocity.y);
            popular = true;
        }
      
        if (_gameControl.certo)
        {
            _gameControl._gameStay = false;
            _gameControl._fimGame = true;

            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.linearVelocity = new Vector2(0, 0);

            _gameControl._panelFimGame.gameObject.SetActive(true);
            _gameControl._panelFimGame.transform.localScale = Vector3.one;

            _gameControl.GameStay(false);


        }

        if (!morte) 
        {

            if (_moveInput.x > 0 && _facingRight == true)
            {
                flip();
            }
            else if (_moveInput.x < 0 && _facingRight == false)
            {
                flip();
            }
            Anim();



        }
        
     

    }

    private void Anim()
    {
        float _animMoveX = Mathf.Abs(_moveInput.x);
        _anim.SetFloat("MoveH", _animMoveX);
        _anim.SetFloat("MoveY", _moveInput.y);
    }
    void Jump()
    {
        if (_rb.linearVelocityY <= 0 && popular)
        {
            _rb.linearVelocityY = 0;
            _rb.AddForceY(_forceJump);
        }
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _moveInput = value.ReadValue<Vector2>();
    }
    public void SetJump(InputAction.CallbackContext value)
    {
        if (_checkGround) 
        {
            Jump();
        }   

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            MJ_GroundJumpControl groundJump = collision.gameObject.GetComponent<MJ_GroundJumpControl>();

            
            

          
            Debug.Log("_numbSort");
            //_gameControl._menuControl.CorPulo(_numbSort);

            _checkGround = true;
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _checkGround = false;
        }
        
    }

    void flip()
    {
        _facingRight = !_facingRight;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector2(x, transform.localScale.y);
    }

    public void Morte()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.linearVelocity = new Vector2(0, 0);
        morte = true;
    }


}

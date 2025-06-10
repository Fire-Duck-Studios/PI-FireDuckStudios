using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    MJ_GameControl _gameControl;
    Rigidbody2D _rb;
    Vector2 _moveInput;
    [SerializeField] float _speed;
    [SerializeField] float _forceJump;
    [SerializeField] bool _checkGround;


    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameControl._gameStay == true) 
        {
            _rb.linearVelocity = new Vector2(_moveInput.x * _speed, _rb.linearVelocity.y);
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

    }

    void Jump()
    {
        if (_rb.linearVelocityY <= 0)
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


}

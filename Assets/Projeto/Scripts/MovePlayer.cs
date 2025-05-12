using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float _speed;


    Vector2 _move;
    void Start()
    {
        
    }

   
    void Update()
    {
        Move();
    }

    public void SetMove(InputAction.CallbackContext Value)
    {
        _move = Value.ReadValue<Vector2>();
        
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_move.x, _move.y, 0f);
        transform.position += movement * _speed * Time.deltaTime;
    }
}

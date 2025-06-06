using UnityEngine;

public class MJ_GroundPref : MonoBehaviour
{
    public GameObject _fimGame;

    [SerializeField] MJ_GroundJumpControl[] _jumpControl;
    MovePlayer _player;

    MJ_GameControl _gameControl;

    private void Start()
    {
        // _player = GetComponent<MovePlayer>();
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        _player = _gameControl._Player;
    }
    private void Update()
    {
        for (int i = 0; i < _jumpControl.Length; i++)
        {
            _jumpControl[i].gameObject.SetActive(false);
            _jumpControl[_player._numbSort].gameObject.SetActive(true);
        }
    }
    
}

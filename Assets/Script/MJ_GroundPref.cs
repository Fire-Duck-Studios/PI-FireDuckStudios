using UnityEngine;

public class MJ_GroundPref : MonoBehaviour
{
    public GameObject _fimGame;

    [SerializeField] MJ_GroundJumpControl[] _jumpControl;
    MovePlayer _player;

    MJ_GameControl _gameControl;
    int _numbSort;

    private void Start()
    {
        // _player = GetComponent<MovePlayer>();
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        _player = _gameControl._Player;
        SorteOrb();
    }
    private void SorteOrb()
    {
        _numbSort = Random.Range(0, 4);
        for (int i = 0; i < _jumpControl.Length; i++)
        {
            _jumpControl[i].gameObject.SetActive(false);
            _jumpControl[_numbSort].gameObject.SetActive(true);
        }
    }
    
}

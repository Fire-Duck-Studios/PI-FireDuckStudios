using TMPro;
using UnityEngine;

public class MJ_MenuControl : MonoBehaviour
{
    MJ_GameControl _gameControl;

    [SerializeField] string[] _nomeCores;
    [SerializeField] TextMeshProUGUI _textoComando;



    void Start()
    {
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        CorPulo(0);
    }

    public void CorPulo(int number)
    {
        //_textoComando.text = _nomeCores[number];
    }
}

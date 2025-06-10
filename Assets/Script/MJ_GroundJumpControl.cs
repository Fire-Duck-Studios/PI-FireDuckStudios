using UnityEngine;
using TMPro;

public class MJ_GroundJumpControl : MonoBehaviour
{
    public int _numbCor;
    MJ_GameControl _gameControl;
    public TextMeshProUGUI textoPontuacao;
   


    void Start()
    {
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            _gameControl.pontuacao++;
            _gameControl._pontuacaotexto.text = "Orb: " + _gameControl.pontuacao;
        
            gameObject.SetActive(false);


        }
    }

    

}
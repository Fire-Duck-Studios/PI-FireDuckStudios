using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MJ_GameControl : MonoBehaviour
{
    public MJ_MenuControl _menuControl;
    [SerializeField] Transform _groundBase;
    [SerializeField] float _groundH;
    [SerializeField] float _distance;

    [SerializeField] bool _checkGroundCount;

    public bool _gameStay;
    public TextMeshProUGUI _pontuacaotexto;
    public bool _fimGame;
    public int pontuacao;
    public int _groundNumber;
    public bool certo;
    [SerializeField] Transform _panelStartGame;

    public Transform _panelFimGame;

    public MovePlayer _Player;

    [SerializeField] float _posx;

    private void Update()
    {
        if (pontuacao == 10)
        {
            certo = true;
        }
    }
    void Start()
    {
        _groundH = _groundBase.position.y;

        Invoke("GroundTime", 0.25f);

        _panelStartGame.gameObject.SetActive(true);

        _panelFimGame.localScale = new Vector3(0, 0, 0);
    }

    void GroundTime()
    {
        for (int i = 0; i < _groundNumber; i++)
        {
            GroundStart();
            if (i == _groundNumber - 2)
            {
                _checkGroundCount = true;
            }
        }
    }

    // Update is called once per frame
    void GroundStart()
    {
        GameObject bullet = MJ_GroundPool._groundPool.GetPooledObject();
        if (bullet != null)
        {

            bullet.SetActive(true);

            //bullet.GetComponent<MJ_GroundPref>()._fimGame.SetActive(false);

            float posx1 = bullet.transform.position.x + _posx;
            float posx2 = bullet.transform.position.x - _posx;

            int sort = Random.Range(0, 2);

            if (sort == 0) {
                bullet.transform.position = new Vector2(posx1, _groundH + _distance);
            }
            else {
                bullet.transform.position = new Vector2(posx2, _groundH + _distance);
            }


           // bullet.transform.position = new Vector2(bullet.transform.position.x, _groundH + _distance);
            _groundH = bullet.transform.position.y;
            if (_checkGroundCount == true)
            {
               

                bullet.GetComponent<MJ_GroundPref>()._fimGame.SetActive(true);
            }
            //bullet.transform.rotation = turret.transform.rotation;
            bullet.SetActive(true);
        }
    }

    IEnumerator TimeFimGame()// time controlado para chamat fim de jogo
    {
        //desativar o player
        yield return new WaitForSeconds(1);
        //chamar o painel reniciar jogo

    }

    public void GameStay(bool ativar)
    {
        _gameStay = ativar;
        if (_gameStay == true)
        {
            _panelStartGame.localScale = new Vector3(0, 0, 0);
        }
        else if (_fimGame == true)
        {
            _panelFimGame.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ResetarCena(string Cena)
    {
        SceneManager.LoadScene(Cena);
    }
}

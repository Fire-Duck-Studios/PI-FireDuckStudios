using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MJ_GameControl : MonoBehaviour
{
    public MJ_MenuControl _menuControl;
    public TextMeshProUGUI _pontuacaotexto;
    public Transform _panelFimGame;
    public MovePlayer _Player;

    [SerializeField] Transform _groundBase;
    [SerializeField] float _groundH;
    [SerializeField] float _distance;
    [SerializeField] bool _checkGroundCount;
    [SerializeField] float _posx;
    [SerializeField] int _ultimoSort = -1;

    public bool _fimGame;
    public bool certo;

    public int pontuacao;
    public int _groundNumber;

    private void Start()
    {
        _groundH = _groundBase.position.y;

        Invoke("GroundTime", 0.25f);

        _panelFimGame.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (pontuacao == _groundNumber)
        {
            certo = true;
        }
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

    void GroundStart()
    {
        GameObject bullet = MJ_GroundPool._groundPool.GetPooledObject();

        if (bullet != null)
        {
            bullet.SetActive(true);

            float posx1 = bullet.transform.position.x + _posx;
            float posx2 = bullet.transform.position.x - _posx;

            int sort;
            do
            {
                sort = Random.Range(0, 2);
            }
            while (sort == _ultimoSort); // evita repetição

            _ultimoSort = sort;

            if (sort == 0)
            {
                bullet.transform.position = new Vector2(posx1, _groundH + _distance);
            }
            else
            {
                bullet.transform.position = new Vector2(posx2, _groundH + _distance);
            }

            _groundH = bullet.transform.position.y;

            bullet.SetActive(true);
        }
    }

    IEnumerator TimeFimGame() // tempo para chamar o fim de jogo
    {
        // desativar o player
        yield return new WaitForSeconds(1);
        // chamar o painel reiniciar jogo
    }

    public void ResetarCena(string Cena)
    {
        SceneManager.LoadScene(Cena);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJ_Enemy : MonoBehaviour
{
    [SerializeField] float _Speed = 2f;
    [SerializeField] float _scaleX = 1f;
    [SerializeField] bool _dir, _isDead = false;

    MJ_GameControl _gameControl;
    Rigidbody2D _Rg;

    void Start()
    {
        float[] valores = { 1f, 2f, 3f };
        _Speed = valores[Random.Range(0, valores.Length)];
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        _Rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_isDead) return; 

        _Rg.linearVelocity = new Vector2(_Speed, _Rg.linearVelocity.y);

        // Ajusta visualmente a direção do inimigo (flip)
        if (_Speed > 0)
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(-_scaleX, transform.localScale.y, transform.localScale.z);

     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco") && !_dir)
        {
            Debug.Log("Colidiu com o bloco!");
            _Speed *= -1;
            _dir = true;
            Invoke("TimerDir", 0.2f); // tempo menor já basta
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Dead();
            
            
        }
    }

    void TimerDir()
    {
        _dir = false;
    }

    void Dead()
    {

        _isDead = true;
        _gameControl._gameStay = false;
            _gameControl._fimGame = true;

            _gameControl._panelFimGame.gameObject.SetActive(true);
            _gameControl._panelFimGame.transform.localScale = Vector3.one;

            _gameControl.GameStay(false);

    }
}

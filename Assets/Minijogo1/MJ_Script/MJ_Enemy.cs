using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJ_Enemy : MonoBehaviour
{
    [SerializeField] float _scaleX = 1f;
    public bool _dir = false;
    Rigidbody2D _rg;
    Animator _enemyAnim;
    float[] valores = { 1f, 2f, 3f };
    float _Speed;
    int ultimoIndex = -1;


    void Start()
    {
        SortearNovoSpeed();
        _rg = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        _rg.linearVelocity = new Vector2(_Speed, _rg.linearVelocity.y);

        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco") && !_dir)
        {
            //Debug.Log("Colidiu com o bloco!");
            _Speed *= -1;
            _dir = true;
            Invoke("TimerDir", 0.2f);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //print("O inimigo esta morto");
            EnemyDead();
            
        }
    }

    void TimerDir()
    {
        _dir = false;
    }

    public void EnemyDead()
    {

        _rg.bodyType = RigidbodyType2D.Kinematic;
        _rg.linearVelocity = Vector2.zero;
        _Speed *= 0;
       // _enemyAnim.enabled = false; 

    }

    private void Flip()
    {
        // Ajusta visualmente a direção do inimigo (flip)
        if (_Speed > 0)
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(-_scaleX, transform.localScale.y, transform.localScale.z);
    }

    void SortearNovoSpeed()
    {
        int novoIndex;

        do
        {
            novoIndex = Random.Range(0, valores.Length);
        } while (novoIndex == ultimoIndex && valores.Length > 1); // repete até ser diferente

        _Speed = valores[novoIndex];
        ultimoIndex = novoIndex;
    }
}

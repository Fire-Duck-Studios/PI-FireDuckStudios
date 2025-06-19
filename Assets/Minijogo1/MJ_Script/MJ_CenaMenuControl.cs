using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class MJ_CenaMenuControl : MonoBehaviour
{

    //[SerializeField] Transform _panelCreditos;
    [SerializeField] Transform[] _painelStart;
    [SerializeField] Transform[] _painelCreditos;


    public void Start()
    {
        
        for (int i = 0; i < _painelStart.Length; i++)
        {
            _painelStart[i].localScale = Vector3.zero;
        }
        for (int i = 0; i < _painelCreditos.Length; i++)
        {
            _painelCreditos[i].localScale = Vector3.zero;
        }

        PainelStartCheck(true);

    }

    public void PainelStartCheck(bool CheckON)
    {
        if (CheckON == true)
        {
            StartCoroutine(TimeStart());
        }
        else
        {
            PainelStartOff();
        }
    }

    IEnumerator TimeStart()
    {
        for (int i = 0; i < _painelStart.Length; i++)
        {
            _painelStart[i].DOScale(2f, .25f);
            yield return new WaitForSeconds(0.25f);
            _painelStart[i].DOScale(1, .25f);
        }
    }

    IEnumerator TimeCreditos()
    {
        for (int i = 0; i < _painelCreditos.Length; i++)
        {
            _painelCreditos[i].DOScale(1.5f, .25f);
            yield return new WaitForSeconds(0.25f);
            _painelCreditos[i].DOScale(1, .25f);
        }
    }
    public void PainelStartOff()
    {
        for (int i = 0; i < _painelStart.Length; i++)
        {
            _painelStart[i].DOScale(0, .25f);
        }
    }

    public void CenaGame()
    {
        SceneManager.LoadScene("MiniJogo1");
    }

    public void PainelCreditosCheck(bool CheckON)
    {
        if (CheckON == true)
        {
            StartCoroutine(TimeCreditos());
        }
        else
        {
            PainelConfigtOff();
        }
    }

    public void PainelConfigtOff()
    {
        for (int i = 0; i < _painelCreditos.Length; i++)
        {
            _painelCreditos[i].DOScale(0, .25f);
        }
    }

    public void Kitar()
    {
        //Debug.Log("KITAR");
        Application.Quit();
    }
}

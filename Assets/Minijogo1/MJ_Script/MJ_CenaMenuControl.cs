using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class MJ_CenaMenuControl : MonoBehaviour
{

    //[SerializeField] Transform _panelCreditos;
    [SerializeField] Transform[] _painelStart;
    [SerializeField] Transform[] _painelCreditos;
    [SerializeField] Transform[] _logo;
    [SerializeField] Transform _posLogo;


    public void Start()
    {
        _posLogo = GetComponent<Transform>();
        
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
            StartCoroutine(TimeAnimarLgo());
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

    IEnumerator TimeAnimarLgo()
    { 
        for (int i = 0; i < _logo.Length; i++)
        {
                _logo[i].DOLocalJump(new Vector3(0, 0, 0), 100, 3, 3f, false);
                yield return new WaitForSeconds(2f);
                
        }
    }


    public void PainelStartOff()
    {
        for (int i = 0; i < _painelStart.Length; i++)
        {
            _painelStart[i].DOScale(0, .25f);
        }

        for (int i = 0; i < _logo.Length; i++)
        {
            _logo[i].DOScale(0, .25f);


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

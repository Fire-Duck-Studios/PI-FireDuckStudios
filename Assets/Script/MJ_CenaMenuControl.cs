using UnityEngine;
using UnityEngine.SceneManagement;

public class MJ_CenaMenuControl : MonoBehaviour
{

    [SerializeField] Transform _panelCreditos;


    public void Start()
    {
        _panelCreditos.localScale = new Vector3(0, 0, 0);
    }
    public void CenaGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void CreditosOpen()
    {
        _panelCreditos.localScale = new Vector3(1, 1, 1);
    }

    public void CreditosClose()
    {
        _panelCreditos.localScale = new Vector3(0, 0, 0);
    }

    public void Kitar()
    {
        //Debug.Log("KITAR");
        Application.Quit();
    }
}

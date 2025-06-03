using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public float duration = 30f; // tempo total dos créditos

    void Start()
    {
        Invoke("CarregarCena", duration);
    }

    void CarregarCena()
    {
        SceneManager.LoadScene("Menu"); // Troque "Menu" pelo nome real da cena
    }
}

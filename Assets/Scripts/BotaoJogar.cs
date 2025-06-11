using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoJogar : MonoBehaviour
{
    public AudioSource audioSource;  // arraste aqui no inspetor

    public void TocarSomEIniciar()
    {
        audioSource.Play();

        // Opcional: carregar a cena depois do som (com pequeno delay)
        Invoke("CarregarCena", audioSource.clip.length);
    }

    void CarregarCena()
    {
        SceneManager.LoadScene("NomeDaSuaCena"); // substitua pelo nome real da cena
    }
}

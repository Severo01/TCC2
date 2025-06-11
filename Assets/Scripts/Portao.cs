using UnityEngine;
using UnityEngine.SceneManagement;

public class Portao : MonoBehaviour
{
    [Tooltip("Nome exato da cena atual para reiniciar caso o jogador não tenha coletado a nota.")]
    public string nomeDaCenaAtual;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimento movimento = other.GetComponent<Movimento>();
            if (movimento != null)
            {
                if (movimento.pegouNota)
                {
                    // Jogador pegou a nota, desbloqueia o caminho
                    gameObject.SetActive(false);
                }
                else
                {
                    // Jogador não pegou a nota, reinicia a fase
                    SceneManager.LoadScene(nomeDaCenaAtual);
                }
            }
        }
    }
}


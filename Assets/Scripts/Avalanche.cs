using UnityEngine;

public class Avalanche : MonoBehaviour
{
    public Transform alvo;           // Jogador
    public float velocidade = 3f;
    public float delay = 2f;

    public bool podeSeguir = false;
    //private Vector3 direcaoFixa;

    void Start()
    {
        //Invoke("CalcularDirecao", delay);
        Invoke("Comecar", delay);
    }

    void Update()
    {
        /*
        if (podeSeguir)
        {
            transform.position += direcaoFixa * velocidade * Time.deltaTime;
        }
        */

        //Seguir para a direita
        if (podeSeguir)
            transform.position += Vector3.right * velocidade * Time.deltaTime;
    }

    void Comecar()
    {
        podeSeguir = true;
    }

    /*
    void CalcularDirecao()
    {
        if (alvo != null)
        {
            // Garante que o inimigo siga só no plano horizontal (ignora diferença no Y)
            Vector3 alvoPosicaoNivelada = new Vector3(alvo.position.x, transform.position.y, alvo.position.z);
            direcaoFixa = (alvoPosicaoNivelada - transform.position).normalized;
            podeSeguir = true;
        }
    }
    */
}

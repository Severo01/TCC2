using UnityEngine;

public class Avalanche : MonoBehaviour
{
    public Transform alvo;           // Jogador
    public float velocidade = 3f;
    public float delay = 2f;

    private bool podeSeguir = false;
    private Vector3 direcaoFixa;

    void Start()
    {
        Invoke("CalcularDirecao", delay);
    }

    void Update()
    {
        if (podeSeguir)
        {
            transform.position += direcaoFixa * velocidade * Time.deltaTime;
        }
    }

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
}

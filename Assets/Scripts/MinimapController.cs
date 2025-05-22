using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform jogador;
    public Transform inimigo;
    public Transform destinoFinal;

    public RectTransform barraProgresso;
    public RectTransform iconeJogador;
    public RectTransform iconeInimigo;

    private float distanciaTotal;

    void Start()
    {
        distanciaTotal = Vector3.Distance(jogador.position, destinoFinal.position);
    }

    void Update()
    {
        AtualizarIcone(iconeJogador, jogador);
        AtualizarIcone(iconeInimigo, inimigo);
    }

    void AtualizarIcone(RectTransform icone, Transform alvo)
    {
        float distanciaAtual = Vector3.Distance(alvo.position, destinoFinal.position);
        float progresso = 1f - (distanciaAtual / distanciaTotal);
        progresso = Mathf.Clamp01(progresso);

        float largura = barraProgresso.rect.width;
        Vector3 novaPos = new Vector3(progresso * largura, icone.localPosition.y, 0);
        icone.localPosition = novaPos;
    }
}

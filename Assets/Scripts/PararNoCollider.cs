using UnityEngine;

public class PararNoCollider : MonoBehaviour
{
    public GameObject objetoParaParar;
    private Rigidbody rb;
    private Avalanche avalancheScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        avalancheScript = GetComponent<Avalanche>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objetoParaParar)
        {
            Debug.Log("Colidiu com o objeto certo! Parando...");
            rb.velocity = Vector3.zero;
            avalancheScript.velocidade = 0f;
            avalancheScript.podeSeguir = false;
        }
    }
}


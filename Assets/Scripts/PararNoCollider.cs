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
        if (collision.gameObject.Equals(objetoParaParar))
        {
            Debug.Log("Colidiu com o objeto certo! Parando...");
            avalancheScript.podeSeguir = false;
        }
    }
}


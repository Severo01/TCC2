using UnityEngine;

public class PararNoCollider : MonoBehaviour
{
    public GameObject objetoParaParar;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objetoParaParar)
        {
            Debug.Log("Colidiu com o objeto certo! Parando...");
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }
}



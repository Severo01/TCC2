using UnityEngine;

public class PararAvalanche : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Avalanche")
        {
            Debug.Log("PARRROOOOOOO");
            Avalanche avalancheScript = other.gameObject.GetComponent<Avalanche>();
            avalancheScript.velocidade = 0.0f;
        }
    }
}

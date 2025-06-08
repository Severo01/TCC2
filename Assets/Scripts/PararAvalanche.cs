using UnityEngine;

public class PararAvalanche : MonoBehaviour
{
    [SerializeField] private GameObject refAvalanche;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(refAvalanche))
        {
            Debug.Log("PARRROOOOOOO");
            Avalanche avalancheScript = refAvalanche.GetComponent<Avalanche>();
            avalancheScript.podeSeguir = false;
            ParticleSystem sistemaParticula = refAvalanche.GetComponentInChildren<ParticleSystem>();
            var spEmission = sistemaParticula.emission;
            spEmission.enabled = false;
        }
    }
}

using UnityEngine;

public class PararAvalanche : MonoBehaviour
{
    [SerializeField] private GameObject refAvalanche;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(refAvalanche))
        {
            Debug.Log("PARRROOOOOOO");
            Avalanche avalancheScript = other.gameObject.GetComponent<Avalanche>();
            avalancheScript.podeSeguir = false;
        }
    }
}

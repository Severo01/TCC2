using UnityEngine;

public class Coletores : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<MusicLayerManager>().AddLayer();
            Destroy(gameObject);
        }
    }
}

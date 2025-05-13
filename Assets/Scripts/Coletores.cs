using UnityEngine;

public class Coletores : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<MusicLayerManager>().AddLayer();
            Destroy(gameObject);
        }
    }
}

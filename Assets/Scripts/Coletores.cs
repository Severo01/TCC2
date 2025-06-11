using UnityEngine;

public class Coletores : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<MusicLayerManager>().AddLayer();

             Movimento movimento = other.GetComponent<Movimento>();
            if (movimento != null)
            {
             movimento.pegouNota = true;
            }

            Destroy(gameObject);
        }
    }

}

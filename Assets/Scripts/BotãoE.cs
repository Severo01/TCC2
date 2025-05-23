using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject pressEMessage; // Um texto UI que será ativado/desativado

    private bool playerInside = false;

    void Start()
    {
        if (pressEMessage != null)
            pressEMessage.SetActive(false);
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressionado! Interação feita.");
            // Aqui você pode colocar qualquer ação: abrir porta, pegar item etc.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (pressEMessage != null)
                pressEMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            if (pressEMessage != null)
                pressEMessage.SetActive(false);
        }
    }
}

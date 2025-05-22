using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckpointTrigger : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialogueUI;
    public GameObject promptUI;

    [Header("Elementos de Diálogo")]
    public TMP_Text speakerNameText;     // Nome do personagem
    public TMP_Text dialogueLineText;    // Fala do personagem

    [Header("Diálogo")]
    public string[] speakerNames;        // Lista de nomes (mesmo tamanho que dialogueLines)
    public string[] dialogueLines;       // Lista de falas
    public float delayBeforeNextScene = 2f;

    [Header("Cena")]
    public string nextSceneName;

    private int messageIndex = 0;
    private bool playerInZone = false;
    private bool dialogueActive = false;

    void Start()
    {
        dialogueUI.SetActive(false);
        promptUI.SetActive(false);
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextMessage();
        }
    }

    private void ShowNextMessage()
    {
        if (!dialogueActive)
        {
            dialogueActive = true;
            dialogueUI.SetActive(true);
            promptUI.SetActive(false);
        }

        if (messageIndex < dialogueLines.Length && messageIndex < speakerNames.Length)
        {
            speakerNameText.text = speakerNames[messageIndex];
            dialogueLineText.text = dialogueLines[messageIndex];
            messageIndex++;
        }
        else
        {
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    private System.Collections.IEnumerator LoadNextSceneAfterDelay()
    {
        dialogueUI.SetActive(false);
        yield return new WaitForSeconds(delayBeforeNextScene);
        SceneManager.LoadScene(nextSceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (!dialogueActive)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            promptUI.SetActive(false);
        }
    }
}


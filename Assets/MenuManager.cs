using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MenuFases;
    [SerializeField] private GameObject MenuCreditos;
    [SerializeField] private GameObject MenuConfig;

    [Header("Slider de Volume")]
    [SerializeField] private Slider sliderVolume;

    void Start()
    {
        // Carrega volume salvo (padrão = 1.0)
        float volumeSalvo = PlayerPrefs.GetFloat("volume", 1f);

        // Evita volume 0 absoluto
        if (volumeSalvo < 0.05f)
            volumeSalvo = 0.05f;

        AudioListener.volume = volumeSalvo;

        // Atualiza valor do slider
        if (sliderVolume != null)
            sliderVolume.value = volumeSalvo;
    }

    void Update()
    {
        // Tecla ESC retorna ao menu principal
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }


    public void AbrirFases()
    {
        Menu.SetActive(false);
        MenuFases.SetActive(true);
        MenuConfig.SetActive(false);
        MenuCreditos.SetActive(false);
    }

    public void VoltarMenu()
    {
        Menu.SetActive(true);
        MenuFases.SetActive(false);
        MenuConfig.SetActive(false);
        MenuCreditos.SetActive(false);
    }

    public void AbrirConfig()
    {
        Menu.SetActive(false);
        MenuFases.SetActive(false);
        MenuConfig.SetActive(true);
        MenuCreditos.SetActive(false);
    }

    public void AbrirCreditos()
    {
        //Menu.SetActive(false);
        //MenuFases.SetActive(false);
        //MenuConfig.SetActive(false);
        //MenuCreditos.SetActive(true);
        SceneManager.LoadScene("Creditos");
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void FasesOutono()
    {
        SceneManager.LoadScene("Outono");
    }

    public void FasesInverno()
    {
        SceneManager.LoadScene("Inverno2");
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }

    public void AjustarVolume()
    {
        float volume = sliderVolume.value;
        if (volume < 0.05f)
            volume = 0.05f;

        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void ResetarVolume()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioListener.volume = 1f;

        if (sliderVolume != null)
            sliderVolume.value = 1f;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFuncoes : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuOpcoes;

    [Header("Slider de Volume")]
    [SerializeField] private Slider sliderVolume;

    void Start()
    {
        // Carrega volume salvo (padrão = 1.0)
        float volumeSalvo = PlayerPrefs.GetFloat("volume", 1f);

        // Evita volume 0 absoluto (som sumiria por completo)
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

    public void Jogar()
    {
        SceneManager.LoadScene("Inverno2");
    }

    public void Outono()
    {
        SceneManager.LoadScene("Outono");
    }

    public void SairJogo()
    {
        SceneManager.LoadScene("Menu");
    }

    public void AbrirOpcoes()
    {
        MenuPrincipal.SetActive(false);
        MenuOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        MenuOpcoes.SetActive(false);
        MenuPrincipal.SetActive(true);
    }

    public void AjustarVolume(float volume)
    {
        // Evita zerar completamente
        if (volume < 0.05f)
            volume = 0.05f;

        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume); // Salva
    }

    // (Opcional) Botão para resetar configurações
    public void ResetarVolume()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioListener.volume = 1f;

        if (sliderVolume != null)
            sliderVolume.value = 1f;
    }
}

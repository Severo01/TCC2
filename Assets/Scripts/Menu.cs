using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFuncoes : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuOpcoes;
    [SerializeField] private GameObject Creditos;

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

    public void Jogar()
    {
        SceneManager.LoadScene("Outono");
    }

    public void AbrirCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Inverno()
    {
        SceneManager.LoadScene("Inverno");
    }

    public void SairJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
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

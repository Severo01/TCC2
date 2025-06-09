using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFuncoes : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject PainelOpcoes;
     [SerializeField] private GameObject MenuConfig;

    [Header("Slider de Volume")]
    [SerializeField] private Slider sliderVolume;

    private bool jogoPausado = false;

    void Start()
    {
        // Garante que o painel de opções está fechado no início
        if (PainelOpcoes != null)
            PainelOpcoes.SetActive(false);

        // Carrega volume salvo (padrão = 1.0)
        float volumeSalvo = PlayerPrefs.GetFloat("volume", 1f);
        if (volumeSalvo < 0.05f)
            volumeSalvo = 0.05f;

        AudioListener.volume = volumeSalvo;

        if (sliderVolume != null)
            sliderVolume.value = volumeSalvo;
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
        {
        // Se estiver no MenuConfig, volta para o PainelOpcoes
        if (MenuConfig.activeSelf)
            {
            MenuConfig.SetActive(false);
            PainelOpcoes.SetActive(true);
            }
        // Se estiver no PainelOpcoes, fecha tudo e volta ao jogo
        else if (PainelOpcoes.activeSelf)
            {
            RetomarJogo();
            }
        // Se nada estiver aberto, abre o menu de pausa
        else
            {
            AbrirMenuPausa();
            }
        }
    }


      public void AbrirConfig()
    {
        if (PainelOpcoes != null)
        PainelOpcoes.SetActive(false);
        MenuConfig.SetActive(true);
    }

    public void VoltarParaOpcoes()
    {
    MenuConfig.SetActive(false);
    PainelOpcoes.SetActive(true);
    }

    public void AbrirMenuPausa()
    {
        if (PainelOpcoes != null)
            PainelOpcoes.SetActive(true);

        Time.timeScale = 0f; // Pausa o jogo
        jogoPausado = true;
    }

    public void RetomarJogo()
    {
        if (PainelOpcoes != null)
            PainelOpcoes.SetActive(false);

        Time.timeScale = 1f; // Continua o jogo
        jogoPausado = false;
    }

    public void SairParaMenu()
    {
        Time.timeScale = 1f; // Garante que o tempo volte ao normal
        SceneManager.LoadScene("Menu");
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
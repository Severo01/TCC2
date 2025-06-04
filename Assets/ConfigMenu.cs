using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicaPrincipal;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeMusica", 1f);
        musicaPrincipal.volume = volumeSlider.value;

        volumeSlider.onValueChanged.AddListener(delegate { AtualizarVolume(); });
    }

    public void AtualizarVolume()
    {
        float novoVolume = volumeSlider.value;
        musicaPrincipal.volume = novoVolume;
        PlayerPrefs.SetFloat("volumeMusica", novoVolume);
    }
}

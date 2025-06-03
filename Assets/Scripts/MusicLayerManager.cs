using UnityEngine;

public class MusicLayerManager : MonoBehaviour
{
    public AudioSource[] musicLayers;  // arraste os AudioSources aqui
    private int currentLayer = 0;
    private float savedVolume;

    void Start()
    {
        savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        // Toca todas as faixas com volume 0, para sincronizar desde o início
        foreach (AudioSource layer in musicLayers)
        {
            layer.volume = 0f;
            layer.Play();
        }
    }

    public void AddLayer()
    {
        if (currentLayer < musicLayers.Length)
        {
            musicLayers[currentLayer].volume = savedVolume;
            currentLayer++;
        }
    }
}

using UnityEngine;

public class MusicLayerManager : MonoBehaviour
{
    public AudioSource[] musicLayers;  // arraste os AudioSources aqui
    private int currentLayer = 0;

    void Start()
    {
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
            musicLayers[currentLayer].volume = 1f;
            currentLayer++;
        }
    }
}

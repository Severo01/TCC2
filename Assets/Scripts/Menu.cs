using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFuncoes : MonoBehaviour
{   
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenuOpcoes;

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
        AudioListener.volume = volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}


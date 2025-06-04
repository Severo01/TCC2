using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MenuFases;

    [SerializeField] private GameObject MenuConfig;

    public void AbrirFases()
    {
        Menu.SetActive(false);
        MenuFases.SetActive(true);
        MenuConfig.SetActive(false);
    }

    public void VoltarMenu()
    {
        MenuFases.SetActive(false);
        Menu.SetActive(true);
        MenuConfig.SetActive(false);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("NomeDaCenaJogo");
    }

    public void AbrirConfig()
    {
        MenuFases.SetActive(false);
        Menu.SetActive(false);
        MenuConfig.SetActive(true);
    }
}

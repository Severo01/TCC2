using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    public float waitTime = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Movimento>())
        {
            Destroy(collision.gameObject);
            Invoke("ResetGame", waitTime);
        }      
    }





    
    private void ResetGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}

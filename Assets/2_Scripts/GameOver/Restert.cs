using UnityEngine;
using UnityEngine.SceneManagement;

public class Restert : MonoBehaviour
{
    public void ReClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Out()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("³ª°¨");
            Application.Quit();
        }
    }
}

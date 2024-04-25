using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("눌림");
        SceneManager.LoadScene("GameScene");
    }

    public void EixtOnClick()
    {
        Debug.Log("나가기 눌림");
        Application.Quit();
    }
}

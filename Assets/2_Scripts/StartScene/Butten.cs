using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("����");
        SceneManager.LoadScene("GameScene");
    }

    public void EixtOnClick()
    {
        Debug.Log("������ ����");
        Application.Quit();
    }
}

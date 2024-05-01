using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    public void OnClick()
    {
        //게임 화면으로
        SceneManager.LoadScene("GameScene");
    }

    public void EixtOnClick()
    {
        //게임 이탈
        Debug.Log("나가기 눌림");
        Application.Quit();
    }

    public void MainOnClick()
    {
        //스타트 화면으로 돌아기기
        SceneManager.LoadScene("StartScene");
    }

    public void CreditOnClick()
    {
        //크레딧 화면으로 돌아기기
        SceneManager.LoadScene("Credit");
    }

    public void TutorialClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

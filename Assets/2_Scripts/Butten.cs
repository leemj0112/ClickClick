using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    public void OnClick()
    {
        //���� ȭ������
        SceneManager.LoadScene("GameScene");
    }

    public void EixtOnClick()
    {
        //���� ��Ż
        Debug.Log("������ ����");
        Application.Quit();
    }

    public void MainOnClick()
    {
        //��ŸƮ ȭ������ ���Ʊ��
        SceneManager.LoadScene("StartScene");
    }
}

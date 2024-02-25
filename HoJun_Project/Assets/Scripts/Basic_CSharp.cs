using UnityEngine;
using System.Collections;

public class Basic_CSharp : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // �ڷ�ƾ �Լ�
    IEnumerator MyCoroutine()
    {
        Debug.Log("�ڷ�ƾ ����");

        // 1�� ���
        yield return new WaitForSeconds(1f);

        Debug.Log("1�ʰ� ����");

        // ���� �����ӱ��� ���
        yield return null;

        Debug.Log("���� ������");

        // 2�� ���
        yield return new WaitForSeconds(2f);

        Debug.Log("����� �ð��� ����");

        // �ڷ�ƾ ����
        yield break;
    }


    // ���� �Լ�
    private void Main()
    {
        // ������ ����
        PlayerPrefs.SetInt("HighScore", 10000);
        PlayerPrefs.SetString("PlayerName", "John");

        // ������ �ҷ�����
        int highScore = PlayerPrefs.GetInt("HighScore");
        string playerName = PlayerPrefs.GetString("PlayerName");

        Debug.Log("High Score: " + highScore);
        Debug.Log("Player Name: " + playerName);
    }
}

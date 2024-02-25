using UnityEngine;
using System.Collections;

public class Basic_CSharp : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    // 코루틴 함수
    IEnumerator MyCoroutine()
    {
        Debug.Log("코루틴 시작");

        // 1초 대기
        yield return new WaitForSeconds(1f);

        Debug.Log("1초가 지남");

        // 다음 프레임까지 대기
        yield return null;

        Debug.Log("다음 프레임");

        // 2초 대기
        yield return new WaitForSeconds(2f);

        Debug.Log("충분한 시간이 지남");

        // 코루틴 종료
        yield break;
    }


    // 메인 함수
    private void Main()
    {
        // 데이터 저장
        PlayerPrefs.SetInt("HighScore", 10000);
        PlayerPrefs.SetString("PlayerName", "John");

        // 데이터 불러오기
        int highScore = PlayerPrefs.GetInt("HighScore");
        string playerName = PlayerPrefs.GetString("PlayerName");

        Debug.Log("High Score: " + highScore);
        Debug.Log("Player Name: " + playerName);
    }
}

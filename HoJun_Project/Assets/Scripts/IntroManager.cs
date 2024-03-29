using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private Button _StartBtn;
    [SerializeField] private Image _FadeInImg;

    [SerializeField] private GameObject _LoadingBarObj;
    [SerializeField] private Image _FillImg;

    private void Awake()
    {
        _StartBtn.onClick.AddListener(OnClickStartBtn);
    }


    // Start 버튼 클릭시 호출
    private void OnClickStartBtn()
    {
        _FadeInImg.gameObject.SetActive(true);
        _FadeInImg.DOFade(1F, 1F).OnComplete(() => StartLoading());
    }

    
    // 로딩 바 시작
    private void StartLoading()
    {
        _LoadingBarObj.SetActive(true);
        _FillImg.fillAmount = 0;
        _FillImg.DOFillAmount(1F, 2F).SetEase(Ease.Linear)
            .OnComplete(() => LoadMainScene());
    }


    // 메인씬 로드
    private void LoadMainScene()
    {
        //SceneManager.LoadScene("02_Main");
        SceneManager.LoadScene(1);
    }
}

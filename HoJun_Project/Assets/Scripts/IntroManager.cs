using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private Button _StartBtn;
    [SerializeField] private UnityEngine.UI.Image _FadeInImg;

    [SerializeField] private GameObject _LoadingBarObj;
    [SerializeField] private UnityEngine.UI.Image _FillImg;
    

    private void Awake()
    {
        _StartBtn.onClick.AddListener(OnClickStartBtn);
    }


    // Start ��ư Ŭ���� ȣ��
    private void OnClickStartBtn()
    {
        _FadeInImg.color = Color.clear;
        _FadeInImg.gameObject.SetActive(true);
        _FadeInImg.DOFade(1F, 1F).OnComplete(() => StartLoading());
    }

    
    // �ε� �� ����
    private void StartLoading()
    {
        _LoadingBarObj.SetActive(true);
        _FillImg.fillAmount = 0;
        _FillImg.DOFillAmount(1F, 2F).SetEase(Ease.Linear)
            .OnComplete(() => LoadMainScene());
    }


    // ���ξ� �ε�
    private void LoadMainScene()
    {
        //SceneManager.LoadScene("02_Main");
        SceneManager.LoadScene(1);
    }
}

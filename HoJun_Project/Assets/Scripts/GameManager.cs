using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _HpImgs;
    [SerializeField] private TextMeshProUGUI _MoneyTxt;
    [SerializeField] private TextMeshProUGUI _DiamondTxt;

    [Header("인벤토리")]
    [SerializeField] private GameObject _InventoryObj;
    [SerializeField] private Button _InventoryBtn;

    [Header("Enmey")]
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private Transform _EnemyRespawnPos;

    [Header("테스트(0-Hp, 1-돈, 2-다이아)")]
    [SerializeField] private int _TestType;
    [SerializeField] private Button _TestIncreaseBtn;
    [SerializeField] private Button _TestDecreaseBtn;

    public static GameManager Instance { get; private set; }

    private int _MoneyCount = 10000;
    private int _DiamondCount = 100;

    private int _PlayerHp = 0;
    public int PlayerHp 
    { 
        get
        {
            return _PlayerHp; 
        }

        set
        {
            if (value < 0)
            {
                Debug.Log($"#### hp는 0이하로 내려갈수 없습니다.[{value}]");
                return; 
            }

            _PlayerHp = value;
        }
    }

    private void Awake()
    {
        // 싱글톤 패턴
        if (Instance == null)
        {
            Instance = this;
        }

        // 1.먼저 모든 Hp 이미지들을 꺼줍니다.
        Array.ForEach(_HpImgs, img => img.SetActive(false));

        // 2.앞 3개의 Hp 이미지를 켜줍니다.
        _HpImgs[0].SetActive(true);
        _HpImgs[1].SetActive(true);
        _HpImgs[2].SetActive(true);

        // 3.돈, 다이아의 갯수 txt를 초기화합니다.
        _MoneyTxt.text = $"x {_MoneyCount}";
        _DiamondTxt.text = $"x {_DiamondCount}";

        _InventoryBtn.onClick.AddListener(() =>
        {
            _InventoryObj.SetActive(true);
            SoundManager.Instance.PlayOneShop();
        });

        PlayerHp = 3;

        //// 테스트 버튼 기능연결
        //_TestIncreaseBtn.onClick.AddListener(OnClickIncreaseBtn);
        //_TestDecreaseBtn.onClick.AddListener(OnClickDecreaseBtn);
    }
   
    public void EnemyDown()
    {
        _Enemy.SetActive(false);
        _Enemy.transform.localPosition = _EnemyRespawnPos.localPosition;
        StartCoroutine(EnemyRespawn());
    }

    private IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(3F);
        _Enemy.SetActive(true);
    }

    private void OnClickIncreaseBtn()
    {
        if (_TestType == 0) // Hp 증가
        {
            for (int i = 0; i < _HpImgs.Length; i++)
            {
                if (_HpImgs[i].activeSelf == false)
                {
                    _HpImgs[i].SetActive(true);
                    break;
                }
            }
        }
        else if(_TestType == 1) // 돈 증가
        {
            _MoneyCount += 300;
            _MoneyTxt.text = $"x {_MoneyCount:n0}";
        }
        else    // 다이아 증가
        {
            _DiamondCount += 5;
            _DiamondTxt.text = $"x {_DiamondCount}";
        }
    }

    public void DecreaseHudValue(int type)
    {
        if (type == 0) // Hp 감소
        {
            for (int i = (_HpImgs.Length - 1); i >= 0; i--)
            {
                if (_HpImgs[i].activeSelf == true)
                {
                    _HpImgs[i].SetActive(false);
                    break;
                }
            }
        }
        else if (type == 1) // 돈 감소
        {
            _MoneyCount -= 200;
            if (_MoneyCount <= 0)
            {
                _MoneyCount = 0;
            }
            _MoneyTxt.text = $"x {_MoneyCount:n0}";
        }
        else    // 다이아 감소
        {
            _DiamondCount -= 3;
            if (_DiamondCount <= 0)
            {
                _DiamondCount = 0;
            }
            _DiamondTxt.text = $"x {_DiamondCount}";
        }
    }
}
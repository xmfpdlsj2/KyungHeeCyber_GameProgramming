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

    [Header("�κ��丮")]
    [SerializeField] private GameObject _InventoryObj;
    [SerializeField] private Button _InventoryBtn;

    [Header("Enmey")]
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private Transform _EnemyRespawnPos;

    [Header("�׽�Ʈ(0-Hp, 1-��, 2-���̾�)")]
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
                Debug.Log($"#### hp�� 0���Ϸ� �������� �����ϴ�.[{value}]");
                return; 
            }

            _PlayerHp = value;
        }
    }

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
        }

        // 1.���� ��� Hp �̹������� ���ݴϴ�.
        Array.ForEach(_HpImgs, img => img.SetActive(false));

        // 2.�� 3���� Hp �̹����� ���ݴϴ�.
        _HpImgs[0].SetActive(true);
        _HpImgs[1].SetActive(true);
        _HpImgs[2].SetActive(true);

        // 3.��, ���̾��� ���� txt�� �ʱ�ȭ�մϴ�.
        _MoneyTxt.text = $"x {_MoneyCount}";
        _DiamondTxt.text = $"x {_DiamondCount}";

        _InventoryBtn.onClick.AddListener(() =>
        {
            _InventoryObj.SetActive(true);
            SoundManager.Instance.PlayOneShop();
        });

        PlayerHp = 3;

        //// �׽�Ʈ ��ư ��ɿ���
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
        if (_TestType == 0) // Hp ����
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
        else if(_TestType == 1) // �� ����
        {
            _MoneyCount += 300;
            _MoneyTxt.text = $"x {_MoneyCount:n0}";
        }
        else    // ���̾� ����
        {
            _DiamondCount += 5;
            _DiamondTxt.text = $"x {_DiamondCount}";
        }
    }

    public void DecreaseHudValue(int type)
    {
        if (type == 0) // Hp ����
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
        else if (type == 1) // �� ����
        {
            _MoneyCount -= 200;
            if (_MoneyCount <= 0)
            {
                _MoneyCount = 0;
            }
            _MoneyTxt.text = $"x {_MoneyCount:n0}";
        }
        else    // ���̾� ����
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
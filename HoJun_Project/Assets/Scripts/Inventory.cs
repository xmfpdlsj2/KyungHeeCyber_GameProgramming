using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _ItemParent;
    [SerializeField] private GameObject _ItemPrefab;
    [SerializeField] private Button _CloseBtn;


    private const int MAX_ITEM_COUNT = 100;

    private List<GameObject> _itemList = new List<GameObject>();

    private void Awake()
    {
        _CloseBtn.onClick.AddListener(OnClickCloseBtn);
        Initialize();
    }


    private void Initialize()
    {
        // 아이템 pool 100개 생성
        for (int i = 0; i < MAX_ITEM_COUNT; i++)
        {
            var instance = Instantiate(_ItemPrefab, _ItemParent);
            var image = instance.GetComponent<Image>();
            image.color = new Color(Random.Range(0F, 1F),
                Random.Range(0F, 1F),
                Random.Range(0F, 1F));
            _itemList.Add(instance);
        }
    }


    private void OnClickCloseBtn()
    {
        this.gameObject.SetActive(false);
    }
}

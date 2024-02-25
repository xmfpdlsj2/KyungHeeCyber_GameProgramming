using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Image LockImg;
    [SerializeField] private Button OnOffBtn;

    private void Awake()
    {
        OnOffBtn.onClick.AddListener(OnClickOnOffButton);
    }

    private void OnClickOnOffButton()
    {
        if (LockImg.isActiveAndEnabled == true)
        {
            // LockImg�� �����ִٸ�
            LockImg.gameObject.SetActive(false);
        }
        else
        {
            // LockImg�� �����ִٸ�
            LockImg.gameObject.SetActive(true);
        }
    }
}
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
            // LockImg가 켜져있다면
            LockImg.gameObject.SetActive(false);
        }
        else
        {
            // LockImg가 꺼져있다면
            LockImg.gameObject.SetActive(true);
        }
    }
}

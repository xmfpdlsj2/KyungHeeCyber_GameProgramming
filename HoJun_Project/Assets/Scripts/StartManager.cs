using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Image LockImg;
    [SerializeField] private Button OnOffBtn;

    private void Awake()
    {
        OnOffBtn.onClick.AddListener(OnClickStartBtn);
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


    private void OnClickStartBtn()
    {
        SceneManager.LoadScene("02_Main");
    }
}

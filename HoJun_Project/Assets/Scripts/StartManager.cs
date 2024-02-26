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
            // LockImg�� �����ִٸ�
            LockImg.gameObject.SetActive(false);
        }
        else
        {
            // LockImg�� �����ִٸ�
            LockImg.gameObject.SetActive(true);
        }
    }


    private void OnClickStartBtn()
    {
        SceneManager.LoadScene("02_Main");
    }
}

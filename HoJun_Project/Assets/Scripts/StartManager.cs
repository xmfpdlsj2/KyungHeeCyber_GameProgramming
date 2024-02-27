using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Image fadeImg;

    private void Awake()
    {
        startBtn.onClick.AddListener(OnClickStartBtn);
    }


    private void OnClickStartBtn()
    {
        SceneManager.LoadScene("02_Main");
    }
}

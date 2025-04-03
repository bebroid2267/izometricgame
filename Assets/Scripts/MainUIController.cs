using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public Button PlayButton;
    public Button SoundEnable;

    void Start()
    {
        PlayButton.onClick.AddListener(HidePanel);
        SoundEnable.onClick.AddListener(GameManager.Instance.SoundManager.ToggleSound);
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }
}

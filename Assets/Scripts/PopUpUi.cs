using TMPro;
using UnityEngine;

public class PopUpUi : MonoBehaviour
{
    public TextMeshProUGUI brainsText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI pharmacyText;
    public TextMeshProUGUI productsText;

    public GameObject panel;
    private PlayerResources playerResources;

    void Start()
    {
        playerResources = GameManager.Instance.PlayerResources;
        playerResources.OnResourceUpdated += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        playerResources.OnResourceUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        if (playerResources == null) return;

        brainsText.text = $"{GetResourceValue("������")} /25";
        pharmacyText.text = $"{GetResourceValue("�����������")} /25";
        waterText.text = $"{GetResourceValue("����")} /25";
        weaponText.text = $"{GetResourceValue("������")} /25";
        productsText.text = $"{GetResourceValue("��������")} /25";
    }

    private int GetResourceValue(string key)
    {
        return playerResources.resources.TryGetValue(key, out int value) ? value : 0;
    }

    public void ShowPopup()
    {
        panel.SetActive(true);
    }

    public void HidePopup()
    {
        panel.SetActive(false);
    }
}

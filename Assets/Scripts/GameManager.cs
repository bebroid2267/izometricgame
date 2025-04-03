using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public IndustryController IndustryController;
    public PlayerResources PlayerResources;
    public PopUpUi PopupController;
    public SoundManager SoundManager;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

}

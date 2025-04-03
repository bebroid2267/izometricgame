using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private bool isSoundOn;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1; // 1 - включен, 0 - выключен

        // Устанавливаем начальное состояние звука и кнопки
        UpdateSoundState();
    }
    public void ToggleSound()
    {
        // Инвертируем состояние звука
        isSoundOn = !isSoundOn;

        // Сохраняем состояние звука в PlayerPrefs
        PlayerPrefs.SetInt("Sound", isSoundOn ? 1 : 0);
        PlayerPrefs.Save(); // Обязательно сохраняем изменения

        // Обновляем состояние звука и кнопки
        UpdateSoundState();
    }

    void UpdateSoundState()
    {
        audioSource.mute = !isSoundOn;
    }

}

using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private bool isSoundOn;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSoundOn = PlayerPrefs.GetInt("Sound", 1) == 1; // 1 - �������, 0 - ��������

        // ������������� ��������� ��������� ����� � ������
        UpdateSoundState();
    }
    public void ToggleSound()
    {
        // ����������� ��������� �����
        isSoundOn = !isSoundOn;

        // ��������� ��������� ����� � PlayerPrefs
        PlayerPrefs.SetInt("Sound", isSoundOn ? 1 : 0);
        PlayerPrefs.Save(); // ����������� ��������� ���������

        // ��������� ��������� ����� � ������
        UpdateSoundState();
    }

    void UpdateSoundState()
    {
        audioSource.mute = !isSoundOn;
    }

}

using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Gán giá tr? ban ??u cho slider
        bgmSlider.value = bgmSource.volume;
        sfxSlider.value = sfxSource.volume;

        // L?ng nghe s? thay ??i giá tr? c?a slider
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    // B?t ho?c t?t BGM
    public void ToggleBGM(bool isOn)
    {
        bgmSource.mute = !isOn;
    }

    // B?t ho?c t?t SFX
    public void ToggleSFX(bool isOn)
    {
        sfxSource.mute = !isOn;
    }

    // Ch?nh âm l??ng BGM
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    // Ch?nh âm l??ng SFX
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----Audio Clip-----")]
    public AudioClip bgm;
    public AudioClip selectbottle;
    public AudioClip deselectbottle;
    public AudioClip swapbottles;
    public AudioClip buttonclick;
    public AudioClip win;
    public AudioClip lose;

    public static AudioManager _Instance;

    private void Awake()
    {
        // Keep bgm playing when change scene
        if (_Instance == null)
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        bgmSource.clip = bgm;
        bgmSource.loop = true; //Enable bgm looping
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
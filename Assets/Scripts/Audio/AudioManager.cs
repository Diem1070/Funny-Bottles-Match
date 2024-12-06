using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    _instance = obj.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }



    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip bgm;
    public AudioClip select;
    public AudioClip deselect;
    public AudioClip ;
       ;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
}
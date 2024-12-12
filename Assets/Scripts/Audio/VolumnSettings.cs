using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumnSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer GameAudioMixer;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        //Initialize the sliders with current volumn
        float BGMVolumn;
        float SFXVolumn;
    }
    public void SetBGMVolumn()
    {
        float volumn = BGMSlider.value;
        GameAudioMixer.SetFloat("BGM", volumn);
    }
    public void SetSFXVolumn()
    {
        float volumn = SFXSlider.value;
        GameAudioMixer.SetFloat("SFX", volumn);
    }
}

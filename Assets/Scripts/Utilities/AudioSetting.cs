using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    public AudioMixer audioMixer;
    float minAudioVolume = -60f;
    float maxAudioVolume = 0f;
    public static float currentMusicValue;
    public static float currentSFXValue;
    public static bool MuteMusic;
    public bool muteMusic
    {
        get { return MuteMusic; }
        set 
        { 
            MuteMusic = value; 
            // Call your method here
            Debug.Log($"Music non static {muteMusic} \n static {MuteMusic}");
            SetMusicVolume((MuteMusic)? 0 : 1);
        }
    }

    public static bool MuteSFX;
    public  bool muteSFX
    {
        get { return MuteSFX; }
        set 
        { 
            MuteSFX = value; 
            // Call your method here
            Debug.Log($"SFX non static {muteSFX} \n static {MuteSFX}");
            SetSFXVolume((MuteSFX)? 0 : 1);
        }
    }
    void Awake()
    {
        if (musicSlider == null){
            SetAudioVolume(SoundType.Music, currentMusicValue);
        }
        else{
            SetAudioVolume(SoundType.Music, currentMusicValue, musicSlider);
        }
        if (sfxSlider == null){
            SetAudioVolume(SoundType.SFX, currentSFXValue);
        }else{
            SetAudioVolume(SoundType.SFX, currentSFXValue, sfxSlider);
        }
        musicToggle.isOn = !MuteMusic;
        sfxToggle.isOn = !MuteSFX;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetMusicPitch(.1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetMusicPitch(.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetMusicPitch(1);
        }
    }
    public void SetMusicVolume()
    {
        float value = musicSlider.value;
        SetMusicVolume(value);
    }

    private void SetMusicVolume(float value)
    {
        currentMusicValue = AudioVolume(value);
        audioMixer.SetFloat("MusicVolume", AudioVolume(value));
    }

    public void SetMusicPitch(float value)
    {
        audioMixer.SetFloat("MusicPitch", value);
    }
    public void SetSFXVolume()
    {
        float value = sfxSlider.value;
        SetSFXVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        currentSFXValue = AudioVolume(value);
        audioMixer.SetFloat("SFXVolume", AudioVolume(value));
    }

    public void IncreaseVolume(string soundType)
    {
        switch (soundType)
        {
            case "Music":
                musicSlider.value += 0.05f;
                SetMusicVolume();
                break;
            case "SFX":
                sfxSlider.value += 0.05f;
                SetSFXVolume();
                break;
        }
    }
    public void DecreaseVolume(string soundType)
    {
        switch (soundType)
        {
            case "Music":
                musicSlider.value -= 0.05f;
                SetMusicVolume();
                break;
            case "SFX":
                sfxSlider.value -= 0.05f;
                SetSFXVolume();
                break;
        }
    }
    private void SetAudioVolume(SoundType soundType, float result, Slider audioSlider = null)
    {
        audioMixer.SetFloat(soundType.ToString(), result);
        float sliderValue = (1 / AbsoluteMinimum * result) + 1;
        if (audioSlider != null)
        {
            audioSlider.value = sliderValue;
        }
    }
    private float AudioVolume(float value) // Value range from 0 to 1
    {
        float volume = (AbsoluteMinimum * value) - AbsoluteMinimum;
        return Mathf.Clamp(volume, minAudioVolume, maxAudioVolume);
    }
    private float GetAudioVolume(float value) // Value for Min Volume to Max 0 db returning 0 to 1
    {
        return value + AbsoluteMinimum;
    }
    [System.Serializable]
    public enum SoundType
    {
        Music, SFX
    }

    float AbsoluteMinimum => Mathf.Abs(minAudioVolume);
}

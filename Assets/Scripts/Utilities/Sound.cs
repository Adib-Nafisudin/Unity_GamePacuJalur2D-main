using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup output;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}
[System.Serializable]
public class FloatValue
{
    public delegate void OnValueChanged(float newValue);
    public event OnValueChanged onValueChanged;
    private float _value;
    [SerializeField] public float Value
    {
        get { return _value; }
        set
        {
            if (_value != value)
            {
                _value = value;
                onValueChanged?.Invoke(_value);
            }
        }
    }
}
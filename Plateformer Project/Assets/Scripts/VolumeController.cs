using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// UI - Slider 컴포넌트가 있는 오브젝트에 이 클래스 부착(Add)해야한다.
/// </summary>

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public string mixerParameterName; // BGM, SFX 작성해주는 공간
    public float sliderMultiplier = 25; // ~1,0 사이의 slider value를 더 크게 줄이기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0001f;
    }

    public void SliderValue(float value)
    {        
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultiplier);
        Debug.Log(Mathf.Log10(value));
    }
    // Update is called once per frame
   
}

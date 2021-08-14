using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGMCtrl : MonoBehaviour
{
    public Slider bgmSlider;
    public AudioSource bgm;
    public Slider effSlider;
    public AudioSource eff;

    private float bgmVolume = 1.0f;
    private float effVolume = 1.0f;

    private void Start()
    {
        bgmVolume = PlayerPrefs.GetFloat("bgmVolume", 1.0f);
        bgmSlider.value = bgmVolume;
        bgm.volume = bgmSlider.value;

        effVolume = PlayerPrefs.GetFloat("effVolume", 1.0f);
        effSlider.value = effVolume;
        eff.volume = effSlider.value;
    }

    private void Update()
    {
        BGMControl();
        EffectControl();
    }

    public void BGMControl()
    {
        bgm.volume = bgmSlider.value;
        
        bgmVolume = bgmSlider.value;
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume);
    }

    public void EffectControl()
    {
        eff.volume = effSlider.value;

        effVolume = effSlider.value;
        PlayerPrefs.SetFloat("effVolume", effVolume);
    }
}

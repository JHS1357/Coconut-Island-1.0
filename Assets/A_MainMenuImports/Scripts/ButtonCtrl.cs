using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    private GameObject main;
    private GameObject levelSelect;
    private GameObject option;
    private GameObject information;

    private AudioSource audioSource;
    private int audioNum = 0;

    public AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioNum = audioClips.Length;

        main = GameObject.Find("MAIN");
        levelSelect = GameObject.Find("LEVELSELECT");
        option = GameObject.Find("OPTION");
        information = GameObject.Find("INFORMATION");

        main.SetActive(true);
        levelSelect.SetActive(false);
        option.SetActive(false);
        information.SetActive(false);
    }

    public void EffectPlay()
    {
        audioSource.clip = audioClips[Random.RandomRange(0, audioNum)];
        audioSource.Play();
    }

    public void GameStart()
    {
        EffectPlay();

        SceneManager.LoadScene("combineScene");
    }

    public void LevelSelect()
    {
        EffectPlay();

        main.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Option()
    {
        EffectPlay();

        main.SetActive(false);
        option.SetActive(true);
    }

    public void Information()
    {
        EffectPlay();

        main.SetActive(false);
        information.SetActive(true);
    }

    public void Close()
    {
        EffectPlay();

        if (option.activeInHierarchy) option.SetActive(false);
        if (levelSelect.activeInHierarchy) levelSelect.SetActive(false);
        if (information.activeInHierarchy) information.SetActive(false);
  
        main.SetActive(true);
    }
}
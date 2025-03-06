using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenuControl : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float cycleLength = 2;
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider fxSlider;
    [SerializeField] RectTransform pickMapMenu;
    

    
    
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        if (currentScene.name == "MainMenu")
        {
            MusicManager.Instance.PlayMusic("MainMenu", 0.1f);
            
            LoadVolume();
        }
        
    }
    public void StartDesertRun()
    {
        Time.timeScale = 1;
        LevelManager.Instance.LoadScene("DesertRun", "CrossFade");
        MusicManager.Instance.PlayMusic("Desert",2f);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        LevelManager.Instance.LoadScene("MainMenu", "CrossFade");
        
    }
    public void Char1Selected()
    {
        PlayerPrefs.SetInt("ChoosenChar",1);
        mainCamera.transform.DORotate(new Vector3(0,-9,0),cycleLength);
        //pickMapMenu.transform.DOMove(new Vector2(-500,50), cycleLength);
        pickMapMenu.DOAnchorPosX(500, cycleLength);


    }
    public void Char2Selected()
    {
        PlayerPrefs.SetInt("ChoosenChar",2);
        mainCamera.transform.DORotate(new Vector2(0,-123),cycleLength);
        //pickMapMenu.transform.DOMove(new Vector2(500,50), cycleLength);
        pickMapMenu.DOAnchorPosX(-500, cycleLength);
    }
    public void ResetPosCam()
    {
        mainCamera.transform.DORotate(new Vector3(0,-64,0),cycleLength);
        pickMapMenu.DOAnchorPosX(0, cycleLength);
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume",volume);
    }
    public void UpdateFXVolume(float volume)
    {
        audioMixer.SetFloat("FXVolume",volume);
    }
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("FXVolume", out float fxVolume);
        PlayerPrefs.SetFloat("FXVolume", fxVolume);
    }
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        fxSlider.value = PlayerPrefs.GetFloat("FXVolume");
    }

    
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game")]
    public PlayerController playerController;
    public List<Obstacle> obstacleList;
    public int score;
    public TMP_Text text;

    [Header("Audio Clips")]
    public AudioClip shootingSound;
    public AudioClip damageSound;
    public AudioClip destructionSound;
    public AudioClip targetHum;
    public AudioClip backgroundMusic;

    [Header("Audio Mixer")]
    public AudioMixer mainAudioMixer;

    [Header("Audio Volume")]
    public float mainVolume = 1f;
    public float musicVolume = 1f;
    public float SFXVolume = 1f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadSoundSettings();
        }
        else
        {
            Destroy(gameObject);
        }

        obstacleList = new List<Obstacle>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (score == 100)
        {
            Debug.Log("You Win!");
        }

        if (playerController != null)
        {
            if (playerController.pawn == null)
            {
                Debug.Log("You Lose!");
            }
        }

        if (text != null)
        {
            text.text = "" + score;
        }
    }

    public void LoadSoundSettings()
    {
        mainVolume = PlayerPrefs.GetFloat("MainVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        UpdateMainVolume();
        UpdateMusicVolume();
        UpdateSFXVolume();
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat("MainVolume", mainVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

        PlayerPrefs.Save();
    }

    public void UpdateMainVolume()
    {
        float volume = ConvertToDecibels(mainVolume);
        mainAudioMixer.SetFloat("MasterVolume", volume);
    }

    public void UpdateMusicVolume()
    {
        float volume = ConvertToDecibels(musicVolume);
        mainAudioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSFXVolume()
    {
        float volume = ConvertToDecibels(SFXVolume);
        mainAudioMixer.SetFloat("SFXVolume", volume);
    }

    private float ConvertToDecibels(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            return -80f;
        }

        return Mathf.Log10(sliderValue) * 20f;
    }
}
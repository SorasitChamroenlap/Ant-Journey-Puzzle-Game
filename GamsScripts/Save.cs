using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    //saved variables
        //game data section
    public bool[] stageLockStatus = new bool[19];
    public int[] stageScore = new int[19];
    public int totalScore;
    public bool pastTutorial;

        //sound data section
    public float gameMusicVolume;
    public float waterSFXVolume;
    public float beeSFXVolume;
    public float buttonClickSoundVolume;
    public float dieSFXVolume;
    public float frogSFXVolume;
    public float birdSFXVolume;
    public float foodPickupSFXVolume;

    //not saved variables
        //game data section
    public int stageIndex;
    public GameObject SelectStageBackground,LockedStageAlertText;
    public Text StageNumber,ScoreText,SummaryScoreText;
    public int score;
    public Text[] EveryStageScore = new Text[19];

        //sound data section
    public AudioSource gameMusic;
    public AudioSource waterSFX;
    public AudioSource beeSFX;
    public AudioSource buttonClickSound;
    public AudioSource dieSFX;
    public AudioSource frogSFX;
    public AudioSource birdSFX;
    public AudioSource foodPickupSFX;
    public Slider gameMusicSlider,sfxSlider;

    void Start(){
        // Initialize();
        if(SaveSystem.LoadGame() != null){
            LoadGame();
        }else{
            Initialize();
        }
        //debug
        // for(int i = 0; i < stageLockStatus.Length; i++){
        //     Debug.Log(stageLockStatus[i] + " stage " + i);
        // }
        // Debug.Log(pastTutorial);
    }
    //initialization
    public void Initialize(){
        //game data section
        pastTutorial = false;
        totalScore = 0;
        stageLockStatus[0] = false;
        stageLockStatus[1] = false;
        stageLockStatus[2] = false;
        stageScore[0] = 0;
        stageScore[1] = 0;
        stageScore[2] = 0;
        for(int i = 3; i < stageLockStatus.Length; i++){
            stageLockStatus[i] = true;
            stageScore[i] = 0;
            totalScore += stageScore[i];
        }

        //sound data section
        gameMusicVolume = 2;
        waterSFXVolume = 2;
        beeSFXVolume = 2;
        dieSFXVolume = 2;
        frogSFXVolume = 2;
        birdSFXVolume = 2;
        foodPickupSFXVolume = 2;
        buttonClickSoundVolume = 2;

        //sound slider data section
        gameMusicSlider.value = gameMusicVolume;
        sfxSlider.value = waterSFXVolume;
        SaveGame();
    }
    
    //specific functions
    public void StartGame(){
        if(pastTutorial == false){
            SceneManager.LoadScene(stageIndex+1);
        }else{
            GetEveryStageScore();
            SelectStageBackground.SetActive(true);
        }
    }
    public void UnlockAndGoToNextSatge(){
        if(score >= stageScore[stageIndex]){
            stageScore[stageIndex] = score;
        }
        stageLockStatus[stageIndex+1] = false;
        CalculateTotalScore();
        SaveGame();
        SceneManager.LoadScene(stageIndex+1);
    }
    public void PlaySelectedStage(){
        if(stageLockStatus[stageIndex] == false){
            SceneManager.LoadScene(stageIndex);
        }else{
            LockedStageAlertText.SetActive(true);
        }
    }
    public void PastTutorial(){
        pastTutorial = true;
    }
    public void GetStageNumber(){
        if(StageNumber != null){
            StageNumber.text = (SceneManager.GetActiveScene().buildIndex - 2).ToString();
        }
    }
    public void ParseScore(){
        if(ScoreText != null){
            score = int.Parse(ScoreText.text);
        }
    }
    public void GetEveryStageScore(){
        for(int i = 0; i < stageLockStatus.Length; i++){
            if(EveryStageScore[i] != null){
                EveryStageScore[i].text = stageScore[i].ToString();
            }
        }
    }
    public void CalculateTotalScore(){
        totalScore = 0;
        for(int i = 0; i < stageLockStatus.Length; i++){
            totalScore += stageScore[i];
        }
    }

    public void setGameMusicVolume(float vol){
        gameMusicVolume = vol;
        // adjustGameMusicVolume();
        SaveGame();
    }
    public void setSFXVolume(float vol){
        waterSFXVolume = vol;
        beeSFXVolume = vol;
        dieSFXVolume = vol;
        frogSFXVolume = vol;
        birdSFXVolume = vol;
        foodPickupSFXVolume = vol;
        buttonClickSoundVolume = vol;
        // adjustSFXVolume();
        SaveGame();
    }
    public void adjustGameMusicVolume(){
        if(gameMusic != null){
            gameMusic.volume = gameMusicVolume/15;
        }
    }
   public void adjustSFXVolume(){
       if(waterSFX != null){
            waterSFX.volume = waterSFXVolume/10;
            beeSFX.volume = beeSFXVolume/2;
            dieSFX.volume = dieSFXVolume/5;
            frogSFX.volume = frogSFXVolume/5;
            birdSFX.volume = birdSFXVolume/5;
            foodPickupSFX.volume = foodPickupSFXVolume/15;
            buttonClickSound.volume = buttonClickSoundVolume/15;
       }
    }

    //non specific functions
    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void SaveGame(){
        SaveSystem.SaveGame(this);
    }
    public void LoadGame(){
        SaveData data = SaveSystem.LoadGame();

        //game data
        stageLockStatus = data.stageLockStatus;
        stageScore = data.stageScore;
        totalScore = data.totalScore;
        pastTutorial = data.pastTutorial;

        //sound data
        gameMusicVolume = data.gameMusicVolume;
        waterSFXVolume = data.waterSFXVolume;
        beeSFXVolume = data.beeSFXVolume;
        dieSFXVolume = data.dieSFXVolume;
        frogSFXVolume = data.frogSFXVolume;
        birdSFXVolume = data.birdSFXVolume;
        foodPickupSFXVolume = data.foodPickupSFXVolume;
        buttonClickSoundVolume = data.buttonClickSoundVolume;
        //sound slider data
        gameMusicSlider.value = gameMusicVolume;
        sfxSlider.value = waterSFXVolume;
    }
    public void ExitGame(){
        Application.Quit();
    }
    public void RestartStage(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetGameData(){
        Initialize();
    }
    void Update(){
        adjustGameMusicVolume();
        adjustSFXVolume();
        ParseScore();
        GetStageNumber();
        Debug.Log(gameMusicVolume);
        Debug.Log(stageScore[3]);
        Debug.Log(stageScore[5]);
    }

    //sound function
    public void PlayGameMusic(){
        gameMusic.Play();
   }
   public void PlayWaterSFX(){
        waterSFX.Play();
   }
   public void PlayBeeSFX(){
        beeSFX.Play();
   }
    public void PlayButtonClickSound(){
        buttonClickSound.Play();
   }
   public void PlayDieSFX(){
       dieSFX.Play();
   }
   public void PlayFrogSFX(){
       frogSFX.Play();
   }
   public void PlayBirdSFX(){
       birdSFX.Play();
   }
   public void PlayFoodPickupSFX(){
       foodPickupSFX.Play();
   }

    //special function
    public void UnlockAllStage(){
        for(int i = 0; i < stageLockStatus.Length; i++){
            pastTutorial = true;
            stageLockStatus[i] = false;
        }
        SaveGame();
    }
}

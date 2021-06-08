using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    //scene management parameters section
    public static bool checkIntro = false ;
    public int index;
    public GameObject SelectStageBackground,alertBox;
    private static bool[] lockChecker;
    public Text StageNumber;

    //score management parameter section
    // private static bool scoreInit = false;
    // private static int totalScore;
    // private static int[] stageScore;
    // public Text UIScoreText,submaryScoreText,stageScoreText;

    //audio management parameters section
    private static bool initSoundValue = false;
    public AudioSource gameMusic;
    private static float gameMusicVolume;
    public AudioSource waterSFX;
    private static float waterSFXVolume;
    public AudioSource beeSFX;
    private static float beeSFXVolume;
    public AudioSource buttonClickSound;
    private static float buttonClickSoundVolume;
    public AudioSource dieSFX;
    private static float dieSFXVolume;
    public AudioSource frogSFX;
    private static float frogSFXVolume;
    public AudioSource birdSFX;
    private static float birdSFXVolume;
    public AudioSource foodPickupSFX;
    private static float foodPickupSFXVolume;
    public Slider gameMusicSlider,sfxSlider;

    //scene management functions section
    void getStageNumber(){
        StageNumber.text = (SceneManager.GetActiveScene().buildIndex - 2).ToString();
    }
     public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayGame(int stageIndex)
    {
        SceneManager.LoadScene(stageIndex);
    }
    public void goToNextStage(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        lockChecker[SceneManager.GetActiveScene().buildIndex + 1] = false;
    }

    public void CheckIntro(){
        if(checkIntro == true){
            SelectStageBackground.SetActive(true);
        }
        else{
            SceneManager.LoadScene(1);
            // checkIntro = true;

            lockChecker = new bool[18];
            lockChecker[0] = false;
            lockChecker[1] = false;
            lockChecker[2] = false;
            for(int i = 3; i <= lockChecker.Length; i++){
                lockChecker[i] = true;
            }
        }
    }

    public void CheckUnlockStage(){
        if(lockChecker[index] == false){
            PlayGame(index);
        }
        else{
            alertBox.SetActive(true);
        }
    }
    public void passIntro(){
        checkIntro = true;
        goToNextStage();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SettingGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartStage(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UnlockAllStages(){
        checkIntro = true;
        for(int i = 0; i < lockChecker.Length; i++){
            lockChecker[i] = false;
        }
    }

    //audio management functions section
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
   public void adjustGameMusicVolume(){
       gameMusic.volume = gameMusicVolume/15;
   }
   public void adjustSFXVolume(){
       waterSFX.volume = waterSFXVolume/10;
       beeSFX.volume = beeSFXVolume;
       dieSFX.volume = dieSFXVolume/5;
       frogSFX.volume = frogSFXVolume/5;
       birdSFX.volume = birdSFXVolume/5;
       foodPickupSFX.volume = foodPickupSFXVolume/15;
       buttonClickSound.volume = buttonClickSoundVolume/5;
   }
   public void adjustButtonClickSoundVolume(){
       buttonClickSound.volume = 0;
   }

    public void setGameMusicVolume(float vol){
        gameMusicVolume = vol;
    }
    public void setSFXVolume(float vol){
        waterSFXVolume = vol;
        beeSFXVolume = vol;
        dieSFXVolume = vol;
        frogSFXVolume = vol;
        birdSFXVolume = vol;
        foodPickupSFXVolume = vol;
        buttonClickSoundVolume = vol;
    }
    //start function
    void Start(){
        if(initSoundValue == false){
            gameMusicVolume = 2;
            waterSFXVolume = 2;
            beeSFXVolume = 2;
            dieSFXVolume = 2;
            frogSFXVolume = 2;
            birdSFXVolume = 2;
            foodPickupSFXVolume = 2;
            buttonClickSoundVolume = 2;
            initSoundValue = true;
        }
        // if(scoreInit == false){
        //     scoreInitialize();
        // }
        gameMusicSlider.value = gameMusicVolume;
        sfxSlider.value = waterSFXVolume;
    }
   //update function
   void Update(){
       adjustGameMusicVolume();
       adjustSFXVolume();
    //    adjustButtonClickSoundVolume();
       getStageNumber();
    //    updateScore();
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
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
    public SaveData(Save save){
        stageLockStatus = save.stageLockStatus;
        stageScore = save.stageScore;
        totalScore = save.totalScore;
        pastTutorial = save.pastTutorial;
        gameMusicVolume = save.gameMusicVolume;
        waterSFXVolume = save.waterSFXVolume;
        beeSFXVolume = save.beeSFXVolume;
        buttonClickSoundVolume = save.buttonClickSoundVolume;
        dieSFXVolume = save.dieSFXVolume;
        frogSFXVolume = save.frogSFXVolume;
        birdSFXVolume = save.birdSFXVolume;
        foodPickupSFXVolume = save.foodPickupSFXVolume;        
    }
}

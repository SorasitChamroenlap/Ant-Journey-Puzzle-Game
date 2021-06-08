using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    //parameter
    private static int totalScore;
    private static int[] stageScore;
    public Text UIScore,recievedScore;
    public Text[] stageScoreText;
    private static bool init = false;


    // function
    public void updateTotalScore(){
        totalScore = 0;
        for(int i = 0; i < stageScore.Length; i++){
            totalScore += stageScore[i];
        }
    }
    public void updateScore(){
        if(int.Parse(UIScore.text) >= stageScore[SceneManager.GetActiveScene().buildIndex]){
            stageScore[SceneManager.GetActiveScene().buildIndex] = int.Parse(UIScore.text);
        }
    }
    void updateRecievedScore(){
        recievedScore.text = UIScore.text;
    }
    void doStageScoreText(){
        for(int i = 0;i < stageScore.Length; i++){
            if(stageScoreText[i] != null){
                stageScoreText[i].text = stageScore[i].ToString();
            }
        }
    }
    void initialize(){
        stageScore = new int[18];
        init = true;
        // Debug.Log("Total score = "+totalScore);
        // Debug.Log(stageScore[0]);
        // Debug.Log(stageScore[1]);
        // Debug.Log(stageScore[2]);
        // Debug.Log(stageScore[3]);
        // Debug.Log(stageScore[4]);
        // Debug.Log(stageScore[5]);
        // Debug.Log(stageScore[6]);
        // Debug.Log(stageScore[7]);
        // Debug.Log(stageScore[8]);
        // Debug.Log(stageScore[9]);
    }
    void Start()
    {
        if(init == false){
            initialize();
        }else{
            doStageScoreText();
        }
    }

    void Update()
    {
        if(UIScore != null){
            // updateScore();
            updateRecievedScore();
            // Debug.Log(stageScore[0]);
            // Debug.Log(stageScore[1]);
            // Debug.Log(stageScore[2]);
            // Debug.Log(stageScore[3]);
            // Debug.Log(stageScore[4]);
            // Debug.Log(stageScore[5]);
            // Debug.Log(stageScore[6]);
            // Debug.Log(stageScore[7]);
            // Debug.Log(stageScore[8]);
            // Debug.Log(stageScore[9]);
        } 
    }
}

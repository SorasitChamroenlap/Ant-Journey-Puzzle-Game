using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingMenu : MonoBehaviour
{
    public GameObject SettingMenu,SubSettingMenu,SelectStageBackground;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(SettingMenu.activeSelf == true){
                SettingMenu.SetActive(false);
                SubSettingMenu.SetActive(false);
                SelectStageBackground.SetActive(false);
                // Resume();
            }
            else if(SettingMenu.activeSelf == false){
                SettingMenu.SetActive(true);
                // Pause();
            }
        }
    }
    public void Resume(){
        Time.timeScale = 1f;
    }
    public void Pause(){
        Time.timeScale = 0f;
    }
}

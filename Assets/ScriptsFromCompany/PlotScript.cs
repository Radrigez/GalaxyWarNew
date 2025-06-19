using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlotScript : MonoBehaviour
{
    public GameObject panel;
    public Button next1;
    public Button next2;
    public Button next3;
    public Button next4;
    public Button next5;
    public Button next6;
    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    public Text Text5;
    public Text Text6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Plot1()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(true);
        next1.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot2()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(true);
        next1.gameObject.SetActive(false);
        next2.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot3()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(true);
        next1.gameObject.SetActive(false);
        next2.gameObject.SetActive(false);
        next3.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot4()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(false);
        Text4.gameObject.SetActive(true);
        next1.gameObject.SetActive(false);
        next2.gameObject.SetActive(false);
        next3.gameObject.SetActive(false);
        next4.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot5()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(false);
        Text4.gameObject.SetActive(false);
        Text5.gameObject.SetActive(true);
        next1.gameObject.SetActive(false);
        next2.gameObject.SetActive(false);
        next3.gameObject.SetActive(false);
        next4.gameObject.SetActive(false);
        next5.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot6()
    {
        panel.gameObject.SetActive(true);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(false);
        Text4.gameObject.SetActive(false);
        Text5.gameObject.SetActive(true);
        next1.gameObject.SetActive(false);
        next2.gameObject.SetActive(false);
        next3.gameObject.SetActive(false);
        next4.gameObject.SetActive(false);
        next5.gameObject.SetActive(false);
        next6.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Plot7()
    {  
         SceneManager.LoadScene("2GameSceneWars");
    }
}

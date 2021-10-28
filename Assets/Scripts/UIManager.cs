using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Menu;
    public GameObject FinishScreen;
    public TextMeshProUGUI finishTime;
    public GameObject FinishLine;
   
    //private bool isMenuActive;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //playerController.enabled = false;
        HUD.gameObject.SetActive(true);
        //Menu.gameObject.SetActive(true);
    }

    private void ShowInstructions()
    {
    }
    // public void CloseMenu()
    // {
    //     Menu.gameObject.SetActive(false);
    //     HUD.gameObject.SetActive(true);
    //     playerController.enabled = true;
    // }
    // Update is called once per frame
    void Update()
    {
        if(FinishLine.GetComponent<FinishLine>().playerHasFinished == true)
        {
            ShowFinishScreen();
            gameObject.GetComponent<Timer>().timerActive = false;
            finishTime.text = "Your time: "  + gameObject.GetComponent<Timer>().timer.text;
        }
    }
    void ShowFinishScreen()
    {
        playerController.enabled = false;
        FinishScreen.gameObject.SetActive(true);
    }

}

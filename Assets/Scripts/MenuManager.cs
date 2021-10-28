using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Inst;
    public GameObject Buttons;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        Buttons.SetActive(false);
        Inst.SetActive(true);
    }
    public void ShowMenu()
    {
        Inst.SetActive(false);
        Buttons.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DashCD : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    public TextMeshProUGUI dashcool;
    void Start()
    {
         playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.dashCd == true)
        {
            dashcool.text = "<color=red>Dash On Cooldown...</color>";
            
        }
        
        else if(playerController.dashCd == false)
        {
            dashcool.text = "<color=green>Dash Ready!</color>";
        }
    }
}

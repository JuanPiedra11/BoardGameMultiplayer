using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Runtime.CompilerServices;


public class PlayerItem : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    Image backgroundImage;

    public Color hightlightColor;
    public GameObject leftArrowbtn;
    public GameObject RightArrowBtn;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();    
    }



    public void SetPlayerInfo(Player _Player) {

        playerName.text = _Player.NickName;
    
    }

    public void ApplyLocalChanges()
    {

        backgroundImage.color = hightlightColor;
        leftArrowbtn.SetActive(true);
        RightArrowBtn.SetActive(false);


    }

}

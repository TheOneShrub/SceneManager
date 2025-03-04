/*******************************************************************
* COPYRIGHT       : Year
* PROJECT         : One Wild Night
* FILE NAME       : Campgrounds.cs
* DESCRIPTION     : Level manager for the campgrounds leve
*                    
* REVISION HISTORY:
* Date            Author                  Comments
* ---------------------------------------------------------------------------
* 2025/02/12     Akram Taghavi-Burris        Created class
* 
*
/******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using CSG.Managers;
using UnityEngine;

public class Campgrounds : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Trigger");
        
        //if Player enters
        if (other.tag == "Player")
        {
            GameManager.Instance.ChangeState(GameState.GameOver);
        }//end if (other.tag == "Player")
        
        
    }
    
    
}//end Campgrounds.cs
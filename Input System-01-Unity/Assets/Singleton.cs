/*******************************************************************
* COPYRIGHT       : 2025
* PROJECT         : CSG gen libraries
* FILE NAME       : Singleton.cs
* DESCRIPTION     : Singleton based class
*
* REVISION HISTORY:
* Date            Author                  Comments
* ---------------------------------------------------------------------------
* 2025/02/04      Blaine Grimes       Created File
*
*
/******************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#ROOTNAMESPACEBEGIN#
//generic singleton base classs that any monobehavior can inherit from


// Update is called once per frame


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //STATIC instance that holds the reference to the singleton
    private static T _instance;
    
    //Pblic property to access singleton instance
    public static T Instance {get{return _instance;}}

    private bool _isPersistent = true;
    
    
    
    // Awake is called once at instantiation
    void Awake()
    {
        CheckForSingleton();

    }//end Awake()

    void CheckForSingleton()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
        
        
        
        Debug.Log(_instance);
    }


    void CheckForPersistence()
    {
        if (_isPersistent)
        {
            if (transform.parent != null)
            {
                transform.SetParent(null);
            }
        }

        DontDestroyOnLoad(_instance);
    }
}

    // Start is called before the first frame update

    


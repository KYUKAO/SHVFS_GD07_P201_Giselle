using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject GameSystemObject;
    public GameObject CustomizeSystemObject;
    public void GoToCustomizeLevel()
    {
        GameSystemObject.SetActive(false);
        CustomizeSystemObject.SetActive(true);
    }
    public void GoToGameInterface()
    {
        GameSystemObject.SetActive(true);
        CustomizeSystemObject.SetActive(false);
    }
}

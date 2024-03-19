using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PVPPanel : MonoBehaviour
{
    [BoxGroup("PVESettings")] 
    [SerializeField] private TMP_Dropdown P1Dropdown;
    
    [BoxGroup("PVESettings")] 
    [SerializeField] private TMP_Dropdown P2Dropdown;
    

    public void Init()
    {
        P1Dropdown = GameObject.Find("P1Dropdown").GetComponent<TMP_Dropdown>();
        P2Dropdown = GameObject.Find("P2Dropdown").GetComponent<TMP_Dropdown>();
        
        P1Dropdown.onValueChanged.AddListener(SetP2DropdownValue);
        P2Dropdown.onValueChanged.AddListener(SetP1DropdownValue);
    }
    
    
    public int GetP1Type()
    {
        return P1Dropdown.value;
    }
    
    public int GetP2Type()
    {
        return P2Dropdown.value;
    }

    private void SetP1DropdownValue(int arg0)
    {
        P1Dropdown.value = arg0 == 1 ? 0 : 1;
    }
    
    private void SetP2DropdownValue(int arg0)
    {
        P2Dropdown.value = arg0 == 1 ? 0 : 1;
    }
}
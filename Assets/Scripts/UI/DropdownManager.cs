using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] private List<String> countryCodes;
    private TMP_Dropdown dropdown;
    private void Start(){
        countryCodes = uiManager.GetCountryCodes();
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();

        dropdown.AddOptions(countryCodes);
    }
}

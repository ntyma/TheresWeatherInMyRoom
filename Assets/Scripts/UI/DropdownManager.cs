using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private List<String> countryCodes;
    private TMP_Dropdown dropdown;
    private void Start(){
        countryCodes = UIManager.instance.GetCountryCodes();
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();

        dropdown.AddOptions(countryCodes);

    }
}

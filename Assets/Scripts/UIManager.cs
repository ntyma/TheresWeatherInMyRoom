using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] GetApi api;
    [SerializeField] TMP_Dropdown countryDropdown;
    [SerializeField] TMP_InputField cityInput;
    [SerializeField] private string city;
    [SerializeField] private string country;

    [SerializeField] public List<String> countries = new List<string>{"CA" , "US", "UK", "AU"};

    public static UIManager instance;
    public WeatherState selectedWeatherState;
    public Action<WeatherState> onWeatherChange;
    void Awake(){
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this; 

        api.OnWeatherStateChangeFinished += WeatherStateChanged;
    }
    public void GetWeather(){
        if(cityInput.text == "") return;
        city = cityInput.text;
        country = countries[countryDropdown.value]; 
        api.GetWeatherByCityCountry(city, country);
    }

    public void WeatherStateChanged(WeatherState state){
        onWeatherChange.Invoke(state);
    }

    public List<String> GetCountryCodes() {
        return countries;
    }

}

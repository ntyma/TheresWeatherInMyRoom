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
    [SerializeField] TMP_Text infoText;
    private string city;
    private string country;

    private string weatherString;

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
        api.OnWeatherIsSame += UpdateLocationText;
    }
    public void GetWeather(){
        if(cityInput.text == "") return;
        city = cityInput.text;
        country = countries[countryDropdown.value]; 
        api.GetWeatherByCityCountry(city, country);
    }

    public void WeatherStateChanged(WeatherState state){
        UpdateInfoText(state);
        onWeatherChange.Invoke(state);
    }

    private void UpdateLocationText(){
        infoText.text = "The weather in " + city + ", " + country + " : " + weatherString;
    }

    private void UpdateInfoText(WeatherState weatherState){
        Weather weather = weatherState.weather[0];
        String state = weather.main;
        switch (state) {
            case "Rain":
                weatherString = "Raining";
                break;
            case "Clouds":
                weatherString = "Cloudy";
                break;
            case "Drizzle":
                weatherString = "Drizzling";
                break;
            case "Snow":
                weatherString = "Snowing";
                break;
            case "Clear" :
                weatherString = "Clear Skies";
                break;
            default :
                weatherString = "Clear Skies";
                break;
        }

        infoText.text = "The weather in " + city + ", " + country + " : " + weatherString;
    }

    public List<String> GetCountryCodes() {
        return countries;
    }

}

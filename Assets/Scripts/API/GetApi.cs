using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 

public class GetApi : MonoBehaviour
{
    // private string apiKey = "92e5d88a41fc01855ef6b23beda71e02";
    public WeatherState weatherState;
    private String currState;
    public Action<WeatherState> OnWeatherStateChangeFinished;
    public Action OnWeatherIsSame;
    private string selectedCity;
    private string selectedCountry;

    void Start()
    {
        
    }

    public void GetWeatherByCityCountry(string cityName, string countryName){
        selectedCity = cityName;
        selectedCountry = countryName;
        StartCoroutine(FindWeatherByCity());
    }

    IEnumerator FindWeatherByCity()
    {
        string cityName = selectedCity;
        string countryName = selectedCountry;
        string apiKey = "92e5d88a41fc01855ef6b23beda71e02";
        string apiAddress = $"https://api.openweathermap.org/data/2.5/weather?q={cityName},{countryName}&units=metric&appid={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(apiAddress);
        yield return request.SendWebRequest();
        if(request.result != UnityWebRequest.Result.ConnectionError){
            // Debug.Log(request.downloadHandler.text);
            weatherState = JsonUtility.FromJson<WeatherState>(request.downloadHandler.text);
            string newState = weatherState.weather[0].main;
            if (newState != currState){
                OnWeatherStateChangeFinished.Invoke(weatherState);
                currState = newState;
            } else {
                OnWeatherIsSame.Invoke();
            }
        } else 
        {
            Debug.Log(request.error);    
        }
        yield return new WaitForSeconds(1f);
    }

    
}

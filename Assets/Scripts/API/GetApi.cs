using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 

public class GetApi : MonoBehaviour
{
    // private string apiKey = "92e5d88a41fc01855ef6b23beda71e02";
    public WeatherState weatherState;
    public Action<WeatherState> OnWeatherStateChangeFinished;
    private string selectedCity;
    private string selectedCountry;

    // Start is called before the first frame update
    void Start()
    {
        // GetWeatherByCityCountry("Richmond", "CA");
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
            Debug.Log(request.downloadHandler.text);
            weatherState = JsonUtility.FromJson<WeatherState>(request.downloadHandler.text);
            OnWeatherStateChangeFinished.Invoke(weatherState);
        } else 
        {
            Debug.Log(request.error);    
        }
        yield return new WaitForSeconds(1f);
    }

    
}

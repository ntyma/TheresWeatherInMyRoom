using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMachine : MonoBehaviour
{
    [SerializeField] private WeatherState weatherState;

    void Start() {
        UIManager.instance.onWeatherChange += ChangeWeatherState;
    }
    public void ChangeWeatherState(WeatherState newState){
        weatherState = newState;
        Weather weather = weatherState.weather[0];
        String state = weather.main;

        switch (state) {
            case "Rain":
                Debug.Log("rain");
                break;
            case "Clouds":
                Debug.Log("clouds");
                break;
            case "Drizzle":
                Debug.Log("drizzling");
                break;
            case "Snow":
                Debug.Log("snow");
                break;
            case "Clear" :
                Debug.Log("clear");
                break;
            default :
                Debug.Log("error");
                break;
        }


        Debug.Log("Changed WeatherSTate");
    }


}

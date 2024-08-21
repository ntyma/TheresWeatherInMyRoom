using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMachine : MonoBehaviour
{
    [SerializeField] private WeatherState weatherState;
    [SerializeField] private RainState rainState;
    [SerializeField] private SunnyState sunState;
    [SerializeField] private CloudyState cloudyState;
    private IWorldState currentState;

    void Start() {
        UIManager.instance.onWeatherChange += ChangeWeatherState;
        currentState = rainState;
    }
    public void ChangeWeatherState(WeatherState newState){
        weatherState = newState;
        Weather weather = weatherState.weather[0];
        String state = weather.main;
        Debug.Log("=====" + state + "=======");

        if(currentState != null){
            currentState.ExitState();
        }

        switch (state) {
            case "Rain":
                currentState = rainState;
                break;
            case "Clouds":
                currentState = cloudyState;
                break;
            case "Drizzle":
                currentState = rainState;
                break;
            case "Snow":
                currentState = rainState;
                break;
            case "Clear" :
                currentState = sunState;
                break;
            default :
                currentState = sunState;
                break;
        }
        currentState.EnterState();
    }

}

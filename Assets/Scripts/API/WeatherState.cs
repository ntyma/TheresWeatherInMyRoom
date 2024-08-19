using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeatherState
{
    public Coord coord;
    public Weather[] weather;
    public Clouds clouds;
}


[System.Serializable]
public class Coord{
    public string lon;
    public string lat;
}

[System.Serializable]
public class Weather {
    public string main;
    public string description;

}

[System.Serializable]
public class Clouds {
    public int all;
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCatalogue : MonoBehaviour
{
    [SerializeField] TextAsset citiesJsonFile;
    private Cities cityCatalogue;
    void Awake(){
        if(citiesJsonFile == null) return;
        cityCatalogue = JsonUtility.FromJson<Cities>(citiesJsonFile.text);
    }

    public Cities GetCityCatalogue (){
        return cityCatalogue;
    }
}

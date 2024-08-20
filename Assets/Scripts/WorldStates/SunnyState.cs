using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyState : MonoBehaviour, IWorldState
{
    [SerializeField] private Light sun;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;
    public void EnterState()
    {
        StartCoroutine(GetBrighter());
    }

    public void ExitState()
    {
        StopCoroutine(GetBrighter());
        StartCoroutine(GetDimmer());
    }

    IEnumerator GetBrighter(){
        while(sun.intensity < maxIntensity) {
            sun.intensity += Time.deltaTime * 0.05f;
            yield return new WaitForFixedUpdate();
        }  
    }

    IEnumerator GetDimmer(){
        while(sun.intensity > minIntensity) {
            sun.intensity -= Time.deltaTime * 0.15f;
            yield return new WaitForFixedUpdate();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.X)){
        //     ExitState();
        // }
    }
}

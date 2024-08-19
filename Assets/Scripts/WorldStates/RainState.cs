using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainState : MonoBehaviour, IWorldState
{
    [SerializeField] private GameObject waterPlane;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform maxHeight;
    [SerializeField] private ParticleSystem rainParticles;
    [SerializeField] private float risingSpeed;
    [SerializeField] private float loweringMultiplier;

    private bool isRising;
    private bool isIdle;

    void Start() {
        // EnterState();
    }
    public void EnterState()
    {
        PlayRainParticles();
        waterPlane.SetActive(true);
        isRising = true;
    }

    public void ExitState()
    {
        StopRainParticles();
        isRising = false;
    }

    public void IdleState()
    {
        isIdle = true;
    }

    void Update(){

        if(isRising) {
            waterPlane.transform.position = Vector3.Lerp(waterPlane.transform.position, maxHeight.position, risingSpeed * Time.deltaTime);
        } 
        else if(!isRising) {
            waterPlane.transform.position = Vector3.Lerp(waterPlane.transform.position, startPoint.position, risingSpeed * loweringMultiplier * Time.deltaTime);
        }
        // if(Input.GetKeyDown(KeyCode.X)){
        //     ExitState();
        // }
    }

    private void PlayRainParticles(){
        float tinyStep = 0.000001f;
        rainParticles.Simulate(tinyStep, true, true, false);
        rainParticles.Play();
    }

    private void StopRainParticles(){
        rainParticles.Stop();
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudyState : MonoBehaviour, IWorldState
{
    [SerializeField] private ParticleSystem groundFog;
    [SerializeField] private GameObject clouds;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform centrePoint;
    [SerializeField] private float speed;
    public void EnterState()
    {
        groundFog.gameObject.SetActive(true);
        clouds.transform.position = startPoint.position;
        clouds.SetActive(true);
        StartCoroutine(RollCloudsIn());
    }

    public void ExitState()
    {
        StopCoroutine(RollCloudsIn());
        StartCoroutine(RollCloudsOut());
    }

    IEnumerator RollCloudsIn(){
        while(groundFog.transform.position.x != centrePoint.position.x & clouds.transform.position.x != centrePoint.position.x) {
            groundFog.transform.position = Vector3.MoveTowards(groundFog.transform.position, centrePoint.position, Time.deltaTime * speed);
            clouds.transform.position = Vector3.MoveTowards(clouds.transform.position, centrePoint.position, Time.deltaTime * speed);
            if(groundFog.transform.position.x >= centrePoint.position.x & clouds.transform.position.x >= centrePoint.position.x) {
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator RollCloudsOut(){
        while(groundFog.transform.position.x != startPoint.position.x) {
            groundFog.transform.position = Vector3.MoveTowards(groundFog.transform.position, startPoint.position, Time.deltaTime * speed * 2f);
            clouds.transform.position = Vector3.MoveTowards(clouds.transform.position, startPoint.position, Time.deltaTime * speed * 2f);
            if(groundFog.transform.position.x <= startPoint.position.x) {
                groundFog.gameObject.SetActive(false);
                clouds.SetActive(false);
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}

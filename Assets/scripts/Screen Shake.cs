using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] public static bool start = false;
    public float duration = 1f;
    public AnimationCurve curve;
    public float strength;

    void Update()
    {
        
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
        
    }
    private IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            
            transform.position = startPosition + Random.insideUnitSphere * strength;
            
            yield return null;
            transform.position = startPosition;

        }
        
        


    }
}

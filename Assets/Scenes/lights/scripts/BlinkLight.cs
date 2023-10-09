using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour 
{
	Light light;
	public float minIntensity = 1.6f;
	public float maxIntensity = 1.8f;	
    public float offset_size = 0.03f;
    public float flickerSpeed = 0.1f;

    private Vector3 default_position; 
	
    void Start () 
	{
		light = GetComponent<Light>();
        default_position = light.transform.position;
        StartCoroutine(Flicker());
	}
	

    private IEnumerator Flicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(flickerSpeed);
            light.intensity = Random.Range(minIntensity, maxIntensity);
            float x =  Random.Range(-offset_size, offset_size);
            float y =  Random.Range(-offset_size, offset_size);
            float z =  Random.Range(-offset_size, offset_size);
            light.transform.position = default_position + new Vector3(x, y, z);
        }
    }
}
using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    float initialIntensity;
    bool triggered = false;

	// Use this for initialization
	void Start ()
    {
        initialIntensity = GetComponent<Light>().intensity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!triggered)
        {
            int chance = Random.Range(0, 50);
            if (chance == 1)
            {
                GetComponent<Animator>().SetTrigger("Start");
                triggered = true;
            }
        }
	}
}

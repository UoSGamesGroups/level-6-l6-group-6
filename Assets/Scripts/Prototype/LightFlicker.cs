using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    bool triggered = false;
	
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

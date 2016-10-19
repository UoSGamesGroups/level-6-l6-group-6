using UnityEngine;
using System.Collections;

public class ScriptedScamper : MonoBehaviour {

    public Light[] lights;
    public GameObject trigger;

    //private bool triggered = false;
    private Animator _Animator;

	// Use this for initialization
	void Start ()
    {
        _Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void StartScare ()
    {
        _Animator.SetTrigger("Start");
    }

    public void ControlLights()
    {
        foreach (Light item in lights)
        {
            item.GetComponent<Animator>().SetTrigger("On");
        }
    }

    public void FlickerOff()
    {
        foreach (Light item in lights)
        {
            item.enabled = false;
            item.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void FlickerOn()
    {
        foreach (Light item in lights)
        {
            item.enabled = true;
            item.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

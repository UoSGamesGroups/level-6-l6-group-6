using UnityEngine;
using System.Collections;

public class ScriptedScamperTrigger : MonoBehaviour
{
    public ScriptedScamper scamper;
    private bool triggered = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PTTP_ScamperTrigger" && triggered == false)
        {
            scamper.StartScare();
            triggered = true;
        }
    }
}

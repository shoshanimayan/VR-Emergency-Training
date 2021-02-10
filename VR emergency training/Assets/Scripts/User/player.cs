using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 spawn;

    public FireDrill fire;
    public EarthQuakeDrill earth;
    public GameManager manager;

    public void Awake()
    {
        spawn = transform.position;  
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "goal"){
            StartCoroutine(reset());
        }
    }
    IEnumerator reset() {
        manager.TextUpdate("Simulation Complete!");
        
        yield return new WaitForSeconds(2);
        if (fire.running)
        {
            fire.off();

        }
        else {
            earth.off();
        }
        transform.position = spawn;

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    
     
    //private variables
    
    private Vector3 spawn;

    [SerializeField] private GameManager _manager;

     
    //private methods
    
    private void Awake()
    {
        spawn = transform.position;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "goal"){
            StartCoroutine(Reset());
        }
    }
    private IEnumerator Reset() {
        _manager.TextUpdate("Simulation Complete!");
        
        yield return new WaitForSeconds(2);
        if (_manager.fire.running)
        {
            _manager.fire.Off();

        }
        else {
            _manager.earth.Off();
        }
        transform.position = spawn;

    }

    


}


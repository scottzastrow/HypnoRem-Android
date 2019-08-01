using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

    public GameObject particleStorm;

	void Start ()
    {
        GameObject newStorm = Instantiate(particleStorm) as GameObject;
    }
	
}

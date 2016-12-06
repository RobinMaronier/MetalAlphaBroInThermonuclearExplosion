using UnityEngine;
using System.Collections;

public class RandomizePitch : MonoBehaviour
{
    public float minPitch = 0.5f;
    public float maxPitch = 1.5f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().pitch = Random.Range(minPitch, maxPitch);
	}
}

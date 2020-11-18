using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreatorController : MonoBehaviour
{
    public GameObject[] onSamples;
    public GameObject[] offSamples;

    private bool showSamples;

    // Start is called before the first frame update
    void Start()
    {
        showSamples = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSamples()
    {
        showSamples = !showSamples;
        foreach (GameObject sample in onSamples)
        {
            sample.SetActive(showSamples);
        }
        foreach (GameObject sample in offSamples)
        {
            sample.SetActive(!showSamples);
        }
    }
}

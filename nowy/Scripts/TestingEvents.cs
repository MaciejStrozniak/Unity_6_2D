using System;
using System.Xml.Serialization;
using UnityEngine;

public class TestingEvents : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventsTest eventsTest = GetComponent<EventsTest>();
        AudioSource audioSource = GetComponent<AudioSource>();
        eventsTest.OnSpacePressed += TestingEvents_OnSpacePressed;

        EventsTest eventsTest2 = GetComponent<EventsTest>();
        eventsTest2.onEKeyPressed += TestingEvents_OnEKeyPressed;
    }

    private void TestingEvents_OnSpacePressed(object sender, EventsTest.DefaultArgs e) {
        Debug.Log("Space pressed w drugim skrypcie " + e.spaceCount);
        Debug.Log("Audio source status: " + e.audioSourceStatus);
        
        EventsTest eventsTest = GetComponent<EventsTest>();
        AudioSource audioSource = GetComponent<AudioSource>();
        if(audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
        // eventsTest.OnSpacePressed -= TestingEvents_OnSpacePressed;
    }

    private void TestingEvents_OnEKeyPressed(object sender, EventArgs e) {
        EventsTest eventsTest2 = GetComponent<EventsTest>();
        Debug.Log("E key pressed");
        eventsTest2.onEKeyPressed -= TestingEvents_OnEKeyPressed;
    }
}

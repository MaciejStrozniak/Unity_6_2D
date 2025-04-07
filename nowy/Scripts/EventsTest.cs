using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventsTest : MonoBehaviour
{
    public event EventHandler<DefaultArgs> OnSpacePressed;
    public class DefaultArgs : EventArgs {
        public int spaceCount;
        public bool audioSourceStatus = false; 
    }

    public event EventHandler onEKeyPressed;

    private int spaceCount;
    private bool audioSourceStatus = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            spaceCount ++;
            audioSourceStatus = !audioSourceStatus;
            OnSpacePressed?.Invoke(this, new DefaultArgs {  spaceCount = spaceCount, 
                                                            audioSourceStatus = audioSourceStatus});
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            onEKeyPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}

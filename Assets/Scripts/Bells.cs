using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bells : MonoBehaviour
{
    [SerializeField] MIDIListenerHub midiHub;
    [SerializeField] Bell bell;
    [SerializeField] List<string> notes;

    // Update is called once per frame
    void Update()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiNotes = midiHub.MidiChannelRead(1);
        foreach (MIDIListenerHub.MIDINoteMessage bellNote in midiNotes)
        {
            if (notes.Contains(bellNote.note) && bell.atStart)
            {
                bell.Hit();
            }
        }
    }
}

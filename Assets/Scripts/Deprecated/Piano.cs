using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    [SerializeField] MIDIListenerHub midiHub;

    // Update is called once per frame
    void Update()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiNotes = midiHub.MidiChannelRead(1);
        foreach(MIDIListenerHub.MIDINoteMessage midiNote in midiNotes)
        {
            print($"Piano Note: {midiNote.note} Octave: {midiNote.octave} Vel: {midiNote.velocity}");
            Transform pianoKey = transform.Find(midiNote.note);
            if (pianoKey != null)
            {
                Key key = pianoKey.GetComponent<Key>();
                key.PressKey(midiNote.velocity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    [SerializeField] MIDIListenerHub midiHub;
    [SerializeField] GuitarStrumBar strumBar;

    // Update is called once per frame
    void Update()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiNotes = midiHub.MidiChannelRead(2);
        foreach (MIDIListenerHub.MIDINoteMessage midiNote in midiNotes)
        {
            //print($"Guitar Note: {midiNote.note} Octave: {midiNote.octave} Vel: {midiNote.velocity} {midiNote.note}Button");
            Transform guitarKey = transform.Find($"{midiNote.note}Button");
            if (guitarKey != null)
            {
                GuitarKey key = guitarKey.GetComponent<GuitarKey>();
                key.PressKey(midiNote.velocity);

                if (strumBar.atStart)
                {
                    strumBar.Strum();
                }
            }
        }
    }
}

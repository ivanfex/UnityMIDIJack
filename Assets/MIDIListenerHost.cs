using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDIListenerHost : MonoBehaviour
{
    string[] noteStrings = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    MidiJack.MidiChannel[] midiChannels = { 
        MidiJack.MidiChannel.Ch1, MidiJack.MidiChannel.Ch2, MidiJack.MidiChannel.Ch3, MidiJack.MidiChannel.Ch4,
        MidiJack.MidiChannel.Ch5, MidiJack.MidiChannel.Ch6, MidiJack.MidiChannel.Ch7
    };
    [SerializeField] Receiver[] channelReceiver;

    // Update is called once per frame
    void Update()
    {
        for(int channel = 0; channel < midiChannels.Length; channel++)
        {
            for(int i = 1; i < 127; i++)
            {
                float keyDownVelocity = MidiJack.MidiMaster.GetKey(midiChannels[channel], i);
                bool isKeyDown = keyDownVelocity > 0;

                if (isKeyDown)
                {
                    channelReceiver[channel].ReceiveNote(NoteMidiMapper(i), OctaveMidiMapper(i), keyDownVelocity);
                }
            }
        }
    }
 
    string NoteMidiMapper(int midiNoteNumber)
    {
        int noteIndex = midiNoteNumber % 12;
        return noteStrings[noteIndex];
    }

    int OctaveMidiMapper(int midiNoteNumber)
    {
        return (midiNoteNumber / 12) - 1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDIListenerHub : MonoBehaviour
{
    string[] noteStrings = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    MidiJack.MidiChannel[] midiChannels = {
        MidiJack.MidiChannel.Ch1, MidiJack.MidiChannel.Ch2, MidiJack.MidiChannel.Ch3, MidiJack.MidiChannel.Ch4,
        MidiJack.MidiChannel.Ch5, MidiJack.MidiChannel.Ch6, MidiJack.MidiChannel.Ch7
    };

    struct MIDINoteMessage
    {
        public string note;
        public int octave;
        public float velocity;

        public MIDINoteMessage(string note, int octave, float velocity)
        {
            this.note = note;
            this.octave = octave;
            this.velocity = velocity;
        }
    }

    List<MIDINoteMessage> MidiChannelRead(int channel)
    {
        List<MIDINoteMessage> midiNotes = new List<MIDINoteMessage>();

        for (int i = 1; i < 127; i++)
        {
            float keyDownVelocity = MidiJack.MidiMaster.GetKey(midiChannels[channel - 1], i);
            bool isKeyDown = keyDownVelocity > 0;

            if (isKeyDown)
            {
                midiNotes.Add(new MIDINoteMessage(NoteMidiMapper(i), OctaveMidiMapper(i), keyDownVelocity));
            }
        }

        return midiNotes;
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

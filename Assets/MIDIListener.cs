using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDIListener : MonoBehaviour
{
    string[] noteStrings = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    [SerializeField] Transform piano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(MidiJack.MidiMaster.GetKeyDown(80));
        for (int i = 1; i < 127; i++)
        {
            //bool isKeyDown = MidiJack.MidiMaster.GetKeyDown(i);
            float keyDownSpeed = MidiJack.MidiMaster.GetKey(i);
            bool isKeyDown = keyDownSpeed > 0;
            if (isKeyDown)
            {
                //print($"{i} {isKeyDown}");
                print(NoteOctaveMidiMapper(i));
                Transform pianoKey = piano.Find(NoteMidiMapper(i));
                if(pianoKey != null)
                {
                    Key key = pianoKey.GetComponent<Key>();
                    key.PressKey();
                }
            }
        }
    }

    string NoteOctaveMidiMapper(int midiNoteNumber)
    {
        int octave = (midiNoteNumber / 12) - 1;
        int noteIndex = midiNoteNumber % 12;
        string note = noteStrings[noteIndex];
        return $"{note}{octave}";
    }

    string NoteMidiMapper(int midiNoteNumber)
    {
        int noteIndex = midiNoteNumber % 12;
        return noteStrings[noteIndex];
    }
}

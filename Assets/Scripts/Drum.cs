using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{
    [SerializeField] MIDIListenerHub midiHub;
    [SerializeField] DrumStick hatStick;
    [SerializeField] DrumStick snareStick;
    [SerializeField] DrumGrow snareDrum;
    [SerializeField] DrumGrow hiHatTop;
    [SerializeField] DrumGrow kickStar;

    // Update is called once per frame
    void Update()
    {
        HitHats();
        HitSnare();
        HitKick();
    }

    void HitHats()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiHats = midiHub.MidiChannelRead(5);
        foreach(MIDIListenerHub.MIDINoteMessage hat in midiHats)
        {
            if (hatStick.atStart)
            {
                hatStick.Hit();
            }
            hiHatTop.Hit();
        }
    }

    void HitSnare()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiSnares = midiHub.MidiChannelRead(6);
        foreach (MIDIListenerHub.MIDINoteMessage snare in midiSnares)
        {
            if (snareStick.atStart)
            {
                snareStick.Hit();
            }
            snareDrum.Hit();
        }
    }

    void HitKick()
    {
        List<MIDIListenerHub.MIDINoteMessage> midiKicks = midiHub.MidiChannelRead(7);
        foreach (MIDIListenerHub.MIDINoteMessage kick in midiKicks)
        {
            kickStar.Hit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public int channel;
    public void ReceiveNote(string note, int octave, float velocity)
    {
        print($"Channel: {channel} Note: {note} Octave: {octave} Vel: {velocity}");
    }
}

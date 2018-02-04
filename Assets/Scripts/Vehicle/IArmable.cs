using System;

public interface IArmable
{
    void ProcessArm (bool arm);
    void Arm ();
    void Disarm ();
    bool Armed { get; }
}
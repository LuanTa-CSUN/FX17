using System;

public interface IArmable
{
    void Arm ();
    void Disarm ();
    bool Armed { get; }
}
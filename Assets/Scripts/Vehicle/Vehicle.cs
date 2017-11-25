using System;
using System.Collections.Generic;

public class Vehicle : IArmable, INavigation
{
    public Vehicle() { }

    Pose PositionDesired { get; set; }
    Pose PositionActual { get; private set;}
    List<Pose> Mission {get; set;}

    void ProcessArm (bool arm, Action<bool> callback = null)
    {
        if(arm)
        {
            Arm(callback);
        }
        else
        {
            Disarm(callback);
        }
    }

    void Arm (Action<bool> callback = null)
    {
        Arming = true;
        throw System.NotImplementedException();
    }

    void Disarm (Action<bool> callback = null)
    {
        Disarming = true;
        throw System.NotImplementedException();
    }

    bool Armed { get; private set; }
    bool ProcessingArm 
    { 
        get
        {
            return Disarming || Arming;
        } 
    }

    bool Disarming { get; private set; }
    bool Arming { get; private set; }
} 
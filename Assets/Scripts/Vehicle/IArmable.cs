public interface IArmable
{
    void ProcessArm (bool arm, Action<bool> callback = null);
    void Arm (Action<bool> callback = null);
    void Disarm (Action<bool> callback = null);
    bool Armed { get; }
    bool ProcessingArm { get; }
    bool Disarming { get; }
    bool Arming { get; }
}
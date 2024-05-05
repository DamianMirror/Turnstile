namespace lab32;

public class TurnstileLogInfo
{
    public DateTime Time;
    public GateAction Action;
    private PassInfo Pass { get; }
    
    public TurnstileLogInfo(PassInfo pass, GateAction action)
    {
        Time = DateTime.Now;
        Action = action;
        Pass = pass;
    }
    
    public string GetPassName()
    {
        return Pass.Name;
    }
    
}

public enum GateAction
{
    Enter,
    Exit
}
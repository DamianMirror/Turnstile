namespace ConsoleApp1;

public class PassInfo
{
    private static int IdNums = 0;
    
    public string Name;
    public PassTypes PassType;
    public Status Status;
    public int PassesAmountLeft;
    private int SecurityLevel { get; }
    private string ID { get; }
    
    public PassInfo(string name, Status status, PassTypes passType, int securityLevel = 1, int passesAmountLeft = 0)
    {
        ID = "x" + IdNums++.ToString("D8");
        Name = name;
        Status = status;
        PassType = passType;
        PassesAmountLeft = passesAmountLeft;
        SecurityLevel = securityLevel;
    }
    public int GetSecurityLevel()
    {
        return SecurityLevel;
    }
    
}

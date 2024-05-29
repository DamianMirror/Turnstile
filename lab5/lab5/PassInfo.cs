namespace lab32;

public class PassInfo
{
    private static int IdNums = 0;
    
    public string Name;
    public PassTypes PassType;
    public Status Status;
    public int PassesAmountLeft = 0;
    private int SecurityLevel { get; set; } = 0;
    private string ID = "x" + IdNums++.ToString("D8");
    
    
    public int GetSecurityLevel()
    {
        return SecurityLevel;
    }
    
    public void SetSecurityLevel(int securityLevel)
    {
        SecurityLevel = securityLevel;
    }
    
    public int GetIDNums()
    {
        return IdNums;
    }
    
}

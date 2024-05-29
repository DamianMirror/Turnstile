namespace lab32;

public interface IPassInfoBuilder
{
    public PassInfoBuilder SetName(string name);
    public PassInfoBuilder SetStatus(Status status);
    public PassInfoBuilder SetPassType(PassTypes passType);
    public PassInfoBuilder SetSecurityLevel(int securityLevel);
    public PassInfoBuilder SetPassesAmountLeft(int passesAmountLeft);
    public PassInfo Build();
}
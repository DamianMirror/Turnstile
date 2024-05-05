namespace ConsoleApp1;

public interface ITurnstileMonitor
{
    public void PrintPasses(GateAction action);
    public void PrintPasses();
    public void PrintNotAllowedPasses();
    public void PrintPeopleInside();
}
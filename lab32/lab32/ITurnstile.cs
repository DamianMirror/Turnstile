namespace lab32;

public interface ITurnstile
{
	public void PassThrough(PassInfo pass, GateAction action);
	public DoublyLinkedList GetLogs();
	public void PrintPasses(GateAction action);
	public void PrintPasses();
	public void PrintNotAllowedPasses();
	public void PrintPeopleInside();
}


namespace lab32
{
	public class Turnstile : ITurnstile
	{
		public Status Type;
		private static int IdNums = 0;
		private string ID;
		public static int TurnstileNumber = 0;
		private PassTypes PassTypeNeeded { get; }
		private int SecurityLevel { get; }
		
		public int countTotalPeopleInside = 0;
		public int countTotalNotAllowedPasses = 0;
		public DoublyLinkedList Logs = new();
		
		public Turnstile(Status type, PassTypes passTypeNeeded, int securityLevel = 1)
		{
			Type = type;
			TurnstileNumber++;
			ID = "x" + IdNums++.ToString("D8");
			PassTypeNeeded = passTypeNeeded;
			SecurityLevel = securityLevel;
		}
		
		public int GetSecurityLevel()
		{
			return SecurityLevel;
		}
		
		public PassTypes GetPassTypeNeeded()
		{
			return PassTypeNeeded;
		}
		
		public Status GetStatus()
		{
			return Type;
		}
		
		public DoublyLinkedList GetLogs()
		{
			return Logs;
		}
		
		private void LogEntryExit(PassInfo pass, GateAction action)
		{
			// Determine the action type and log the corresponding entry or exit event.
			string entityType = pass.Status == Status.Customer ? "Customer" : "Worker";
			string actionType = action == GateAction.Enter ? "entered" : "exited";

			if (action != GateAction.Enter && action != GateAction.Exit)
			{
				Console.WriteLine("Invalid action");
				return;
			}

			Console.WriteLine($"{entityType} {pass.Name} {actionType} at {DateTime.Now}");
			Logs.Add(new TurnstileLogInfo(pass, action));

			// Update the count of people inside based on the action.
			countTotalPeopleInside += action == GateAction.Enter ? 1 : -1;
		}
		
		public void PassThrough(PassInfo pass, GateAction action)
		{
			// Validate pass type.
			if (pass.PassType != GetPassTypeNeeded() && GetPassTypeNeeded() != PassTypes.Any)
			{
				Console.WriteLine($"Pass is not allowed for {pass.Name}: Wrong pass type.");
				countTotalNotAllowedPasses++;
				return;
			}

			// Check security level and pass status.
			if (pass.GetSecurityLevel() < GetSecurityLevel() || pass.Status != Type)
			{
				Console.WriteLine($"Pass is not allowed for {pass.Name}: Security level or status mismatch.");
				countTotalNotAllowedPasses++;
				return;
			}

			// Check for passes remaining if the pass is temporary.
			if (pass.PassType == PassTypes.Temporary)
			{
				if (pass.PassesAmountLeft <= 0)
				{
					Console.WriteLine($"Pass is not allowed for {pass.Name}: Insufficient passes remaining.");
					countTotalNotAllowedPasses++;
					return;
				}

				pass.PassesAmountLeft--;
			}

			Console.WriteLine("Pass is allowed");
			LogEntryExit(pass, action);
		}
		
		public void PrintPasses()
		{
			Logs.Display();
		}
		
		public void PrintPasses(GateAction action)
		{
			Logs.Display(action);
		}
		
		public void PrintNotAllowedPasses()
		{
			Console.WriteLine("Passes not allowed: " + countTotalNotAllowedPasses);
		}

		public void PrintPeopleInside()
		{
			Console.WriteLine("People inside: " + countTotalPeopleInside);
		}
	}
}

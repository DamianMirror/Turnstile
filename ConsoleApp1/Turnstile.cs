using System;

namespace ConsoleApp1
{
	public class Turnstile : ITurnstile, ITurnstileMonitor
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
		
		private void LogEntryExit(PassInfo pass, GateAction action)
		{
			if(action == GateAction.Enter)
			{
				if (pass.Status == Status.Customer)
				{
					Console.WriteLine("Customer " + pass.Name + " entered at " + DateTime.Now);
				}
				else
				{
					Console.WriteLine("Worker " + pass.Name + " entered at " + DateTime.Now);
				}
				Logs.Add(new TurnstileLogInfo(pass, action));
				countTotalPeopleInside++;
			}
			else if(action == GateAction.Exit)
			{
				if (pass.Status == Status.Customer)
				{
					Console.WriteLine("Customer " + pass.Name + " exited at " + DateTime.Now);
				}
				else
				{
					Console.WriteLine("Worker " + pass.Name + " exited at " + DateTime.Now);
				}
				Logs.Add(new TurnstileLogInfo(pass, action));
				countTotalPeopleInside--;
			}
			else
			{
				Console.WriteLine("Invalid action");
			}
		}
		
		public void PassThrough(PassInfo pass, GateAction action)
		{
			// Check if the pass type is what's needed or if any pass type is accepted
			if (pass.PassType == GetPassTypeNeeded() || GetPassTypeNeeded() == PassTypes.Any)
			{
				// Check security level and pass status for worker
				if (pass.GetSecurityLevel() >= GetSecurityLevel() && pass.Status == Type)
				{
					// Check for temporary pass with passes remaining
					if(pass.PassType == PassTypes.Temporary && pass.PassesAmountLeft <= 0)
					{
						Console.WriteLine("Pass is not allowed: Insufficient passes remaining.");
						countTotalNotAllowedPasses++;
					}
					else
					{
						if(pass.PassType == PassTypes.Temporary)
						{
							pass.PassesAmountLeft--;
						}
						Console.WriteLine("Pass is allowed");
						LogEntryExit(pass, action);
					}
				}
				else
				{
					Console.WriteLine("Pass is not allowed: Security level or status mismatch.");
					countTotalNotAllowedPasses++;
				}
			}
			else
			{
				Console.WriteLine("Pass is not allowed: Wrong pass type.");
				countTotalNotAllowedPasses++;
			}
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

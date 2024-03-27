using System;

namespace ConsoleApp1
{
	public interface ITurnstile
	{
		public void PassThrough(PassInfo pass, GateAction action);
	}
}
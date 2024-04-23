using Microsoft.Extensions.DependencyInjection;
//unity container
using Unity;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            
            var services = new ServiceCollection();
            services.AddSingleton<ITurnstile, Turnstile>();

            // Створення сервіс-провайдера
            var serviceProvider = services.BuildServiceProvider();

            // Використання залежностей
            var turnstile1 = serviceProvider.GetRequiredService<ITurnstile>();
            var turnstile2 = serviceProvider.GetRequiredService<ITurnstile>();
            
            //задання параметрів для кожного турнікету

            /*
            PassInfo pass1 = new PassInfo("John", Status.Customer, PassTypes.Temporary, 2, 5);
            PassInfo pass2 = new PassInfo("Riko", Status.Worker, PassTypes.Permanent, 4);
            PassInfo pass3 = new PassInfo("Masha", Status.Worker, PassTypes.Permanent, 2);

            Turnstile turnstile1 = new Turnstile(Status.Customer, PassTypes.Temporary, 2);
            Turnstile turnstile2 = new Turnstile(Status.Worker, PassTypes.Permanent, 4);
            Turnstile turnstile3 = new Turnstile(Status.Worker, PassTypes.Any, 1);

            turnstile1.PassThrough(pass1, GateAction.Enter);
            turnstile1.PassThrough(pass2, GateAction.Enter);
            turnstile1.PassThrough(pass3, GateAction.Enter);
            turnstile1.PrintPeopleInside();

            turnstile2.PassThrough(pass2, GateAction.Enter);
            turnstile2.PassThrough(pass3, GateAction.Enter);
            turnstile2.PrintPeopleInside();
            turnstile1.PassThrough(pass1, GateAction.Exit);
            turnstile1.PrintPeopleInside();
            turnstile2.PrintPeopleInside();

            turnstile1.PrintNotAllowedPasses();
            turnstile2.PrintNotAllowedPasses();

            turnstile1.PrintPasses();
            turnstile1.PrintPasses(GateAction.Enter);
            turnstile1.PrintPasses(GateAction.Exit);
            */
        }
    }
}


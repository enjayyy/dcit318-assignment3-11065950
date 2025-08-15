namespace FinanceManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new FinanceApp();
            app.Run();

            Console.WriteLine("\nDone. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}

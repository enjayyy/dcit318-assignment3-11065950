namespace HealthSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new HealthSystemApp();

            app.SeedData();
            app.BuildPrescriptionMap();

            app.PrintAllPatients();

            Console.Write("\nEnter a Patient ID to view prescriptions: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                app.PrintPrescriptionsForPatient(id);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("\nDone. Press Enter to exit...");
            Console.ReadLine();
        }
    }
}

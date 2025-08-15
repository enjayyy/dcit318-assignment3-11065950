using System;
using System.Collections.Generic;
using System.Linq;
using HealthSystem.Models;
using HealthSystem.Repositories;

namespace HealthSystem
{
    public class HealthSystemApp
    {
        private readonly Repository<Patient> _patientRepo = new();
        private readonly Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        public void SeedData()
        {
            // Add Patients
            _patientRepo.Add(new Patient(1, "Alice Johnson", 29, "Female"));
            _patientRepo.Add(new Patient(2, "Bob Smith", 40, "Male"));
            _patientRepo.Add(new Patient(3, "Charlie Adams", 35, "Male"));

            // Add Prescriptions
            _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Paracetamol", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Ibuprofen", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(4, 3, "Metformin", DateTime.Now.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(5, 1, "Vitamin C", DateTime.Now));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap = _prescriptionRepo
                .GetAll()
                .GroupBy(p => p.PatientId)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                );
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("\nAll Patients:");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var p in _prescriptionMap[patientId])
                {
                    Console.WriteLine(p);
                }
            }
            else
            {
                Console.WriteLine($"\nNo prescriptions found for Patient ID {patientId}");
            }
        }
    }
}

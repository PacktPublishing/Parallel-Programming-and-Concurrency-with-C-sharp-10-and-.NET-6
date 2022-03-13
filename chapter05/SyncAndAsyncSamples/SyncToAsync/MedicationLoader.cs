using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.SyncToAsync
{
    public class MedicationLoader
    {
        private HealthcareService _healthcareService;
        public MedicationLoader()
        {
            _healthcareService = new HealthcareService();
        }
        public Patient? GetPatientAndMedications(int patientId)
        {
            Patient? patient = null;
            try
            {
                patient = _healthcareService.GetPatientInfoAsync(patientId).Result;
            }
            catch (AggregateException ae)
            {
                Console.WriteLine($"Error loading patient. Message: {ae.Flatten().Message}");
            }

            if (patient != null)
            {
                patient = ProcessPatientInfo(patient);
                return patient;
            }
            else
            {
                return null;
            }
        }
        private Patient ProcessPatientInfo(Patient patient)
        {
            // Add additional processing here.
            return patient;
        }
    }
}
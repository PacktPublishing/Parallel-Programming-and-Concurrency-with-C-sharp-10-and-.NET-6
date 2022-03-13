using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.SyncToAsync
{
    public class HealthcareService
    {
        public async Task<Patient> GetPatientInfoAsync(int patientId)
        {
            await Task.Delay(2000);

            Patient patient = new()
            {
                Id = patientId,
                Name = "Smith, Terry",
                PrimaryCareProvider = new Provider
                {
                    Id = 999,
                    Name = "Dr. Amy Ng"
                },
                Medications = new List<Medication>
                {
                    new Medication { Id = 1, Name = "acetaminophen" },
                    new Medication { Id = 2, Name = "hydrocortisone cream" }
                }
            };

            return patient;
        }
    }
}
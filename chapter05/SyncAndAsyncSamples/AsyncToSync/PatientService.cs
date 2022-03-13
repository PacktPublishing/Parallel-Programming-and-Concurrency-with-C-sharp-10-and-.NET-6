using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.AsyncToSync
{
    public class PatientService
    {
        public Patient GetPatientInfo(int patientId)
        {
            Thread.Sleep(2000);

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
using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples
{
    public class ParallelPatientLoader
    {
        private Patient _patient;
        private Provider _provider;
        private List<Medication> _medications;

        public async Task<Patient> LoadPatientAsync(int patientId)
        {
            var taskList = new List<Task>
            {
                LoadPatientInfoAsync(patientId),
                LoadProviderAsync(patientId),
                LoadMedicationsAsync(patientId)
            };

            await Task.WhenAll(taskList.ToArray());
            _patient.Medications = _medications;
            _patient.PrimaryCareProvider = _provider;

            return _patient;
        }

        public Patient LoadPatient(int patientId)
        {
            var taskList = new List<Task>
            {
                LoadPatientInfoAsync(patientId),
                LoadProviderAsync(patientId),
                LoadMedicationsAsync(patientId)
            };

            Task.WaitAll(taskList.ToArray());
            _patient.Medications = _medications;
            _patient.PrimaryCareProvider = _provider;

            return _patient;
        }

        public async Task LoadPatientInfoAsync(int patientId)
        {
            await Task.Delay(100);
            _patient = new Patient { Id = patientId, Name = "Smith, Gail" };
        }

        public async Task LoadProviderAsync(int patientId)
        {
            await Task.Delay(100);
            _provider = new Provider { Id = 44, Name = "Dr. Sammy Hamm" };
        }

        public async Task LoadMedicationsAsync(int patientId)
        {
            await Task.Delay(100);
            _medications = new List<Medication>
                {
                    new Medication { Id = 1, Name = "acetaminophen" },
                    new Medication { Id = 2, Name = "hydrocortisone cream" }
                };
        }
    }
}

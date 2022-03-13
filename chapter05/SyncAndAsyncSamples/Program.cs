using SyncAndAsyncSamples.AsyncToSync;
using SyncAndAsyncSamples.Models;
//using SyncAndAsyncSamples.SyncToAsync;

//Console.WriteLine("Hello, sync to async world!");
//var medLoader = new MedicationLoader();
//Patient? patient = medLoader.GetPatientAndMedications(123);

//Console.WriteLine($"Loaded patient: {patient.Name} with {patient.Medications.Count} mediations.");

Console.WriteLine("Hello, async to sync world!");
var loader = new PatientLoader();
Patient? patient = await loader.GetPatientAndMedsAsync(123);

Console.WriteLine($"Loaded patient: {patient.Name} with {patient.Medications.Count} mediations.");
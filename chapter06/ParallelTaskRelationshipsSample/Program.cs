using ParallelTaskRelationshipsSample;

var parallelWork = new ParallelWork();

//parallelWork.DoAllWork();
//parallelWork.DoAllWorkAttached();
parallelWork.DoAllWorkDenyAttach();
Console.ReadKey();
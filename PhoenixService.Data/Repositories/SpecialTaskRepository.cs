using NCore.Models;
using NCore.Specifications.Factories;
using PhoenixService.Data.Interfaces.Repositories;
using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Repositories
{
    public class SpecialTaskRepository : ISpecialTaskRepository
    {
        private readonly IEntityFactory<EspecialTask> especialTaskFactory;

        public SpecialTaskRepository(IEntityFactory<EspecialTask> especialTaskFactory)
        {
            this.especialTaskFactory = especialTaskFactory;
        }

        public Task Save(SpecialTask task)
        {
            var nTask = new EspecialTask
            {
                Index = task.PhoenixId,
                Patient = task.PatientName,
                DateIn = task.DateIn,
                InitializeType = task.InitializeType,
                EspecialList = task.EspecialListPhoenixId,
                Operator = task.OperatorPhoenixId,
                Department = task.DepartmentPhoenixId,
                StartTime = task.StartTime,
                Doctor = task.DoctorPhoenixId
            };

            especialTaskFactory.StoreIntoDb(nTask);

            return Task.CompletedTask;
        }
    }
}
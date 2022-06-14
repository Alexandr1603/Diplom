using System;
using TA.Domain.Results;
using TA.Domain.Workers;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Workers
{
    public class WorkersService
    {
        private readonly WorkersRepository _workersRepository;

        public WorkersService()
        {
            _workersRepository = new WorkersRepository();
        }

        public Worker? GetWorker(Guid workerId)
        {
            return _workersRepository.GetWorker(workerId);
        }

        public Worker? GetWorker(String workerLogin)
        {
            return _workersRepository.GetWorker(workerLogin);
        }

        public Worker[] GetAllWorkers()
        {
            return _workersRepository.GetAllWorkers();
        }
        public Result EntryWorker(Worker user, String workerPassword)
        {
            if (user is null) return Result.Fail("Данного пользователя не существует");
            if (user.Password != workerPassword) return Result.Fail("Пароль не верен");

            return Result.Success();
        }
        public void DeleteWorker(Guid workerId)
        {
            _workersRepository.DeleteWorker(workerId);
        }
        public Result SaveWorkerEntry(WorkerBlank blank)
        {
            if (blank.Login == "") throw new Exception("Введите логин");
            if (blank.Password == "") throw new Exception("Введите пароль");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _workersRepository.SaveWorkerEntry(blank);
            return Result.Success();
        }
    }
}

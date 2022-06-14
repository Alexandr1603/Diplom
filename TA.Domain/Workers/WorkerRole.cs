using System;
using System.ComponentModel.DataAnnotations;

namespace TA.Domain.Workers
{
    public enum WorkerRole
    {
        Admin = 1,
        Manager = 2
    }

    public static class WorkerRoleExtensions
    {
        public static String GetDisplayName(this WorkerRole workerRole)
        {
            switch (workerRole)
            {
                case WorkerRole.Admin: return "Админ";
                case WorkerRole.Manager: return "Менеджер";

                default: throw new Exception("Роль не найдена");
            }
        }
    }
}
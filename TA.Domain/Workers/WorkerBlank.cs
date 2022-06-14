using System;

namespace TA.Domain.Workers
{
    public class WorkerBlank
    {
        public Guid? Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public WorkerRole Role { get; set; }

        public WorkerBlank() { }
        public WorkerBlank(Guid id, String firstName, String lastName, WorkerRole role)
        {
            Id = id;
            Login = firstName;
            Password = lastName;
            Role = role;
        }
    }
}

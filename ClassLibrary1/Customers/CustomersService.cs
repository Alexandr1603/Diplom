using System;
using TA.Domain.Results;
using TA.Domain.Customers;
using TA.EntitiesCore.Repositories;

namespace TA.Services.Customers
{
    public class CustomersService
    {
        private readonly CustomersRepository _customersService;

        public CustomersService()
        {
            _customersService = new CustomersRepository();
        }

        public Customer? GetCustomer(Guid CustomerId)
        {
            return _customersService.GetCustomer(CustomerId);
        }

        public Customer[] GetAllCustomers()
        {
            return _customersService.GetAllCustomers();
        }
        public void DeleteCustomer(Guid CustomerId)
        {
            _customersService.DeleteCustomer(CustomerId);
        }
        public Result SaveCustomerEntry(CustomerBlank blank)
        {
            if (blank.Name == "") throw new Exception("Введите имя");
            if (blank.Surname == "") throw new Exception("Введите фамилию");
            if (blank.Patronymic == "") throw new Exception("Введите отчество");
            if (blank.Passport == "") throw new Exception("Введите паспорт");
            if (blank.Phone == "") throw new Exception("Введите телефон");
            if (blank.Email == "") throw new Exception("Введите почту");
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _customersService.SaveCustomerEntry(blank);
            return Result.Success();
        }
    }
}

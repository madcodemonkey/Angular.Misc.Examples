using System.Collections.Generic;
using ACME.Models;

namespace ACME.Services
{
    public interface IPeopleService
    {
        List<Person> GetAll();
        Person GetById(int id);
        bool Update(Person person);
        void Add(Person person);
        void Delete(Person person);
    }
}
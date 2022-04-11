using ACME.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Services
{
    public class PeopleService : IPeopleService
    {
        private List<Person> _peopleList = new List<Person>();

        public PeopleService()
        {
            PopulatePeople();
        }

        public List<Person> GetAll()
        {
            return _peopleList;
        }

        public Person GetById(int id)
        {
            return _peopleList.FirstOrDefault(w => w.Id == id);
        }

        public bool Update(Person person)
        {
            var existingPerson = GetById(person.Id);
            if (existingPerson == null) return false;

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Email = person.Email;
            existingPerson.DateOfBirth = person.DateOfBirth;
            existingPerson.AddressLine1 = person.AddressLine1;
            existingPerson.AddressLine2 = person.AddressLine2;
            existingPerson.StateId = person.StateId;
            existingPerson.PostalCode = person.PostalCode;

            return true;
        }

        public void Add(Person person)
        {
            lock (_peopleList)
            {
                if (person.Id != 0) throw new ArgumentException("Please don't add existing users!");

                int maxId = _peopleList.Max(w => w.Id);
                person.Id = maxId + 1;
                _peopleList.Add(person);
            }
        }

        public void Delete(Person person)
        {
            lock (_peopleList)
            {
                var existingPerson = _peopleList.FirstOrDefault(w => w.Id == person.Id);
                if (existingPerson != null)
                {
                    _peopleList.Remove(existingPerson);
                }
            }
        }

        private void PopulatePeople()
        {
            lock (_peopleList)
            {
                if (_peopleList.Count > 0) return;

                _peopleList.Add(new Person
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Hope",
                    Email = "bob.hope@gmail.com",
                    DateOfBirth = new DateTime(1903, 5, 29),
                    AddressLine1 = "2627 N Hollywood Way",
                    City = "Burbank",
                    StateId = 5,
                    PostalCode = "91505"
                });

                _peopleList.Add(new Person
                {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Thompson",
                    Email = "bob.hope@gmail.com",
                    DateOfBirth = new DateTime(1976, 3, 20),
                    AddressLine1 = "416 Sid Snyder Ave SW",
                    City = "Olympia",
                    StateId = 49,
                    PostalCode = "98504"
                });
            }
        }


    }
}

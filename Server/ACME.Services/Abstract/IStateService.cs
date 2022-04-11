using System.Collections.Generic;
using ACME.Models;

namespace ACME.Services
{
    public interface IStateService
    {
        List<LookupItem> GetAll();
        LookupItem GetById(int id);
        bool Update(LookupItem state);
        void Add(LookupItem state);
        void Delete(LookupItem state);
    }
}
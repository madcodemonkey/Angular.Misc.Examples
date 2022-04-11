using System;
using ACME.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Services
{
    public class StateService : IStateService
    {
        private readonly List<LookupItem> _stateList = new List<LookupItem>();

        public StateService()
        {
            PopulateStates();
        }

        public List<LookupItem> GetAll()
        {
            return _stateList;
        }

        public LookupItem GetById(int id)
        {
            return _stateList.FirstOrDefault(w => w.Id == id);
        }

        public bool Update(LookupItem state)
        {
            var item = GetById(state.Id);
            if (item == null) return false;

            item.Name = state.Name;
            item.Description = state.Description;

            return true;
        }

        public void Add(LookupItem state)
        {
            lock (_stateList)
            {
                if (state.Id != 0) throw new ArgumentException("Please don't add existing states!");

                int maxId = _stateList.Max(w => w.Id);
                state.Id = maxId + 1;
                _stateList.Add(state);
            }
        }

        public void Delete(LookupItem state)
        {
            lock (_stateList)
            {
                var existingPerson = _stateList.FirstOrDefault(w => w.Id == state.Id);
                if (existingPerson != null)
                {
                    _stateList.Remove(existingPerson);
                }
            }
        }

        private void PopulateStates()
        {
            lock (_stateList)
            {
                if (_stateList.Count > 0) return;

                _stateList.Add(new LookupItem { Id = 1, Description = "Alabama", Name = "AL" });
                _stateList.Add(new LookupItem { Id = 2, Description = "Alaska", Name = "AK" });
                _stateList.Add(new LookupItem { Id = 3, Description = "Arizona", Name = "AZ" });
                _stateList.Add(new LookupItem { Id = 4, Description = "Arkansas", Name = "AR" });
                _stateList.Add(new LookupItem { Id = 5, Description = "California", Name = "CA" });
                _stateList.Add(new LookupItem { Id = 6, Description = "Colorado", Name = "CO" });
                _stateList.Add(new LookupItem { Id = 7, Description = "Connecticut", Name = "CT" });
                _stateList.Add(new LookupItem { Id = 8, Description = "Delaware", Name = "DE" });
                _stateList.Add(new LookupItem { Id = 9, Description = "District of Columbia", Name = "DC" });
                _stateList.Add(new LookupItem { Id = 10, Description = "Florida", Name = "FL" });
                _stateList.Add(new LookupItem { Id = 11, Description = "Georgia", Name = "GA" });
                _stateList.Add(new LookupItem { Id = 12, Description = "Hawaii", Name = "HI" });
                _stateList.Add(new LookupItem { Id = 13, Description = "Idaho", Name = "ID" });
                _stateList.Add(new LookupItem { Id = 14, Description = "Illinois", Name = "IL" });
                _stateList.Add(new LookupItem { Id = 15, Description = "Indiana", Name = "IN" });
                _stateList.Add(new LookupItem { Id = 16, Description = "Iowa", Name = "IA" });
                _stateList.Add(new LookupItem { Id = 17, Description = "Kansas", Name = "KS" });
                _stateList.Add(new LookupItem { Id = 18, Description = "Kentucky", Name = "KY" });
                _stateList.Add(new LookupItem { Id = 19, Description = "Louisiana", Name = "LA" });
                _stateList.Add(new LookupItem { Id = 20, Description = "Maine", Name = "ME" });
                _stateList.Add(new LookupItem { Id = 21, Description = "Maryland", Name = "MD" });
                _stateList.Add(new LookupItem { Id = 22, Description = "Massachusetts", Name = "MA" });
                _stateList.Add(new LookupItem { Id = 23, Description = "Michigan", Name = "MI" });
                _stateList.Add(new LookupItem { Id = 24, Description = "Minnesota", Name = "MN" });
                _stateList.Add(new LookupItem { Id = 25, Description = "Mississippi", Name = "MS" });
                _stateList.Add(new LookupItem { Id = 26, Description = "Missouri", Name = "MO" });
                _stateList.Add(new LookupItem { Id = 27, Description = "Montana", Name = "MT" });
                _stateList.Add(new LookupItem { Id = 28, Description = "Nebraska", Name = "NE" });
                _stateList.Add(new LookupItem { Id = 29, Description = "Nevada", Name = "NV" });
                _stateList.Add(new LookupItem { Id = 30, Description = "New Hampshire", Name = "NH" });
                _stateList.Add(new LookupItem { Id = 31, Description = "New Jersey", Name = "NJ" });
                _stateList.Add(new LookupItem { Id = 32, Description = "New Mexico", Name = "NM" });
                _stateList.Add(new LookupItem { Id = 33, Description = "New York", Name = "NY" });
                _stateList.Add(new LookupItem { Id = 34, Description = "North Carolina", Name = "NC" });
                _stateList.Add(new LookupItem { Id = 35, Description = "North Dakota", Name = "ND" });
                _stateList.Add(new LookupItem { Id = 36, Description = "Ohio", Name = "OH" });
                _stateList.Add(new LookupItem { Id = 37, Description = "Oklahoma", Name = "OK" });
                _stateList.Add(new LookupItem { Id = 38, Description = "Oregon", Name = "OR" });
                _stateList.Add(new LookupItem { Id = 39, Description = "Pennsylvania", Name = "PA" });
                _stateList.Add(new LookupItem { Id = 40, Description = "Puerto Rico", Name = "PR" });
                _stateList.Add(new LookupItem { Id = 41, Description = "Rhode Island", Name = "RI" });
                _stateList.Add(new LookupItem { Id = 42, Description = "South Carolina", Name = "SC" });
                _stateList.Add(new LookupItem { Id = 43, Description = "South Dakota", Name = "SD" });
                _stateList.Add(new LookupItem { Id = 44, Description = "Tennessee", Name = "TN" });
                _stateList.Add(new LookupItem { Id = 45, Description = "Texas", Name = "TX" });
                _stateList.Add(new LookupItem { Id = 46, Description = "Utah", Name = "UT" });
                _stateList.Add(new LookupItem { Id = 47, Description = "Vermont", Name = "VT" });
                _stateList.Add(new LookupItem { Id = 48, Description = "Virginia", Name = "VA" });
                _stateList.Add(new LookupItem { Id = 49, Description = "Washington", Name = "WA" });
                _stateList.Add(new LookupItem { Id = 50, Description = "West Virginia", Name = "WV" });
                _stateList.Add(new LookupItem { Id = 51, Description = "Wisconsin", Name = "WI" });
                _stateList.Add(new LookupItem { Id = 52, Description = "Wyoming", Name = "WY" });

            }
        }
    }
}
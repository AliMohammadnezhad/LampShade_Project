using System;
using _0_FrameWork.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.AddressAgg
{
    public class Address:EntityBase
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string FullAddress { get; private set; }
        public int ZipCode { get; private set; }

        public long AccountId { get; private set; }
        public Account Account { get; private set; }

        public Address(string country, string state, string city,
            string fullAddress, int zipCode, long accountId)
        {
            Country = country;
            State = state;
            City = city;
            FullAddress = fullAddress;
            ZipCode = zipCode;
            AccountId = accountId;
            CreationDate = DateTime.Now;
        }

        public void Edit(string country, string state, string city,
            string fullAddress, int zipCode)
        {
            Country = country;
            State = state;
            City = city;
            FullAddress = fullAddress;
            ZipCode = zipCode;
        }
    }
}

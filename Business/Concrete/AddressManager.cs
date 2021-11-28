using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constans;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public List<Address> GetAll()
        {
            return _addressDal.GetAll(a=>a.Statement ==true);
        }

        public Address GetById(int id)
        {
            return _addressDal.Get(a => a.AddressId == id);
        }

        public void Update(Address entity)
        {
            if (CheckPhoneNumberIsCorrect(entity.HouseNumber) && CheckCountryIsCorrect(entity.Country))
            {
                _addressDal.Update(entity);
                Console.WriteLine(Messages.AddressUpdated);
            }
        }
        public void Delete(Address entity)
        {
            entity.Statement = false;
            _addressDal.Update(entity);

        }
        public void Add(Address entity)
        {
            if(CheckPhoneNumberIsCorrect(entity.HouseNumber) && CheckCountryIsCorrect(entity.Country))
            {
                _addressDal.Add(entity);
                Console.WriteLine(Messages.AddressAdded);
            }
        }

        private bool CheckCountryIsCorrect(string countryName)
        {
            if (countryName == "Turkey" || countryName=="Germany")
            {
                return true;
            }
            Console.WriteLine(Messages.AddressCountryMustBeTurkey);
            return false;
        }
        private bool CheckPhoneNumberIsCorrect(string houseNumber)
        {

            if (houseNumber.Length == 10 && houseNumber[0] != '0')
            {
                return true;
            }

            Console.WriteLine(Messages.PhoneNumberIsNotCorrect);
            return false;
        }
    }
}

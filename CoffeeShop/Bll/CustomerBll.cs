using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CoffeeShop.Repo;

namespace CoffeeShop.Bll
{
    
    public class CustomerBll
    {
        CustomerRepo _customerRepo = new CustomerRepo();
        public bool Add(int id,string name,string address, int contact)
        {
            return _customerRepo.Add(id,name,address,contact);
        }
        public bool IsContactExists(string contact)
        {
            return _customerRepo.IsContactExists(contact);
        }
        public DataTable Display()
        {
            return _customerRepo.Display();
        }
        public bool Delete(int id)
        {
            return _customerRepo.Delete(id);
        }
        public bool Update(int id,string name, string address, int contact)
        {
            return _customerRepo.Update(id,name, address, contact);
        }
      



    }
}

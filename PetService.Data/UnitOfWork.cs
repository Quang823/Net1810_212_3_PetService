using PetService.Data.Models;
using PetService.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Data
{
    public class UnitOfWork
    {
        private Net1810_212_3_PetServiceContext _unitOfWorkContext;
        private PaymentRepository _payment;

        public UnitOfWork() 

        {
            _unitOfWorkContext ??= new Net1810_212_3_PetServiceContext();
        }

        public PaymentRepository PaymentRepository 
        { 
            get 
            { 
                return _payment ??= new Repository.PaymentRepository(_unitOfWorkContext);
            } 
        }
    }
}

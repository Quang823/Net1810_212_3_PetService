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
        private PaymentRepository _payment;
        public UnitOfWork()
        { 
        }

        public PaymentRepository Repository 
        { 
            get 
            { 
                return _payment ??= new Repository.PaymentRepository(); 
            } 
        }

        public object PaymentRepository { get; set; }
    }
}

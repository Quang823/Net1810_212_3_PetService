using Microsoft.EntityFrameworkCore;
using PetService.Data.Base;
using PetService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Data.Repository
{
    public class PaymentRepository : GenericRepository<Payment>
    {
        
        public PaymentRepository() 
        { 

        }
        public PaymentRepository(Net1810_212_3_PetServiceContext context)=>_context=context;
        

  
    }


}
    

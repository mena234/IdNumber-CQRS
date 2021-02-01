using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  IdNumber.Application.Queries
{
   public interface IIdNumberQuery
    {
            Task<idNumberViewModel> GetIdNumberAsync(int id);

            Task<IEnumerable<idNumberViewModel>> GetAllIdNumbersAsync();
   }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH.Domain.DBModel;

namespace MH.Domain.IRepository
{
    public interface ITicketStatusRepository : IRepository<TicketStatus, int>
    {
        
    }
}
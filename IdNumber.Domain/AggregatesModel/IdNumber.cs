using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IdNumber.Domain.AggregatesModel
{
    public class IdNumber : Entity, IAggregateRoot
    {
        public IdNumber()
        {
            AddAttandanceStartedDomainEvent();
        }

        private void AddAttandanceStartedDomainEvent()
        {
            var IdNumberDomainEvent = new IdNumberDomainEvent(this);
            this.AddDomainEvent(IdNumberDomainEvent);
        }
    }
}

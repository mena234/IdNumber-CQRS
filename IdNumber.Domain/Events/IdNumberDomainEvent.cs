using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IdNumber.Domain.Events
{
    public class IdNumberDomainEvent : INotification
    {
        public int? BuildingCode { get; }

        public string BuildingType { get; }

        public string Conservativecode { get; }

        public IdNumberDomainEvent(int? buildingCode, string buildingType, string conservativecode)
        {
            BuildingCode = buildingCode;
            BuildingType = buildingType;
            Conservativecode = conservativecode;
        }
    }
}

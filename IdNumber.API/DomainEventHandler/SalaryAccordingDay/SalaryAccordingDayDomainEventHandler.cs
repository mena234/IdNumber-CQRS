using MediatR;
using Salaary.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Salary.Dmoain.AggregatesModel.EmployeeAggregate;

namespace Salary.API.DomainEventHandler.SalaryAccordingDay
{
    public class SalaryAccordingDayDomainEventHandler : INotificationHandler<SalaryAccordingDayDomainEvent>
    {
        private readonly ISalaryRepository salaryRepository;

        public SalaryAccordingDayDomainEventHandler(ISalaryRepository _salaryRepository)
        {
            salaryRepository = _salaryRepository ?? throw new ArgumentNullException(nameof(_salaryRepository));


        }

        public async Task Handle(SalaryAccordingDayDomainEvent notification, CancellationToken cancellationToken)
        {
            var NumOfDays = notification.attendance.days;

            var salaryFromEvent = Convert.ToDecimal(NumOfDays) * 150;

            var salary = new Salary.Dmoain.AggregatesModel.EmployeeAggregate.Salary(1, salaryFromEvent);


            salaryRepository.Add(salary);




        }


    }
}

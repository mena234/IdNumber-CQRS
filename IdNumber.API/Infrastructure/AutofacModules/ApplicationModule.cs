using Autofac;
using Salary.API.Application.Commands;
using Salary.API.Application.Queries;
using Salary.Dmoain.AggregatesModel.EmployeeAggregate;
using Salary.Domain.AggregatesModel.AttendanceAggregate;
using Salary.Infrastructure.Repository;
using System.Reflection;

namespace Microsoft.eShopOnContainers.Services.Ordering.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        :Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new IdNumberQueries(QueriesConnectionString))
                .As<ISalaryQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SalaryRepository>()
                .As<ISalaryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttandceRepsoitory>()
           .As<IAttandceRepository>()
           .InstancePerLifetimeScope();

            //builder.RegisterType<OrderRepository>()
            //    .As<IOrderRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(CreateSalaryCommandHandler).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}

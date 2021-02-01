using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IdNumber.Application.Queries;
using Dapper;

namespace Salary.API.Application.Queries
{
    public class IdNumberQueries : IIdNumberQuery

    {
        private string _connectionString = string.Empty;



        public IdNumberQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));

        }
        public async Task<IEnumerable<idNumberViewModel>> GetAllIdNumbersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var res = connection.QueryAsync<idNumberViewModel>("SELECT TOP (10) *  FROM [SalaryDb].[dbo].[Salary]");
                return await (res);

            }
        }

        public async Task<idNumberViewModel> GetIdNumberAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>
                    (@"Select * from [SalaryDb].[dbo].[Salary] where Id = @id"

                        , new { id }
                        );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapOrderItems(result);
            }
        }

        private idNumberViewModel MapOrderItems(dynamic result)
        {
            var Salary = new idNumberViewModel
            {
                Sal = result[0].Sal,
                EmpId = result[0].EmpId
            };

            return Salary;
        }

    }
}

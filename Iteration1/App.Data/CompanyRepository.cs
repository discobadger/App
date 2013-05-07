using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using App.Models;

namespace App.Data
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            Company company = null;
            var connectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "uspGetCompanyById"
                };

                var parameter = new SqlParameter("@CompanyId", SqlDbType.Int) { Value = id };
                command.Parameters.Add(parameter);

                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    company = new Company
                                      {
                                          Id = int.Parse(reader["CompanyId"].ToString()),
                                          Name = reader["Name"].ToString(),
                                          Classification = (Classification)int.Parse(reader["ClassificationId"].ToString())
                                      };
                }
            }

            return company;
        }
    }
}

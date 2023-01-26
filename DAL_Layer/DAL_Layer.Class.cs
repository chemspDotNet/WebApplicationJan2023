using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DAL_Layer.Models;

namespace DAL_Layer
{
    
    public class DAL_LayerClass
    {
        string connString = "Initial Catalog=ProductDB;Data Source=LAPTOP-AD3V6SHV\\SQLEXPRESS;Integrated Security=true;";
        public DataSet GetEmployees()
        {

            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("MyTest", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();

                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Employees - " + ex.Message.ToString());
            }
        }


        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into Employee (name, job, salary) values(@item,  )", connection);

                    //SqlParameter p = new SqlParameter("@name", employee.Name);

                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parameters[1] = new SqlParameter("@job", SqlDbType.NVarChar);
                    parameters[2] = new SqlParameter("@salary", SqlDbType.Money);

                    //if (newItemDescription.Trim() != string.Empty)
                    //    parameters[0].Value = newItemDescription.Trim();

                    parameters[0].Value = employee.Name;
                    parameters[1].Value = employee.Job;
                    parameters[2].Value = employee.Salary;

                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    var result = command.ExecuteNonQuery();
                    command.CommandTimeout = 6000;
                    connection.Close();
                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Employees - " + ex.Message.ToString());
            }
        }

    }
}


using Dapper;
using DapperMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DapperMvcProject.Repository
{
    public class EmpRepository
    {
        public SqlConnection con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }

        public void AddEmployee(EmpModel objEmp)
        {
            try
            {
                Connection();
                con.Open();
                con.Execute("AddNewEmpDetails", objEmp, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public List<EmpModel> GetAllEmployees()
        {
            try
            {
                Connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query< EmpModel > (con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void UpdateEmployee(EmpModel objUpdate)
        {
            try
            {
                Connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
                con.Close();
            }catch
            {
                throw;
            }
        }
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", Id);
                Connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
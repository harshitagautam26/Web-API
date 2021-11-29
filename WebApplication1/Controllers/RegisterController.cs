using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @"
                 select Id,username,password,
                  email,
                    address
                   from
                  dbo.tbl_register
                ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EMPLOYEESDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }




        public string Post(Register reg)
        {
            try
            {
                string query = @"
                            insert into dbo.tbl_register values
                    ( 
                         '" + reg.username + @"'
                         , '" + reg.password + @"'
                          , '" + reg.email + @"'
                           , '" + reg.address + @"'
                 

                         )
                        ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EMPLOYEESDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!";
            }
            catch (Exception)
            {
                return "Fail to Add!";
            }
        }
    }
}

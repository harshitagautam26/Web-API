using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
//using System.Web.UI.WebControls;

namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {

        [HttpGet]
        //[Authorize]
        public HttpResponseMessage Get()
        {

           
            string query = @"
                 select Id,
                  email,password
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

        [HttpPost]

        [Route("api/Login/post")]
        public string Post(Login lg)
        {
            try
            {
                
                    string query = "select * from dbo.tbl_register where password=" + lg.password;








                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EMPLOYEESDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                    return "Login Successfully!";
                
                
            }
           
            catch (Exception ex)
                {

                    return "Fail to Add!";

                }         
        }
    }
}




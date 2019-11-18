using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

    namespace MvcCrudOperation.Models
{
    public class GeosDBModel
    {
       
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);
        }
        // ********** VIEW STUDENT DETAILS ********************
        public List<GeosModel> GetStudent()
        {
            connection();
            List<GeosModel> studentlist = new List<GeosModel>();

            SqlCommand cmd = new SqlCommand("select * from tblEmployees", con);
           
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new GeosModel
                    {
                        id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        DeptName = Convert.ToString(dr["DeptName"]),
                    });
            }
            return studentlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(GeosModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("EditDetils", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@DeptName", smodel.DeptName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
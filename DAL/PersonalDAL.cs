using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonalDAL
    {
        public static List<Personel> Listele ()
        {
            List<Personel> personelListesi = new List<Personel>();
        SqlConnection conn = new SqlConnection("Server=303-01;Database=Northwind;uid=sa;pwd=1234;");
        conn.Open();

            SqlCommand cmd = new SqlCommand("Select EmployeeID,FirstName,LastName,Title from Employees", conn);

            SqlDataReader dr = cmd.ExecuteReader();

           while(dr.Read())
           {
                Personel p = new Personel();
                p.ID = Convert.ToInt32(dr["EmployeeID"]);
                p.Ad = dr["FirstName"].ToString();
                p.Soyad = dr["LastName"].ToString();
                p.Gorev = dr["Title"].ToString();
                personelListesi.Add(p);
           }

            dr.Close();
            conn.Close();
            return personelListesi;  
        }

      
    }
}

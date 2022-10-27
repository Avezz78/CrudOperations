using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations
{
    internal class operations
    {
        private SqlConnection con = new SqlConnection("Data Source=MOBACK;DataBase=master;Integrated Security=True");

        //created a method to perform create operation
        public void CreateUser()
        {
            try
            {
                con.Open();
                Console.Write("Enter Your Name : ");
                string userName = Console.ReadLine();
                Console.Write("Enter Your Age : ");
                int userAge = int.Parse(Console.ReadLine());
                SqlCommand insertCmd = new SqlCommand("insert into Userinfo(User_Name,User_age) values('" + userName + "'," + userAge + ")", con);
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Data Will be successfully inserted into the table");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //created a method to perform Retrieve operation
        public void RetriveUser()
        {
            try
            {
                con.Open();
                SqlCommand displaCmd = new SqlCommand("Select * From Userinfo", con);
                SqlDataReader dr = displaCmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("\nId :" + dr.GetValue(0).ToString());
                    Console.WriteLine("Name :" + dr.GetValue(1).ToString());
                    Console.WriteLine("Age :" + dr.GetValue(2).ToString());
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //created a method to perform update operation
        public void UpdateUser()
        {
            try
            {
                con.Open();
                string u_Name;
                Console.Write("Enter Your id that you would like to update : ");
                int u_Id = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Age that you would like to update : ");
                int u_Age = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Name that you would like to update : ");
                u_Name = Console.ReadLine();
                SqlCommand updateCmd = new SqlCommand("update Userinfo set User_age =  " + u_Age + " ,User_Name = '" + u_Name + "' where User_Id = " + u_Id + "", con);
                updateCmd.ExecuteNonQuery();
                Console.WriteLine("record updated succesfully :");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //created a method to perform delete operation
        public void DeleteUser()
        {
            try
            {
                con.Open();
                int d_Id;
                Console.Write("Enter Your id that you would like to delete : ");
                d_Id = int.Parse(Console.ReadLine());
                SqlCommand deleteCmd = new SqlCommand("Delete from Userinfo where User_Id = " + d_Id, con);
                deleteCmd.ExecuteNonQuery();
                Console.WriteLine("record Deleted succesfully :");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

using CustomerSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomerSystemApi.Services
{
    public class CustomerService
    {
        //資料庫連線字串
        private static readonly string cnstr = ConfigurationManager.ConnectionStrings["CustomerSystem"].ConnectionString;

        //資料庫連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        #region 取得所有顧客資料
        public List<customer> GetAllCustomer()
        {
            string sql = @"SELECT * FROM CUSTOMER";
            List<customer> CustomerList = new List<customer>();

            try
            {
                conn.Open();
                SqlCommand Sql_cmd = new SqlCommand();
                Sql_cmd.Connection = conn;
                Sql_cmd.CommandText = sql;

                SqlDataReader dr = Sql_cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        customer Data = new customer();
                        Data.Id = Convert.ToInt32(dr["Id"]);
                        Data.Name = dr["Name"].ToString();
                        Data.Phone = dr["Phone"].ToString();
                        Data.Email = dr["Email"].ToString();
                        Data.Address = dr["Address"].ToString();
                        CustomerList.Add(Data);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return CustomerList;
        }
        #endregion

        #region 取得某一顧客資料
        public customer GetOneCustomer(int Id)
        {
            string sql = @"SELECT * FROM CUSTOMER WHERE ID = @Id";
            customer Data = new customer();

            try
            {
                conn.Open();
                SqlCommand Sql_cmd = new SqlCommand();
                Sql_cmd.Connection = conn;
                Sql_cmd.CommandText = sql;

                Sql_cmd.Parameters.Clear();
                Sql_cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                SqlDataReader dr = Sql_cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.Name = dr["Name"].ToString();
                    Data.Phone = dr["Phone"].ToString();
                    Data.Email = dr["Email"].ToString();
                    Data.Address = dr["Address"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
        #endregion

        #region 新增顧客資料
        public int InsertCustomer(string name, string phone, string email, string address)
        {
            string sql = @"INSERT INTO CUSTOMER (NAME, PHONE, EMAIL, ADDRESS) VALUES (@NAME, @PHONE, @EMAIL, @ADDRESS)";
            int num = 0;

            try
            {
                conn.Open();
                SqlCommand Sql_cmd = new SqlCommand();
                Sql_cmd.Connection = conn;
                Sql_cmd.CommandText = sql;

                Sql_cmd.Parameters.Clear();
                Sql_cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
                Sql_cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = phone;
                Sql_cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = email;
                Sql_cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = address;

                num = Sql_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                num = 0;
            }
            finally
            {
                conn.Close();
            }
            return num;
        }
        #endregion

        #region 更新客戶資料
        public int UpdateCustomer(int id, string name, string phone, string email, string address)
        {
            string sql = @"UPDATE CUSTOMER SET NAME = @NAME , PHONE = @PHONE, EMAIL = @EMAIL, ADDRESS = @ADDRESS WHERE ID = @ID";
            int num = 0;

            try
            {
                conn.Open();
                SqlCommand Sql_cmd = new SqlCommand();
                Sql_cmd.Connection = conn;
                Sql_cmd.CommandText = sql;

                Sql_cmd.Parameters.Clear();
                Sql_cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                Sql_cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = name;
                Sql_cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = phone;
                Sql_cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = email;
                Sql_cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = address;

                num = Sql_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                num = 0;
            }
            finally
            {
                conn.Close();
            }
            return num;
        }
        #endregion

        #region 刪除客戶資料
        public int DeleteCustomer(int id)
        {
            conn.Open();
            string sql = @"DELETE FROM CUSTOMER WHERE ID = @ID";
            int num = 0;

            try
            {
                SqlCommand Sql_cmd = new SqlCommand();
                Sql_cmd.Connection = conn;
                Sql_cmd.CommandText = sql;

                Sql_cmd.Parameters.Clear();
                Sql_cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                num = Sql_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                num = 0;
            }
            finally
            {
                conn.Close();
            }
            return num;
        }
        #endregion
    }
}
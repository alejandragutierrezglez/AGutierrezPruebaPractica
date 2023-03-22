using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace BL
{
    public class Banco
    {
        public static ML.Result Add(ML.Banco banco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "BancoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[7];

                        parameter[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameter[0].Value = banco.Nombre.ToString();

                        parameter[1] = new SqlParameter("@NoEmpleados", System.Data.SqlDbType.Int);
                        parameter[1].Value = banco.NoEmpleados.ToString();

                        parameter[2] = new SqlParameter("@NoSucursales", System.Data.SqlDbType.Int);
                        parameter[2].Value = banco.NoSucursales.ToString();


                        parameter[3] = new SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                        parameter[3].Value = banco.Pais.IdPais.ToString();

                        parameter[4] = new SqlParameter("@Capital", System.Data.SqlDbType.Decimal);
                        parameter[4].Value = banco.Capital.ToString();


                        parameter[5] = new SqlParameter("@IdRazonSocial", System.Data.SqlDbType.Int);
                        parameter[5].Value = banco.RazonSocial.IdRazonSocial.ToString();

                        parameter[6] = new SqlParameter("@NoClientes", System.Data.SqlDbType.Int);
                        parameter[6].Value = banco.NoClientes.ToString();

                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Banco banco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "BancoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[8];

                        parameter[0] = new SqlParameter("@IdBanco", System.Data.SqlDbType.VarChar);
                        parameter[0].Value = banco.IdBanco.ToString();


                        parameter[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameter[1].Value = banco.Nombre.ToString();

                        parameter[2] = new SqlParameter("@NoEmpleados", System.Data.SqlDbType.Int);
                        parameter[2].Value = banco.NoEmpleados.ToString();

                        parameter[3] = new SqlParameter("@NoSucursales", System.Data.SqlDbType.Int);
                        parameter[3].Value = banco.NoSucursales.ToString();


                        parameter[4] = new SqlParameter("@IdPais", System.Data.SqlDbType.Int);
                        parameter[4].Value = banco.Pais.IdPais.ToString();

                        parameter[5] = new SqlParameter("@Capital", System.Data.SqlDbType.Decimal);
                        parameter[5].Value = banco.Capital.ToString();


                        parameter[6] = new SqlParameter("@IdRazonSocial", System.Data.SqlDbType.Int);
                        parameter[6].Value = banco.RazonSocial.IdRazonSocial.ToString();

                        parameter[7] = new SqlParameter("@NoClientes", System.Data.SqlDbType.Int);
                        parameter[7].Value = banco.NoClientes.ToString();

                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(ML.Banco banco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "BancoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parameter = new SqlParameter[1];

                        parameter[0] = new SqlParameter("@IdBanco", System.Data.SqlDbType.VarChar);
                        parameter[0].Value = banco.IdBanco.ToString();

                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "BancoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dataTableBanco = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTableBanco);

                        if (dataTableBanco.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in dataTableBanco.Rows)
                            {

                                ML.Banco banco = new ML.Banco();
                                banco.IdBanco = int.Parse(row[0].ToString());
                                banco.Nombre = row[1].ToString();
                                banco.NoEmpleados = int.Parse(row[2].ToString());
                                banco.NoSucursales = int.Parse(row[3].ToString());
                                banco.Pais = new ML.Pais();
                                banco.Pais.IdPais = int.Parse(row[4].ToString());
                                banco.Capital= decimal.Parse(row[5].ToString());
                                banco.RazonSocial= new ML.RazonSocial();
                                banco.RazonSocial.IdRazonSocial= int.Parse(row[6].ToString());
                                banco.NoClientes = int.Parse(row[7].ToString());

                                result.Objects.Add(banco);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }
    }
}

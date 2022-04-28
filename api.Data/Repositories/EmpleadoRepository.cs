using api.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Data.Repositories
{
    public class EmpleadoRepository : IEmpleadosRepository
    {
        private MySQLConfiguration _connectionString;
        public EmpleadoRepository(MySQLConfiguration connectionStrin)
        {
            _connectionString = connectionStrin;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

       

        public async Task<IEnumerable<Empleado>> GetAllEmpleados()
        {
          var db = dbConnection();
            var sql = @"
                       SELECT id, nombre, correo, direccion
                        FROM  empleados";
            return await db.QueryAsync<Empleado>(sql, new { });

        }

        public async Task<Empleado> GetEmpleadoDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                       SELECT id, nombre, correo, direccion
                        FROM  empleados
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Empleado>(sql, new { Id = id });
        }

        public async Task<bool> InsertEmpleado(Empleado empleado)
        {
            var db = dbConnection();
            var sql = @"
                       INSERT INTO empleados  ( nombre, correo, direccion)
                        VALUES (@Nombre, @Correo, @Direccion)";

            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Correo, empleado.Direccion });
            return result > 0;
                }

        public async Task<bool> UpdateEmpleado(Empleado empleado)
        {
            var db = dbConnection();
            var sql = @"
                      UPDATE empleados  
                        SET nombre = @Nombre, correo= @Correo, direccion= @Direccion
                       WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Correo, empleado.Direccion, empleado.Id });
            return result > 0;
        }

        public async Task<bool> DeleteEmpleado(Empleado empleado)
        {
            var db = dbConnection();
            var sql = @"
                       DELETE 
                        FROM  empleados
                        WHERE id = @Id";
            var result= await db.ExecuteAsync(sql, new { Id = empleado.Id });
            return result > 0;
        }
    }
}

using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Data.Repositories
{
    public interface IEmpleadosRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmpleados();
        Task<Empleado> GetEmpleadoDetails(int id);
        Task<bool> InsertEmpleado( Empleado empleado);
        Task<bool> UpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleado(Empleado empleado);

    }
}

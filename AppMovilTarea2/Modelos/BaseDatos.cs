using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMovilTarea2.Modelos
{
    public class BaseDatos
    {

        readonly SQLiteAsyncConnection db;
        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la bd
            db.CreateTableAsync<Empleado>().Wait();
        }

        //Metodos del CRUD para Sitios

        #region Empleado
        //Select
        public Task<List<Empleado>> ObtenerEmpleado()
        {
            return db.Table<Empleado>().ToListAsync();
        }

        //Insert
        public Task<int> InsertarEmpleado(Empleado ubicacion)
        {
            if (ubicacion.Id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }
        //Traer un solo sitio (Ubicacion)
        public Task<Empleado> ObtenerEmpleado(int pid)
        {
            return db.Table<Empleado>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> EliminarEmpleado(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }

        internal Task<int> InsertarEmpleado()
        {
            throw new NotImplementedException();
        }
        #endregion Sitios
    }
}

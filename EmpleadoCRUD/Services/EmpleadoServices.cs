using EmpleadoCRUD.Context;
using EmpleadoCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadoCRUD.Services
{
    public class EmpleadoServices
    {
        public void Add(Empleado request)
        {
            try
            {


                using (var _context = new AplicationDBContext()) //abrir y cerrar automaticamente la cadena
                {
                    Empleado empleado = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        FechaRegistro = DateTime.Now,
                        Correo = request.Correo,
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        public Empleado Read(int Id)
        {
            try
            {
                using(var _context = new AplicationDBContext())
                {
                    Empleado empleado = _context.Empleados.Find(Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrior un error"+ex.Message);
            }
        }
        public void Editar(int id, Empleado empleadoActualizado)
        {
            try
            {
                using (var _context = new AplicationDBContext())
                {
                    
                    Empleado empleado = _context.Empleados.Find(id);

                    if (empleado != null)
                    {
                      
                        empleado.Nombre = empleadoActualizado.Nombre;
                        empleado.Apellido = empleadoActualizado.Apellido;
                        empleado.FechaRegistro = empleadoActualizado.FechaRegistro;
                        empleado.Correo = empleadoActualizado.Correo;

                        _context.Update(empleado);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                using (var _context = new AplicationDBContext())
                {
                    
                    Empleado empleado = _context.Empleados.Find(id);

                    if (empleado != null)
                    {
                        
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }
        }
    }
}

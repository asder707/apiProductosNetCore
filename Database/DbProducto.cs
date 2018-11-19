using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class DbProducto : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public DbProducto(DbContextOptions<DbProducto> options)
            : base(options)
        {

        }

        public List<Producto> GetAll()
        {
            // Ejemplo con una Query de SQL
            List<Producto> productos = this
                                        .Producto
                                        .FromSql("SELECT * FROM Producto")
                                        .ToList();

            return productos;
        }

        public Producto GetByCodProducto(int codProducto)
        {
            // Ejemplo con LinQ
            Producto producto = this
                                .Producto
                                .FirstOrDefault(p => p.codProducto == codProducto);
            return producto;
        }

        public Producto Create(Producto producto)
        {
            try
            {
                this
                    .Producto
                    .Add(producto);

                this.SaveChanges();

                return producto;
            }
            catch (Exception ex)
            {
                //throw new Exception("No fue posible crear el producto");
                return null;
            }
        }

        public Producto Delete(int codProducto)
        {
            try
            {
                var producto = this.GetByCodProducto(codProducto);

                if (producto == null)
                {
                    //throw new Exception($"El cliente {rut} no se puede eliminar debido a no existe.");
                    return null;
                }

                this
                    .Producto
                    .Remove(producto);

                this.SaveChanges();

                return producto;
            }
            catch (Exception ex)
            {
                //throw new Exception($"No fue posible eliminar el usuario {rut}");
                return null;
            }
        }

    }
}

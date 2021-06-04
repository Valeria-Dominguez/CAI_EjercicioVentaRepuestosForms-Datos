using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaRepuestos.Datos;
using VentaRepuestos.Entidades.Dominio;
using VentaRepuestos.Entidades.Modelos;
using VentaRepuestos.Negocio.Excepciones;

namespace VentaRepuestos.Negocio
{
    public class RepuestoNegocio
    {
        List<Repuesto> _listaProductos;
        RepuestoMapper _repuestoMapper;

        public RepuestoNegocio()
        {
            _listaProductos = new List<Repuesto>();
            _repuestoMapper = new RepuestoMapper();
        }

        public List<Repuesto> Traer()
        {
            this._listaProductos = this._repuestoMapper.TraerTodos();
            return _listaProductos;
        }

        public TransactionResult AgregarRepuesto (Repuesto repuesto)
        {
            BuscarRepuesto(repuesto.Nombre);
            return this._repuestoMapper.Agregar(repuesto);                
        }

        private void BuscarRepuesto(string nombre)
        {
            foreach (Repuesto repuesto in this._listaProductos)
            {
                if (repuesto.Nombre == nombre)
                    throw new RepuestoExistenteException("El repuesto ya existe");
            }
        }

        public TransactionResult QuitarRepuesto (Repuesto repuesto)
        {
            if (repuesto.Stock > 0)
                throw new Exception("No puede eliminarse, repuesto con stock");
            return this._repuestoMapper.Eliminar(repuesto);
        }

        public TransactionResult ModificarPrecio (Repuesto repuesto, double precio)
        {
            repuesto.Precio = precio;
            return this._repuestoMapper.Modificar(repuesto);
        }
        public TransactionResult AgregarStock (Repuesto repuesto, int cantidad)
        {
            repuesto.Stock = repuesto.Stock + cantidad;
            return this._repuestoMapper.Modificar(repuesto);

        }
        public TransactionResult QuitarStock(Repuesto repuesto, int cantidad)
        {
            if (repuesto.Stock < cantidad)
                throw new StockInsuficienteException("El stock disponible es menor a la cantidad que desea quitar:" + repuesto.Stock);
            repuesto.Stock = repuesto.Stock - cantidad;
            return this._repuestoMapper.Modificar(repuesto);
        }
        public List<Repuesto> TraerPorCateogria(int id)
        {
            List<Repuesto> repuestosCategoria = new List<Repuesto>();
            foreach(Repuesto repuesto in this.Traer())
            {
                if (repuesto.IdCategoria == id)
                    repuestosCategoria.Add(repuesto);
            }
            return repuestosCategoria;
        }
    }
}

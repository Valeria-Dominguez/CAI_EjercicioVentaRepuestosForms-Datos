using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Entidades.Dominio
{
    [DataContract]
    public class Repuesto
    {
        int _codigo;
        string _nombre;
        double _precio;
        int _stock;
        int _idCategoria;

        [DataMember(Name = "id")]
        public int Codigo { get => _codigo; set => _codigo = value; }

        [DataMember(Name = "nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [DataMember(Name = "precio")]
        public double Precio { get => _precio; set => _precio = value; }

        [DataMember(Name = "stock")]
        public int Stock { get => _stock; set => _stock = value; }

        [DataMember(Name = "idCategoria")]
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }

        public Repuesto(int codigo, string nombre, double precio, int stock, int idCategoria)
        {
            _codigo = codigo;
            _nombre = nombre;
            _precio = precio;
            _stock = stock;
            _idCategoria = idCategoria;
        }

        public Repuesto()
        {
        }


        public override string ToString()
        {
            return $"{this._codigo} {this._nombre} / Precio: ${this._precio} - Cantidad: {this._stock} - Categoria: {this._idCategoria}";
        }

    }
}

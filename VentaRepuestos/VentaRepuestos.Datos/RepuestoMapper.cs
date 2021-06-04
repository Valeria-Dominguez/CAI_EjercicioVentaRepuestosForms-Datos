using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaRepuestos.Entidades.Dominio;
using VentaRepuestos.Entidades.Modelos;

namespace VentaRepuestos.Datos
{
    public class RepuestoMapper
    {
        public List <Repuesto> TraerTodos()
        {
            string json = WebHelper.Get("/VentaHardware/Productos/847004");
            List<Repuesto> resultado = MapList(json);
            return resultado;
        }

        private List<Repuesto> MapList(string json)
        {
            List<Repuesto> lst = JsonConvert.DeserializeObject<List<Repuesto>>(json);
            return lst;
        }

        public TransactionResult Agregar (Repuesto repuesto)
        {
            NameValueCollection parametros = ReverseMap(repuesto);
            string json2 = WebHelper.Post("/VentaHardware/Productos", parametros);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json2);
            return resultado;
        }

        private NameValueCollection ReverseMap(Repuesto repuesto)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("idCategoria", repuesto.IdCategoria.ToString());
            n.Add("nombre", repuesto.Nombre);
            n.Add("stock", repuesto.Stock.ToString());
            n.Add("precio", repuesto.Precio.ToString("0.00"));
            n.Add("usuario", "847004");
            n.Add("id", repuesto.Codigo.ToString());
            return n;
        }

        public TransactionResult Eliminar(Repuesto repuesto)
        {
            NameValueCollection parametros = ReverseMap(repuesto);
            string json3 = WebHelper.Delete("/VentaHardware/Productos", parametros);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json3);
            return resultado;
        }

        public TransactionResult Modificar(Repuesto repuesto)
        {
            NameValueCollection parametros = ReverseMap(repuesto);
            string json4 = WebHelper.Put("/VentaHardware/Productos", parametros);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json4);
            return resultado;
        }
    }
}

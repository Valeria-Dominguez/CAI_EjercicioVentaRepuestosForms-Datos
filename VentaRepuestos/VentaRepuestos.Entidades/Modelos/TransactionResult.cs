using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Entidades.Modelos
{
    [DataContract]
    public class TransactionResult
    {
        [DataMember]
        int ID { set; get; }

        [DataMember]
        bool IsOK { set; get; }

        [DataMember]
        string Error { set; get; }

        public override string ToString()
        {
            if (IsOK)
                return $"Operación exitosa - ID:{this.ID}";
            else
                return $"La operación no pudo realizarse: {this.Error}";
        }
    }
}

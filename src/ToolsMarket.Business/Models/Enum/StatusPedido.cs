using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMarket.Business.Models.Enum
{
    public enum StatusPedido : int
    {
        Aberto = 1,
        Processado = 2,
        Finalizado = 3,
        Cancelado = 4
    }
}

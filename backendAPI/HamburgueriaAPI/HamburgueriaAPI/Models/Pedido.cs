using System;
using System.Collections.Generic;

namespace HamburgueriaAPI.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public DateOnly Datapedido { get; set; }

    public virtual Pessoa IdpedidoNavigation { get; set; } = null!;

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}

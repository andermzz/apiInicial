using System;
using System.Collections.Generic;

namespace HamburgueriaAPI.Models;

public partial class PedidoProduto
{
    public int Idpedido { get; set; }

    public int Idproduto { get; set; }

    public int Quantidade { get; set; }

    public decimal? Valorunitario { get; set; }

    public virtual Pedido IdpedidoNavigation { get; set; } = null!;

    public virtual Produto IdprodutoNavigation { get; set; } = null!;
}

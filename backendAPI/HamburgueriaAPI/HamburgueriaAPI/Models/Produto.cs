using System;
using System.Collections.Generic;

namespace HamburgueriaAPI.Models;

public partial class Produto
{
    public int Idproduto { get; set; }

    public string Descricao { get; set; } = null!;

    public decimal Valorunitario { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}

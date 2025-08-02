using HamburgueriaAPI.ViewModel;
using System;
using System.Collections.Generic;

namespace HamburgueriaAPI.Models;

public partial class Pessoa
{
    public int Idpessoa { get; set; }

    public string Nome { get; set; } = null!;

    public int Idade { get; set; }

    public decimal Renda { get; set; }

    public virtual Pedido? Pedido { get; set; }

    public Pessoa(){}

    public Pessoa(int idpessoa, string nome, int idade, decimal renda, Pedido? pedido)
    {
        Idpessoa = idpessoa;
        Nome = nome;
        Idade = idade;
        Renda = renda;
        Pedido = pedido;
    }

    public Pessoa(string nome, int idade, decimal renda, Pedido? pedido)
    {
        Nome = nome;
        Idade = idade;
        Renda = renda;
        Pedido = pedido;
    }

    public Pessoa(PessoaViewModel pessoa)
    {
        Nome = pessoa.nome;
        Idade = pessoa.idade;
        Renda = pessoa.renda;
    }


}

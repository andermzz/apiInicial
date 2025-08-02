using System;
using System.Collections.Generic;
using Humanizer;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace HamburgueriaAPI.Models;

public partial class BdHamburgueriaContext : DbContext
{
    public BdHamburgueriaContext()
    {
    }

    public BdHamburgueriaContext(DbContextOptions<BdHamburgueriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoProduto> PedidoProdutos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
     #warning  To protect potentially sensitive information in your connection string, you should move it out of source code.You can avoid scaffolding the connection string by using the Name = syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2148\\SA; Database=bd_hamburgueria; User Id=sa; password=senai.123; Integrated Security=SSPI;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido);

            entity.ToTable("pedido");

            entity.Property(e => e.Idpedido)
                .ValueGeneratedOnAdd()
                .HasColumnName("idpedido");
            entity.Property(e => e.Datapedido).HasColumnName("datapedido");

            entity.HasOne(d => d.IdpedidoNavigation).WithOne(p => p.Pedido)
                .HasForeignKey<Pedido>(d => d.Idpedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_pessoa");
        });

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.HasKey(e => new { e.Idpedido, e.Idproduto });

            entity.ToTable("pedido_produto");

            entity.Property(e => e.Idpedido).HasColumnName("idpedido");
            entity.Property(e => e.Idproduto).HasColumnName("idproduto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Valorunitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valorunitario");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.Idpedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_produto_pedido");

            entity.HasOne(d => d.IdprodutoNavigation).WithMany(p => p.PedidoProdutos)
                .HasForeignKey(d => d.Idproduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_produto_produto");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Idpessoa);

            entity.ToTable("pessoa");

            entity.Property(e => e.Idpessoa).HasColumnName("idpessoa");
            entity.Property(e => e.Idade).HasColumnName("idade");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Renda)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("renda");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Idproduto);

            entity.ToTable("produto");

            entity.Property(e => e.Idproduto).HasColumnName("idproduto");
            entity.Property(e => e.Descricao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Valorunitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valorunitario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

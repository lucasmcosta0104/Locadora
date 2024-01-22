﻿using Locadora.Dto;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Locadora.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }    
        public string Modelo { get; set; }    
        public int Ano { get; set; }    
        public string Cor { get; set; }      
        public string Placa { get; set; }
        [Precision(17, 2)]
        public decimal ValorDiaria { get; set; }    
        public bool Disponibilidade { get; set; }
        public int LocadoraModeloId { get; set; }
        public virtual LocadoraModelo LocadoraModelo { get; set;}
        [JsonIgnore]
        public virtual ICollection<Locacao> Locacoes { get; private set; }

        public Task Adicionar(VeiculoDto dto)
        {
            Marca = dto.Marca;
            Modelo = dto.Modelo;
            Ano = dto.Ano;
            Cor = dto.Cor;
            Placa = dto.Placa;
            ValorDiaria = dto.ValorDiaria;
            Disponibilidade = true;
            LocadoraModeloId = dto.LocadoraModeloId;

            return Task.CompletedTask;
        }

        public Task Editar(VeiculoEditDto dto)
        {
            Marca = dto.Marca;
            Modelo = dto.Modelo;
            Ano = dto.Ano;
            Cor = dto.Cor;
            Placa = dto.Placa;

            return Task.CompletedTask;
        }

        public Task AlterarValorDiaria(decimal valorDiaria)
        {
            ValorDiaria = valorDiaria;

            return Task.CompletedTask;
        }

        public Task RetiradaLocacao()
        {
            Disponibilidade = false;
            return Task.CompletedTask;
        }

        public Task EntregaLocacao()
        {
            Disponibilidade = true;
            return Task.CompletedTask;
        }

        public decimal CalcularValorTotalLocacao(int quantidadeDias, int diariasComMulta)
        {
            return (quantidadeDias - diariasComMulta) * ValorDiaria + (diariasComMulta * ValorDiaria * 1.20M);
        }
    }
}

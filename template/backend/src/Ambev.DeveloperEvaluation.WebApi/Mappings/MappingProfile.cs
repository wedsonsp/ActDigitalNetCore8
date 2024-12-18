﻿using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente;
using Ambev.DeveloperEvaluation.Application.Filiais;
using Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;
using Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda;
using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial;
using Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ItemVenda = Ambev.DeveloperEvaluation.Domain.Entities.ItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeando de GetUserResult para GetUserResponse
            CreateMap<GetUserResult, GetUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));


            // Mapeando de GetUserResult para GetUserResponse
            CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            // Mapeando de GetUserResult para GetUserResponse
            CreateMap<AuthenticateUserResult, AuthenticateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            // Mapeia os dados de CreateClienteRequest para CreateClienteCommand
            CreateMap<CreateClienteRequest, CreateClienteCommand>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone));

            // Configuração do mapeamento entre CreateClienteResult e CreateClienteResponse
            CreateMap<CreateClienteResult, CreateClienteResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Ajuste a correspondência entre as propriedades

            // Adiciona o mapeamento entre CreateFilialRequest e CreateFilialCommand
            CreateMap<CreateFilialRequest, CreateFilialCommand>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep));

            // Configuração de mapeamento entre CreateFilialResult e CreateFilialResponse
            CreateMap<CreateFilialResult, CreateFilialResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateProdutoResult, CreateProdutoResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Exemplo de mapeamento de propriedades diferentes
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario));

            // Configuração de mapeamento entre CreateVendaRequest e CreateVendaCommand
            CreateMap<CreateVendaRequest, CreateVendaCommand>()
                .ForMember(dest => dest.NumeroVenda, opt => opt.MapFrom(src => src.NumeroVenda))
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.NomeCliente))
                .ForMember(dest => dest.IdFilial, opt => opt.MapFrom(src => src.IdFilial))
                .ForMember(dest => dest.NomeFilial, opt => opt.MapFrom(src => src.NomeFilial))
                .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto))
                //.ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda))
                //.ForMember(dest => dest.ValorTotalVendaDesconto, opt => opt.MapFrom(src => src.ValorTotalVendaDesconto))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            // Mapeamento entre CreateVendaResult e CreateVendaResponse
            CreateMap<CreateVendaResult, CreateVendaResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumeroVenda, opt => opt.MapFrom(src => src.NumeroVenda))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda))
                .ForMember(dest => dest.ValorTotalVendaDesconto, opt => opt.MapFrom(src => src.ValorTotalVendaDesconto));


            CreateMap<CreateItemVendaCommand, Domain.Entities.ItemVenda>()
            .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto))
            .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
            .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
            .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario));

            // Mapeamento da venda
            CreateMap<Venda, CreateVendaResponse>()
                .ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda))
                .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda)); // Mapeia os itens de venda

            
            

            // Mapeamento de Venda para GetVendaResult
            CreateMap<Venda, GetVendaResult>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapStatusVenda(src.Status))) // Chama o método auxiliar
                .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda));

            // Mapeamento entre ItemVenda e SaleItem
            CreateMap<Domain.Entities.ItemVenda, SaleItem>()
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto))
                .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario));

            // Mapeamento de GetVendaResult para GetVendaResponse
            CreateMap<GetVendaResult, GetVendaResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeCliente, opt => opt.MapFrom(src => src.NomeCliente))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ValorTotalVenda, opt => opt.MapFrom(src => src.ValorTotalVenda))
                .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda))
                .ForMember(dest => dest.DescontoVenda, opt => opt.MapFrom(src => src.DescontoVenda))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.ValorTotalVendaDesconto, opt => opt.MapFrom(src => src.ValorTotalVendaDesconto)); // Mapear a lista de itens de venda


            // Mapeamento entre ItemVenda e SaleItem (certifique-se de que isso esteja correto)
            CreateMap<Domain.Entities.ItemVenda, SaleItem>()
                .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario));

            // Mapeamento entre SaleItem e VendaItemResponse
            CreateMap<SaleItem, GetVendaItemResponse>()
                .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario));

            CreateMap<UpdateVendaRequest, UpdateVendaCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpdateVendaResult, UpdateVendaResponse>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // Mapeando o comando CreateVendaCommand para a entidade Venda
            CreateMap<CreateVendaCommand, Venda>()
                .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda)); // Garantir que os ItensVenda sejam mapeados corretamente

            // Mapeando os itens de venda
            CreateMap<CreateItemVendaCommand, Domain.Entities.ItemVenda>();

            // Mapeamento de ItemVenda para CreateItemVendaResult
            CreateMap<ItemVenda, CreateItemVendaResult>();

            // Mapeando de Venda para UpdateVendaCommand
            CreateMap<Venda, UpdateVendaCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // Mapear explicitamente o campo Id
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) // Mapear o campo Status
                .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda));

            // Mapeamento de ItemVenda para UpdateItemVendaCommand
            CreateMap<ItemVenda, UpdateItemVendaCommand>()
                .ForMember(dest => dest.IdProduto, opt => opt.MapFrom(src => src.IdProduto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.NomeProduto)); // Adicione outros mapeamentos conforme necessário
        }

        

        // Método auxiliar para mapear o status da venda
        private VendaStatus MapStatusVenda(string status)
        {
            // Tenta fazer o parse do status (caso seja válido)
            if (Enum.IsDefined(typeof(VendaStatus), status))
            {
                return (VendaStatus)Enum.Parse(typeof(VendaStatus), status);
            }

            // Retorna um valor default se o parse falhar
            return VendaStatus.NaoCancelada; // Ou outro valor padrão
        }


  

    }
}

﻿using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.DeleteAtendimento
{
    public class DeleteAtendimentoCommand : IRequest<ResultViewModel>
    {
        public DeleteAtendimentoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

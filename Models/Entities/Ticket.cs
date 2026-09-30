using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is the "Chamados" from RF05
namespace DeskFlow.API.Models.Entities
{
    public class Ticket
    {
        //todo: as per RF05 - add attributes Id, Titulo, Descricao, Prioridade (Baixa, Media, Alta), Status (Aberto, EmAndamento, Fechado), SolicitanteNome, DataAbertura, DataFechamento, Solucao e CategoriaId.
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string RequesterName {get; set;} //SolicitanteNome from RF05
        public DateTime OpenedDate {get; set;}
        public DateTime ClosedDate {get; set;}
        public string Solution {get; set;}
        public int CategoryId {get; set;}
        public string Priority {get; set;}
        public string Status {get; set;}
    }
}
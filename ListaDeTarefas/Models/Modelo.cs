using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListaDeTarefas.Models
{
    public class Lista
    {
        [Key]
        public int ListaId { get; set; }
        public string Nome { get; set; }
        public int Ativa { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioID { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
        public DateTime? Prazo { get; set; }
    }
    public class Tarefa
    {
        [Key]
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public int Concluida { get; set; }
        public virtual int Ativa { get; set; }
        public virtual Lista lista { get; set; }
        public int ListaId { get; set; }
    }
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Ativo { get; set; }
        public virtual ICollection<Lista> Listas { get; set; }
    }
}
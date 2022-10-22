using System;

namespace ComoSelecionaConstrutor
{
    public class Operacao : IOperacao
    {
        public Guid Id { get; set; }
        public Operacao()
        {
            Id = Guid.NewGuid();
        }
    }
    public interface IOperacao
    {
        Guid Id { get; set; }
    }
}

namespace Model
{
    using System;

    public class Insumo
    {
        public string Id { get; private set; }
        public string Tipo { get; private set; }
        public DateTime DataValidade { get; private set; }

        public Insumo(string id, string tipo, DateTime dataValidade)
        {
            Id = id;
            Tipo = tipo;
            DataValidade = dataValidade;
        }
    }
}

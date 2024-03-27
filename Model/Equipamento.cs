namespace Model
{
    using System;
    using System.Collections.Generic;

    public class Equipamento
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public List<Insumo> Insumos { get; private set; }

        public Equipamento(string id, string nome)
        {
            Id = id;
            Nome = nome;
            Insumos = new List<Insumo>();
        }

        public void AdicionarInsumo(Insumo insumo)
        {
            Insumos.Add(insumo);
        }

        public void RemoverInsumo(Insumo insumo)
        {
            Insumos.Remove(insumo);
        }
    }
}

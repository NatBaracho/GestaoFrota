using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestaoFrota.Models
{
    public class FrotaRepository
    {
        private readonly string _caminhoArquivo = "dados_frota.json";
        private List<Veiculo> _veiculos;
        private readonly JsonSerializerOptions _jsonOptions;

        public FrotaRepository()
        {
            _jsonOptions = new JsonSerializerOptions {WriteIndented = true};
            _veiculos = CarregadorDoDisco();
        }

        public void Adicionar(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
            SalvarNoDisco();
        }

        public void Remover(Guid id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo != null)
            {
                _veiculos.Remove(veiculo);
                SalvarNoDisco();
            }
        }

        public IEnumerable<Veiculo> ObterTodos() => _veiculos.AsReadOnly();

        private void SalvarNoDisco()
        {
            string json = JsonSerializer.Serialize(_veiculos, _jsonOptions);
            File.WriteAllText(_caminhoArquivo, json);
        }

        private List<Veiculo> CarregadorDoDisco()
        {
            //Expressões de Coleção '[]' substituem 'new List<Veiculo>()'
            if (!File.Exists(_caminhoArquivo)) return [];

            string json = File.ReadAllText(_caminhoArquivo);
            if (string.IsNullOrWhiteSpace(json)) return [];

            return JsonSerializer.Deserialize<List<Veiculo>>(json, _jsonOptions) ?? [];
        }
    }
}
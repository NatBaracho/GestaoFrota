using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestaoFrota.Models
{
    // Esta classe é responsável por guardar e carregar os veículos da frota.
    // Ela usa um arquivo chamado "dados_frota.json" para salvar as informações.
    public class FrotaRepository
    {
        // Nome do arquivo onde os dados vão ficar guardados.
        private readonly string _caminhoArquivo = "dados_frota.json";

        // Lista de veículos que está na memória do programa.
        private List<Veiculo> _veiculos;

        // Configuração para salvar o JSON de forma organizada (com identação).
        private readonly JsonDocumentOptions _JsonOptions;

        // Quando criamos o repositório, ele já tenta carregar os dados do arquivo.
        public FrotaRepository()
        {
            _JsonOptions = new JsonDocumentOptions { WriteIndented = true };
            _veiculos = CarregarDoDisco();
        }

        // Adiciona um novo veículo na lista e salva no arquivo.
        public void Adicionar(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
            SalvarNoDisco();
        }

        // Remove um veículo da lista pelo seu Id (código único).
        public void Remover(Guid id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo != null)
            {
                _veiculos.Remove(veiculo);
                SalvarNoDisco();
            }
        }

        // Devolve todos os veículos da lista, mas sem permitir alterações diretas.
        public IEnumerable<Veiculo> ObterTodos() => _veiculos.AsReadOnly();

        // Salva a lista de veículos no arquivo em formato JSON.
        private void SalvarNoDisco()
        {
            string json = JsonSerializer.Serialize(_veiculos, _JsonOptions);
            File.WriteAllText(_caminhoArquivo, json);
        }

        // Carrega os veículos do arquivo JSON para a memória.
        private List<Veiculo> CarregarDoDisco()
        {
            // Se o arquivo não existir, devolve uma lista vazia.
            if (!File.Exists(_caminhoArquivo)) return [];

            // Lê o conteúdo do arquivo.
            string jsdon = File.ReadAllText(_caminhoArquivo);

            // Se o arquivo estiver vazio, devolve uma lista vazia.
            if (string.IsNullOrWhiteSpace(jsdon)) return [];

            // Converte o texto JSON de volta para uma lista de veículos.
            // Se der algum problema, devolve uma lista vazia.
            return JsonSerializer.Deserialize<List<Veiculo>>(jsdon, _JsonOptions) ?? [];
        }
    }
}

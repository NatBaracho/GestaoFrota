namespace GestaoFrota.Models
{
    // A classe Caminhao representa um caminhão.
    // Ela usa tudo o que já existe na classe Veiculo
    // e adiciona informações que só um caminhão tem.
    public class Caminhao(string placa, string modelo, int ano, decimal valorDiariaBase, double capacidadeCargaKg): Veiculo(placa, modelo, ano, valorDiariaBase)
    {
        // Aqui guardamos quantos quilos o caminhão consegue carregar.
        // Exemplo: 5000 kg, 12000 kg...
        public double CapacidadeCargaKg { get; set; } = capacidadeCargaKg;

        // Este método calcula quanto custa alugar o caminhão por "dias".
        // O cálculo funciona assim:
        // 1. diária × dias
        // 2. adiciona 20% de seguro (caminhão tem seguro mais caro)
        // 3. adiciona uma taxa extra baseada na capacidade de carga
        public override decimal CalcularCustoAluguel(int dias)
        {
            // Parte principal do valor: diária × dias
            decimal custoBase = ValorDiariaBase * dias;

            // Taxa extra: quanto maior a carga, maior o valor
            // A cada 1000 kg, cobra R$ 50 por dia
            decimal taxaCarga = (decimal)(CapacidadeCargaKg / 1000.0) * 50m * dias;

            // Soma tudo: custo base + 20% de seguro + taxa de carga
            return custoBase + (custoBase * 0.20m) + taxaCarga;
        }

        // Este método cria uma frase descrevendo o caminhão.
        // Ele usa a descrição padrão da classe Veiculo
        // e adiciona a capacidade de carga no final.
        public override string ObterDescricao() => $"{base.ObterDescricao()} | Carga: {CapacidadeCargaKg}Kg";
    }
}

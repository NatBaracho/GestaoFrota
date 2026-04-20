namespace GestaoFrota.Models
{
    // A classe Carro representa um carro comum.
    // Ela "herda" tudo da classe Veiculo, ou seja, aproveita o que já existe lá.
    // O que for diferente ou específico de um carro, colocamos aqui.
    public class Carro(string placa, string modelo, int ano, decimal valorDiariaBase, int quantidadePortas) : Veiculo(placa, modelo, ano, valorDiariaBase)
    {
        // Quantidade de portas do carro.
        // Exemplo: 2 portas, 4 portas...
        public int QuantidadePorta { get; set; } = quantidadePortas;

        // Aqui calculamos quanto custa alugar o carro por "dias".
        // Todo carro tem um valor de diária (valorDiariaBase).
        // Depois multiplicamos pela quantidade de dias.
        // No final, adicionamos 10% de seguro obrigatório.
        public override decimal CalcularCustoAluguel(int dias)
        {
            decimal custoBase = ValorDiariaBase * dias;
            return custoBase + (custoBase * 0.10m); // Acrescenta 10% de seguro
        }

        // Esse método devolve uma frase descrevendo o carro.
        // Ele usa a descrição padrão da classe Veiculo e adiciona a quantidade de portas.
        public override string ObterDescricao()
            => $"{base.ObterDescricao()} | Portas: {QuantidadePorta}";
    }
}

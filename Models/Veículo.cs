using System;
using System.Text.Json.Serialization;

namespace GestaoFrota.Models
{
    // Aqui estamos dizendo ao sistema:
    // "Quando você encontrar um Veiculo no JSON, ele pode ser um Carro ou um Caminhao."
    // Isso ajuda o programa a entender qual tipo de veículo está sendo enviado ou recebido.
    [JsonDerivedType(typeof(Carro), typeDiscriminator: "carro")]
    [JsonDerivedType(typeof(Caminhao), typeDiscriminator: "caminhao")]

    // Esta é uma classe "modelo" de veículo.
    // Ela NÃO pode ser usada diretamente, só serve como base para outros tipos (Carro, Caminhao).
    public abstract class Veiculo
    {
        // Um código único gerado automaticamente para identificar cada veículo.
        public Guid Id { get; set; }

        // A placa do veículo (exemplo: ABC-1234).
        public string Placa { get; set; }

        // O nome ou modelo do veículo (exemplo: Corolla, Uno, FH 540).
        public string Modelo { get; set; }

        // Aqui guardamos o ano do veículo de forma protegida.
        private int _ano;

        // Esta propriedade controla o ano do veículo.
        // Ela impede que alguém coloque um ano absurdo, como 1500 ou 3000.
        public int Ano
        {
            get => _ano;
            set
            {
                // Se o ano for muito antigo ou muito no futuro, o programa avisa que está errado.
                if (value < 1900 || value > DateTime.Now.Year + 1)
                {
                    throw new ArgumentException("Ano do veículo inválido");
                }

                _ano = value; // Se estiver tudo certo, o ano é salvo.
            }
        }

        // Quanto custa a diária básica para alugar este veículo.
        public decimal ValorDiariaBase { get; set; }

        // Este é o "construtor".
        // Ele é chamado quando criamos um novo veículo.
        // Como Veiculo é só um modelo, apenas Carro e Caminhao podem usar este construtor.
        protected Veiculo(string placa, string modelo, int ano, decimal valorDiariaBase)
        {
            Id = Guid.NewGuid(); // Gera automaticamente um código único.
            Placa = placa;
            Modelo = modelo;
            Ano = ano; // Aqui passa pela validação do ano.
            ValorDiariaBase = valorDiariaBase;
        }

        // Este método diz: "Toda classe filha deve explicar como calcula o custo do aluguel."
        // Cada tipo de veículo pode ter sua própria regra.
        public abstract decimal CalcularCusntoAluguel(int dias);

        // Este método cria uma frase com as informações básicas do veículo.
        // As classes filhas podem mudar essa frase se quiserem.
        public virtual string ObterDescricao()=> $"{Modelo} ({Ano}) - Placa: {Placa}";
    }
}

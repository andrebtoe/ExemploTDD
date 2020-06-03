using Xunit;

namespace ExemploTDD.Testes
{
    public class ContaCorrenteTeste01
    {
        // ****** Conta corrente deve ter um número de conta e um saldo inicial ******
        // O número de conta deve ter um padrão no seguinte formato: 9999-9 (9 corresponde ao digito)
        // O Saldo inicial da conta corrente deve ser superior ou igual há 50 reais
        // O correntista deve conseguir sacar o dinheiro de sua conta corrente
        // Ao sacar o saldo deve ser subtraido do valor do saque
        // Não deve ser possível realizar saque com valor negativo
        // O correntista deve ter possibilidade de depositar dinheiro em sua conta corrente
        // Não deve ser permitido realizar depósito em conta corrente com valor negativo.

        [Fact]
        public void Testar_Ao_Criar_Conta_Corrente_Caminho_Feliz()
        {
            // Arrange
            const string identificacaoDaContaCorrente = "1234-5";
            const decimal saldoInicial = 50.0m;

            // Action
            var contaCorrente = new ContaCorrente(identificacaoDaContaCorrente, saldoInicial);

            // Assert
            Assert.NotNull(contaCorrente);
            Assert.True(saldoInicial == contaCorrente.Saldo);
            Assert.True(identificacaoDaContaCorrente == contaCorrente.IdentificacaoDaContaCorrente);
        }
    }
}
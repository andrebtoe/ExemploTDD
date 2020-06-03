using Xunit;

namespace ExemploTDD.Testes
{
    public class ContaCorrenteTeste07
    {
        // Conta corrente deve ter um número de conta e um saldo inicial
        // O número de conta deve ter um padrão no seguinte formato: 9999-9 (9 corresponde ao digito)
        // O Saldo inicial da conta corrente deve ser superior ou igual há 50 reais
        // O correntista deve conseguir sacar o dinheiro de sua conta corrente
        // Ao sacar o saldo deve ser subtraido do valor do saque
        // Não deve ser possível realizar saque com valor negativo
        // ****** O correntista deve ter possibilidade de depositar dinheiro em sua conta corrente ******
        // Não deve ser permitido realizar depósito em conta corrente com valor negativo.

        [Theory]
        [InlineData(40, 220)]
        [InlineData(250, 430)]
        [InlineData(100, 280)]
        public void Testar_Saldo_Apos_Deposito_Caminho_Feliz(decimal valorDeDeposito, decimal saldoEsperado)
        {
            // Arrange
            var contaCorrente = new ContaCorrente("1234-5", 180);

            // Action
            contaCorrente.Depositar(valorDeDeposito);

            // Assert
            Assert.True(contaCorrente.Saldo == saldoEsperado);
        }
    }
}
using System;
using System.Text.RegularExpressions;

namespace ExemploTDD
{
    public class ContaCorrente
    {
        private const decimal SaldoInicialPadrao = 50;

        public ContaCorrente(string identificacaoDaContaCorrente, decimal saldoInicial)
        {
            VerificarFormatoDeIdentificacaoDaContaCorrente(identificacaoDaContaCorrente);
            VerificarSaldoInicial(saldoInicial);

            IdentificacaoDaContaCorrente = identificacaoDaContaCorrente;
            Saldo = saldoInicial;
        }

        public string IdentificacaoDaContaCorrente { get; private set; }
        public decimal Saldo { get; private set; }

        public void Sacar(decimal valor)
        {
            // Verificar se valor do saque é negativo, caso sim, lançar uma exception
            if (valor < 0)
                throw new Exception($"Não é possível sacar um valor negativo: {valor}");

            // Definir variável com valor irá ficar no saldo
            var projecaoDoSaldo = Saldo - valor;

            // Verificar se projeção do saldo é negativo, caso sim, lançar uma exception
            if (projecaoDoSaldo < 0)
                throw new Exception($"Saldo insuficiente: {valor}");

            // Definir subtração do saldo. Só chegará aqui caso as verificações estejam de acordo com as regras
            Saldo -= valor;
        }

        public void Depositar(decimal valor)
        {
            // Verificar se valor do saque é negativo, caso sim, lançar uma exception
            if (valor <= 0)
                throw new Exception($"Não é possível depositar um valor igual à zero ou inferior: {valor}");

            // Definir adição do saldo. Só chegará aqui caso as verificações estejam de acordo com as regras
            Saldo += valor;
        }

        private void VerificarFormatoDeIdentificacaoDaContaCorrente(string identificacaoDaContaCorrente)
        {
            // Verificar se identificador da conta não está definido, caso sim, lançar uma exception
            if (String.IsNullOrEmpty(identificacaoDaContaCorrente))
                throw new Exception("Conta corrente não pode ser vázio");

            // Definir regex para definir se formato do identificador da conta corrente está válido, caso não esteja, lançar uma exception
            var identificacaoDaContaCorrenteValido = Regex.IsMatch(identificacaoDaContaCorrente, @"^(\d){4}\-(\d){1}$");
            if (!identificacaoDaContaCorrenteValido)
                throw new Exception("Formato do identificador de conta corrente inválido");
        }

        private void VerificarSaldoInicial(decimal saldoInicial)
        {
            // Verificar se saldo é menor do que o padrão definido, caso sim, lançar uma exception
            if (saldoInicial < SaldoInicialPadrao)
                throw new Exception($"Saldo inicial não pode ser menor que {SaldoInicialPadrao}");
        }
    }
}
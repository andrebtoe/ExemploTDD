﻿using System;
using Xunit;

namespace ExemploTDD.Testes
{
    public class ContaCorrenteTeste05
    {
        // Conta corrente deve ter um número de conta e um saldo inicial
        // O número de conta deve ter um padrão no seguinte formato: 9999-9 (9 corresponde ao digito)
        // O Saldo inicial da conta corrente deve ser superior ou igual há 50 reais
        // O correntista deve conseguir sacar o dinheiro de sua conta corrente
        // ****** Ao sacar o saldo deve ser subtraido do valor do saque ******
        // Não deve ser possível realizar saque com valor negativo
        // O correntista deve ter possibilidade de depositar dinheiro em sua conta corrente
        // Não deve ser permitido realizar depósito em conta corrente com valor negativo.

        [Theory]
        [InlineData(-10)]
        [InlineData(201)]
        [InlineData(542)]
        public void Testar_Ao_Sacar_Da_Conta_Corrente_Com_Saldo_Invalido(decimal valorDeSaque)
        {
            // Arrange
            var contaCorrente = new ContaCorrente("1234-5", 200);

            // Action
            Assert.Throws<Exception>(() => contaCorrente.Sacar(valorDeSaque));
        }
    }
}
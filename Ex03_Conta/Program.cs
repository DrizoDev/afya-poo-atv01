using System;
namespace Ex03_Conta
{
    public class ContaCorrenteUniversitaria
    {
        private readonly string _numeroConta;
        private string _titular;
        private decimal _saldo;
        private decimal _limiteChequeEspecial;

        public string NumeroConta => _numeroConta;

        public string Titular
        {
            get => _titular;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _titular = value;
            }
        }

        public decimal Saldo => _saldo;
        public decimal LimiteChequeEspecial => _limiteChequeEspecial;

        public decimal SaldoTotal => _saldo + _limiteChequeEspecial;

        public string StatusConta => _saldo < 0 ? "Negativo" : "Positivo";

        public ContaCorrenteUniversitaria(string numeroConta, string titular)
        {
            if (string.IsNullOrWhiteSpace(numeroConta))
                throw new ArgumentException("O número da conta é obrigatório.");

            if (string.IsNullOrWhiteSpace(titular))
                throw new ArgumentException("O titular é obrigatório.");

            _numeroConta = numeroConta;
            _titular = titular;
            _saldo = 0m;
            _limiteChequeEspecial = 500m;
        }

        public bool Depositar(decimal valor)
        {
            if (valor <= 0)
                return false;

            _saldo += valor;
            return true;
        }

        public bool Sacar(decimal valor)
        {
            if (valor <= 0)
                return false;

            if (valor > SaldoTotal)
                return false;

            _saldo -= valor;
            return true;
        }

        public override string ToString()
        {
            return $"Conta: {_numeroConta} | Titular: {_titular} | Saldo: R$ {_saldo:F2} | Limite: R$ {_limiteChequeEspecial:F2}";
        }
    }

    class Program
    {
        static void Main()
        {
            ContaCorrenteUniversitaria conta = new ContaCorrenteUniversitaria("2026001", "Drizo");

            Console.WriteLine(conta);

            conta.Depositar(300);
            Console.WriteLine(conta);

            conta.Sacar(700);
            Console.WriteLine(conta);

            Console.WriteLine($"Saldo Total: R$ {conta.SaldoTotal:F2}");
            Console.WriteLine($"Status: {conta.StatusConta}");
        }
    }
}

using System;

namespace Ex02_Cofre
{
    public class CofreDigital
    {
        private readonly string _dono;
        private string _senha;
        private bool _estaAberto;
        private int _tentativasErradas;
        private bool _bloqueado;

        public string Dono => _dono;
        public bool EstaAberto => _estaAberto;
        public int TentativasErradas => _tentativasErradas;
        public bool Bloqueado => _bloqueado;

        public CofreDigital(string dono, string senhaInicial)
        {
            if (string.IsNullOrWhiteSpace(dono))
                throw new ArgumentException("O nome do dono é obrigatório.");

            if (string.IsNullOrWhiteSpace(senhaInicial))
                throw new ArgumentException("A senha inicial é obrigatória.");

            _dono = dono;
            _senha = senhaInicial;
            _estaAberto = false;
            _tentativasErradas = 0;
            _bloqueado = false;
        }

        public string Abrir(string senhaInformada)
        {
            if (_bloqueado)
                return "Cofre Bloqueado.";

            if (senhaInformada == _senha)
            {
                _estaAberto = true;
                _tentativasErradas = 0;
                return "Cofre aberto com sucesso.";
            }

            _tentativasErradas++;

            if (_tentativasErradas >= 3)
            {
                _bloqueado = true;
                return "Cofre Bloqueado.";
            }

            return $"Senha incorreta. Tentativas erradas: {_tentativasErradas}.";
        }

        public void Fechar()
        {
            _estaAberto = false;
        }

        public bool AlterarSenha(string senhaAntiga, string novaSenha)
        {
            if (!_estaAberto)
                return false;

            if (senhaAntiga != _senha)
                return false;

            if (string.IsNullOrWhiteSpace(novaSenha))
                return false;

            _senha = novaSenha;
            return true;
        }

        public void ResetarCofre(string novaSenha)
        {
            if (!string.IsNullOrWhiteSpace(novaSenha))
            {
                _senha = novaSenha;
                _estaAberto = false;
                _tentativasErradas = 0;
                _bloqueado = false;
            }
        }

        public override string ToString()
        {
            return $"Dono: {_dono} | Aberto: {_estaAberto} | Tentativas Erradas: {_tentativasErradas} | Bloqueado: {_bloqueado}";
        }
    }

    class Program
    {
        static void Main()
        {
            CofreDigital cofre = new CofreDigital("Drizo", "1234");

            Console.WriteLine(cofre.Abrir("1111"));
            Console.WriteLine(cofre.Abrir("2222"));
            Console.WriteLine(cofre.Abrir("3333"));

            Console.WriteLine(cofre);

            cofre.ResetarCofre("4321");
            Console.WriteLine(cofre.Abrir("4321"));

            bool alterou = cofre.AlterarSenha("4321", "9999");
            Console.WriteLine($"Senha alterada? {alterou}");

            Console.WriteLine(cofre);
        }
    }
}

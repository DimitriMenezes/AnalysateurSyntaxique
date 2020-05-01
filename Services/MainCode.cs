using System;
using System.Collections.Generic;
using System.Text;
using Services.Gram;

namespace Teste
{
    public class MainCode
    {
        public static void Main(string[] args)
        {

            var teste = "Je ai. Je suis, je ai et je suis née";

			new FrancaisGrammaire().Analyseur(teste);
        }
    }
}

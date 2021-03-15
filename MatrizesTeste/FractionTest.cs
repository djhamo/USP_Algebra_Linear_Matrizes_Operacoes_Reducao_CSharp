using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrizes.Modelo;
using System.Diagnostics;



//Comutativa: x+y = y+x
//Associativa: (x+y)+z = x+(y+z)
//Existência de elemento neutro: x +0 = x = 0+x
//Existência do Inverso x+(-x) = 0
//Espeço Vetorial
//(a+b)*v = a*v + b*v
//(a*b)*v = a*(b*v)
//a*(x+y) = a*x + a*y
//1*x = x

namespace Matrizes.Teste
{
    [TestClass]
    public class FractionTest
    {
        //Valor inteiro
        [TestMethod]
        public void DefineValorInteiroOK()
        {
            Fraction x = 1;
            Assert.AreEqual(1, x);
        }
        //Valor decimal
        [TestMethod]
        public void DefineValorDecimalOK()
        {
            Fraction x = 1.5;
            Assert.AreEqual(1.5, x);
        }
        //Valor fração
        [TestMethod]
        public void DefineValorFracaoOK()
        {
            Fraction x = "1/2";
            Assert.AreEqual<string>("1/2", x);
        }

        //Soma
        [TestMethod]
        public void SomaFractionOK()
        {
            Fraction x = "1/2";
            Fraction y = "3/7";
            Fraction result = x + y;
            Assert.AreEqual<string>("13/14", result);

            x = 1.5;
            y = 7.25;
            result = x + y;
            Assert.AreEqual(8.75, result);

            x = 3;
            y = 7;
            result = x + y;
            Assert.AreEqual(10, result);
        }

        //Subtração
        [TestMethod]
        public void SubtracaoFractionOK()
        {
            Fraction x = "1/2";
            Fraction y = "3/7";
            Fraction result = x - y;
            Assert.AreEqual<string>("1/14", result);

            x = 1.5;
            y = 7.25;
            result = x - y;
            Assert.AreEqual(-5.75, result);

            x = 3;
            y = 7;
            result = x - y;
            Assert.AreEqual(-4, result);
        }
        //Multiplicação
        [TestMethod]
        public void MultiplicacaoFractionOK()
        {
            Fraction x = "1/2";
            Fraction y = "3/7";
            Fraction result = x * y;
            Assert.AreEqual<string>("3/14", result);

            x = 1.5;
            y = 7.25;
            result = x * y;
            Assert.AreEqual(10.875, result);

            x = 3;
            y = 7;
            result = x * y;
            Assert.AreEqual(21, result);
        }
        //Divisão
        [TestMethod]
        public void DivisaoFractionOK()
        {
            Fraction x = "1/2";
            Fraction y = "3/7";
            Fraction result = x / y;
            Assert.AreEqual<string>("7/6", result);

            x = 1.5;
            y = 7.25;   
            result = x / y;
            Assert.AreEqual<string>("6/29", result);
            Debug.WriteLine("{0}", result.ToDouble());
            Assert.AreEqual(0.20689655, result.ToDouble(), 0.001);

            x = 3;
            y = 7;
            result = x / y;
            Assert.AreEqual(0.42857143, result.ToDouble(), 0.001);
        }

        //Soma Negativo
        //Subtração Negativo
        //Multiplicação Negativo
        //Divisão Negativo

        //Divisão por zero

        //Tamanho máximo

    }
}
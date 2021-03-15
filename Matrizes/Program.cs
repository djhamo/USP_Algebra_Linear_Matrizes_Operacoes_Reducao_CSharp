using System;
using Matrizes.Modelo;
using System.Diagnostics;

namespace Matrizes
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Fraction[,] _matriz = new Fraction[3, 3] { { 1.0, 2.0, 7.0 }, { 3.0, 4.0, 8.0 }, { 5.0, 6.0, 9.0 } };
            Matriz _meu = new Matriz(_matriz);
            _meu.Print();
            Console.WriteLine("Determinante {0}", _meu.Determinante());

            Matriz _ex = _meu.ExcluiLinhaColuna(1, 2);
            _ex.Print();
            Console.WriteLine("Determinante {0}", _ex.Determinante());

            Console.WriteLine("Cofatores");
            Matriz _cof = _meu.Cofatores();
            _cof.Print();

            Console.WriteLine("Transposta");
            Matriz _tan = _meu.Transposta();
            _tan.Print();

            Console.WriteLine("Adjunta");
            Matriz _adj = _meu.Adjunta();
            _adj.Print();

            Console.WriteLine("Determinante {0}", _meu.Determinante());

            Console.WriteLine("Inversa");
            Matriz _inv = new Matriz();
            try
            {
                _inv = _meu.Inversa();
                _inv.Print();
            }
            catch (Exception)
            {

            }

            
            Fraction[,] _matriz2 = new Fraction[2, 2] { { 2.0, 1.0 }, { 4.0, 3.0 } };
            Matriz _meu2 = new Matriz(_matriz2);

            _meu2.Print();

            Console.WriteLine("Adjunta");
            Matriz _adj2 = _meu2.Adjunta();
            _adj2.Print();

            Console.WriteLine("Determinante {0}", _meu2.Determinante());

            Console.WriteLine("Inversa");
            Matriz id = new Matriz();
            Matriz _inv2 = new Matriz();
            try
            {
                _inv2 = _meu2.Inversa();
                _inv2.Print();

                Console.WriteLine("MUltiplicando");
                id = _meu2 * _inv2;
                id.Print();
            }
            catch (Exception) { }

            Fraction[,] _matriz3 = new Fraction[4, 4] { { "1/1", "1/2", "1/3", "1/4" }, { "1/2", "1/3", "1/4", "1/5" }, { "1/3", "1/4", "1/5", "1/6" }, { "1/4", "1/5", "1/6", "1/7"} };
            Matriz _meu3 = new Matriz(_matriz3);
            _meu3.Print();

            Console.WriteLine("Determinante {0}", _meu3.Determinante());

            Console.WriteLine("Inversa");
            Matriz _inv3 = new Matriz();
            try
            {
                _inv3 = _meu3.Inversa();
                _inv3.Print();

                Console.WriteLine("MUltiplicando");
                id = _meu3 * _inv3;
                id.Print();
            }
            catch (Exception) { }


            Fraction[,] matriz4 = new Fraction[4, 4] { { 1, 1, 1, 1 }, { 1, 2, -1, 2 }, { 1, -1, 2, 1 }, { 1, 3, 3, 2 } };
            _meu3 = new Matriz(matriz4);
            _meu3.Print();

            Console.WriteLine("Inversa");
            _inv3 = new Matriz();
            try
            {
                _inv3 = _meu3.Inversa();
                _inv3.Print();

                Console.WriteLine("MUltiplicando");
                id = _meu3 * _inv3;
                id.Print();
            }
            catch (Exception) { }

            Console.ReadKey();

            Fraction res1 = 1;
            for (int i = 1; i <= 100; i++)
            {
                res1 += new Fraction(1, i);                
            }

            Fraction res2 = new Fraction(1, 100);
            for (int i = 99; i > 0; i--)
            {
                res2 += new Fraction(1, i);
            }
            res2 += 1;

            Console.WriteLine("Soma 1 {0} == Soma 2 {1} Iguais ? {2}", res1, res2, res1==res2);
            Console.ReadKey();

            Fraction[,] _matrizlu = new Fraction[2, 2] { { 1, 2 }, { 3, 6 } };
            Matriz _lu = new Matriz(_matrizlu);
            Console.Clear();
            _lu.Print();

            Console.WriteLine("Determinante {0}", _lu.Determinante());
            Console.ReadKey();

            BigInteger positive_big = Int64.MaxValue;

            positive_big = BigInteger.Pow(positive_big, 15);
            Console.WriteLine("Big int {0}", positive_big);
            Console.ReadKey();

            Fraction[,] _matriz55 = new Fraction[6, 6] { 
                { "1/1", "1/2", "1/3", "1/4", "1/5", "1/6" }, 
                { "1/2", "1/3", "1/4", "1/5", "1/6", "1/7" }, 
                { "1/3", "1/4", "1/5", "1/6", "1/7", "1/8" }, 
                { "1/4", "1/5", "1/6", "1/7", "1/8", "1/9" }, 
                { "1/5", "1/6", "1/7", "1/8", "1/9", "1/10" },
                { "1/6", "1/7", "1/8", "1/9", "1/10", "1/11" }
            };
            _meu3 = new Matriz(_matriz55);
            _meu3.Print();

            Console.WriteLine("Determinante {0}", _meu3.Determinante());

            Console.WriteLine("Inversa");
            _inv3 = new Matriz(6,6);
            try
            {
                _inv3 = _meu3.Inversa();
                _inv3.Print();
                Console.WriteLine("MUltiplicando");
                id = _meu3 * _inv3;
                id.Print();
            }
            catch (Exception) { }
           
            Console.ReadKey();

            Fraction[,] matriz7 = new Fraction[6, 6] { 
                { 1, -1, -8, 6, -4, 9 }, 
                { 6, -5, 5, -1, 2, 6 }, 
                { 8, 7, -9, 2, -3, 10 }, 
                { -5, -5, -9, -8, -6, -6 },
                { 5, -1, -3, 9, -8, -2 },
                { 3, 3, -3, -5, 9, -2 }                
            };
            _meu3 = new Matriz(matriz7);
            _meu3.Print();

            Console.WriteLine("Determinante {0}", _meu3.Determinante());
            _inv3 = new Matriz();
            try
            {
                Console.WriteLine("Inversa");
                _inv3 = _meu3.Inversa();
                _inv3.Print();

                Console.WriteLine("MUltiplicando");
                id = _meu3 * _inv3;
                id.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0}", ex.Message);
                Console.ReadKey();
            }
            */

            
            int length = 1024;
            Stopwatch stopwatch = new Stopwatch();
            for (int simulacao = 128; simulacao < length; simulacao*=2)
            {
                Fraction[,] _matriz = new Fraction[simulacao, simulacao];
                int denominador = 0;
                for (int i = 0; i < simulacao; i++)
                {
                    denominador = i + 1;
                    for (int j = 0; j < simulacao; j++)
                    {
                        _matriz[i, j] = new Fraction(1, denominador);
                        denominador++;
                    }
                        
                }
                Console.WriteLine("Matriz {0}x{1}", simulacao, simulacao);
                Matriz mtrz = new Matriz(_matriz);
                mtrz.Print();

                stopwatch.Restart();
                stopwatch.Start();
                Matriz _inv = mtrz.Inversa();
                stopwatch.Stop();

                _inv.Print();
                Matriz id = mtrz * _inv;
                id.Print();

                Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);
                Console.ReadKey();
            }

            Console.ReadKey();
            
            /*
            var list = new ConcurrentBag<string>();
            string[] dirNames = { ".", "..", @"c:\" };
            List<Task> tasks = new List<Task>();
            foreach (var dirName in dirNames)
            {
                Task t = Task.Run(() => {
                    foreach (var path in Directory.GetFiles(dirName))
                        list.Add(path);
                });
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            foreach (Task t in tasks)
                Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

            Console.WriteLine("Number of files read: {0}", list.Count);
            */
            /*
            Stopwatch stopwatch = new Stopwatch();
            int tam = 10;
            Fraction[,] _matriz = new Fraction[tam, tam];
            int denominador = 0;
            for (int i = 0; i < tam; i++)
            {
                denominador = i + 1;
                for (int j = 0; j < tam; j++)
                {
                    _matriz[i, j] = new Fraction(1, denominador);
                    denominador++;
                }

            }
            //Fraction[,] _matriz4 = new Fraction[4, 4] { { 1, 1, 1, 1 }, { 1, 2, -1, 2 }, { 1, -1, 2, 1 }, { 1, 3, 3, 2 } };
            Matriz _meu3 = new Matriz(_matriz);
            _meu3.Print();

            stopwatch.Start();
            Console.WriteLine("Determinante {0}", _meu3.Determinante());
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            stopwatch.Start();
            Console.WriteLine("Determinante Multi {0}", _meu3.DeterminanteMulti());
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);

            Matriz _inv3 = new Matriz();
            try
            {
                Console.WriteLine("Inversa");
                stopwatch.Start();
                _inv3 = _meu3.Inversa();
                stopwatch.Stop();
                _inv3.Print();

                Console.WriteLine("MUltiplicando");
                Matriz id = _meu3 * _inv3;
                id.Print();
                Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);

                stopwatch.Restart();
                Console.WriteLine("Inversa");
                stopwatch.Start();
                _inv3 = _meu3.InversaMulti();
                stopwatch.Stop();
                _inv3.Print();

                Console.WriteLine("MUltiplicando");
                id = _meu3 * _inv3;
                id.Print();
                Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception {0}", ex.Message);
                Console.ReadKey();
            }

            Console.ReadKey();
            
            /*
            
            Console.WriteLine("Teste de Fração");
            Fraction f1 = "1/3";
            Fraction f2 = "-1/3";
            Console.WriteLine("Valores {0} e {1}", f1, f2);
            Console.WriteLine("Valores +:{0} e *:{1}", f1 + f2, f1 * f2);
            Console.WriteLine("Valores -:{0} e /:{1}", f1 - f2, f1 / f2);
            Console.WriteLine("Valores -2:{0} e /2:{1}", f2 - f2, f2 / f2);

            Console.ReadKey();

            Fraction[,] _l = new Fraction[3, 3] { { 1, 0, 0 }, { 0.35, 1, 0 }, { 1.53, 0.972, 1 } };
            Matriz _ml = new Matriz(_l);
            Fraction[,] _u = new Fraction[3, 3] { { 3.17, 4.01, 3.15 }, { 0, 0.17, 1.24 }, { 0, 0, 2.35 } };
            Matriz _mu = new Matriz(_u);
            Fraction[,] _du = new Fraction[3, 3] { { 3.17, 0, 0 }, { 0, 0.17, 0 }, { 0, 0, 2.35 } };
            Matriz _mdu = new Matriz(_du);
            Fraction[,] _u2 = new Fraction[3, 3] { { 1, 1.265, 0.993 }, { 0, 1, 7.29 }, { 0, 0, 1 } };
            Matriz _mu2 = new Matriz(_u2);
            Matriz _mat = (_ml * _mu).Transposta();
            _ml.Print();
            _mu.Print();
            _mdu.Print();
            _mu2.Print();
            (_mdu * _mu2).Print();
            Console.WriteLine((_mdu * _mu2) == _mu);
            Console.ReadKey();
            (_ml * _mu).Transposta().Print();
            Console.WriteLine((_mu.Transposta() * _ml.Transposta()) == _mat);
            Console.ReadKey();

            Fraction[,] _matriz4 = new Fraction[4, 4] { { 2, -1, 1, -2 }, { 7, 0, 5, -4 }, { 3, 7, 5, 2 }, {-3, -11, -8, -2 } };
            Matriz _meu3 = new Matriz(_matriz4);
            _meu3.Print();
            _meu3.InversaLU().Print();
            //Matriz esc = _meu3.Escalonamento();
            //esc.Print();
            //if (esc.isLower())
            //    Console.WriteLine("Lower OK");
            //else
            //    Console.WriteLine("Lower NOK");

            _meu3.DecomposicaoLU();
            if ((_meu3.Lower * _meu3.Upper) == _meu3)
                Console.WriteLine("LU OK");
            else
            {
                Console.WriteLine("LU NOK");
                _meu3.Lower.Print();
                _meu3.Upper.Print();
                Console.ReadKey();
            }

            Console.WriteLine("Lower");
            _meu3.Lower.Print();
            if (_meu3.Lower.InversaLower() == _meu3.Lower.Inversa())
            {
                Console.WriteLine("Inversa Lower Ok");
                _meu3.Lower.InversaLower().Print();
            }
            else
            {
                Console.WriteLine("Inversa Lower NOk");
                _meu3.Lower.Inversa().Print();
                _meu3.Lower.InversaLower().Print();
                Console.ReadKey();
            }

            Matriz iddd = (_meu3.Lower.InversaLower() * _meu3.Lower);
            if (iddd.isIdentidade())
                Console.WriteLine("Inversa Lower Ok 2");
            else
            {
                Console.WriteLine("Inversa Lower NOk 2");
                iddd.Print();
                Console.ReadKey();
            }

            Console.WriteLine("Upper");
            _meu3.Upper.Print();
            if (_meu3.Upper.InversaUpper() == _meu3.Upper.Inversa())
            {
                Console.WriteLine("Inversa Upper Ok");
                _meu3.Upper.InversaUpper().Print();
            }                
            else
            {
                Console.WriteLine("Inversa Upper NOk");
                _meu3.Upper.Inversa().Print();
                _meu3.Upper.InversaUpper().Print();
                Console.ReadKey();
            }


            if ((_meu3.Upper.InversaUpper() * _meu3.Upper).isIdentidade())
                Console.WriteLine("Inversa Upper Ok 2");
            else
            {
                Console.WriteLine("Inversa Upper NOk 2");
                Console.ReadKey();
            }
            if ((_meu3.InversaLU()) == _meu3.Inversa())
                Console.WriteLine("Inversa Ok");
            else
            {
                Console.WriteLine("Inversa NOk");
                _meu3.Inversa().Print();
                (_meu3.Lower.InversaLower() * _meu3.Upper.InversaUpper()).Print();
                Console.ReadKey();
            }
            if ((_meu3 * (_meu3.Upper.InversaUpper() * _meu3.Lower.InversaLower())).isIdentidade())
                Console.WriteLine("Inversa 2 Ok");
            else
            {
                Console.WriteLine("Inversa 2 NOk");
                _meu3.Inversa().Print();
                (_meu3.Lower.InversaLower() * _meu3.Upper.InversaUpper()).Print();
                Console.ReadKey();
            }
            Console.ReadKey();

            Fraction[,] _matrizcal = new Fraction[3, 4] { { 1, 1, 0, 3 }, { 2, -1, 1, 5 }, { 3, 0, -1, 4 } };
            _meu3 = new Matriz(_matrizcal);
            _meu3.Print();
            //Fraction det = _meu3.Determinant;
            //Console.WriteLine("Determinante {0}", det);
            //if (det != 0)
                _meu3.Escalonamento().Print();
            Console.ReadKey();

            Fraction[,] _exe1 = new Fraction[3, 3] { { 2, 6, 2 }, { -3, -8, 0 }, { 4, 9, 2 } };
            Matriz exec1 = new Matriz(_exe1);

            exec1.Print();
            Console.WriteLine("Upper");
            exec1.Upper.Print();
            Console.WriteLine("Upper Inversa");
            exec1.Upper.InversaUpper().Print();
            Console.WriteLine("Lower");
            exec1.Lower.Print();
            Console.WriteLine("Lower Inversa");
            exec1.Lower.InversaLower().Print();
            (exec1.Lower * exec1.Upper).Print();
            Console.ReadKey();

            Stopwatch stopwatch = new Stopwatch();
            //int length = 64;
            int length = 1048576;
            //int simulacao = 1;
            //Parallel.For(0, length, t =>

            //List<Task> tasks = new List<Task>();

            for (int simulacao = 2; simulacao <= length; simulacao *= 2)
            {
                //Task t = Task.Factory.StartNew(() => {
                Matriz mtrz;
                Matriz _inv2;
                Matriz id;

                //simulacao *= 2;
                Fraction[,] _matriz = new Fraction[simulacao, simulacao];
                double[,] _matrizd = new double[simulacao, simulacao];
                int denominador = 0;
                for (int i = 0; i < simulacao; i++)
                {
                    denominador = i + 1;
                    for (int j = 0; j < simulacao; j++)
                    {
                        _matriz[i, j] = new Fraction(1, denominador);
                        _matrizd[i, j] = 1.0/denominador;
                        denominador++;
                    }

                }
                Console.WriteLine("Matriz {0}x{1}", simulacao, simulacao);
                mtrz = new Matriz(_matriz);
                //mtrz.Print();

                //stopwatch.Restart();
                //stopwatch.Start();
                //Matriz _inv = mtrz.Inversa();
                //stopwatch.Stop();

                //_inv.Print();
                //id = mtrz * _inv;
                //if (id.isIdentidade())
                //    Console.WriteLine("Invesa OK");
                //else
                //{
                //    Console.WriteLine("Invesa NOK");
                //    Console.ReadKey();

                //}

                //Console.WriteLine("Time elapsed: {0:hh\\:mm\\:ss}({1})", stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                try
                {
                    stopwatch.Start();
                    _inv2 = mtrz.InversaLU();
                    stopwatch.Stop();
                    Console.WriteLine("Multiplicando Com a Inversa para Identidade");
                    id = mtrz * _inv2;
                    if (id.isIdentidade())
                        Console.WriteLine("Invesa 2 OK");
                    else
                    {
                        Console.WriteLine("Invesa 2 NOK");
                        id.Print();
                        Console.ReadKey();

                    }

                    Console.WriteLine("Matriz {0}x{0} Time elapsed: {1:hh\\:mm\\:ss}({2})", simulacao, stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);
                }
                catch (Exception ex)
                {
                    //mtrz.Print();
                    Console.WriteLine("Exception {0} -> {1}", ex.Message, ex.ToString());
                    Console.ReadKey();
                }
                //Console.ReadKey();

                //stopwatch.Restart();
                //stopwatch.Start();
                //Matrix<double> inversa = sample.Inverse();
                //Matrix<double> ids = sample * inversa;
                //Matrix<double> ids2 = Matrix<double>.Build.DiagonalIdentity(simulacao);
                //Console.WriteLine(ids);
                //Console.WriteLine(ids2);
                //if (ids == ids2)
                //    Console.WriteLine("Invesa 2 OK");
                //else
                //{
                //    Console.WriteLine("Invesa 2 NOK");
                //    Console.ReadKey();

                //}
                //stopwatch.Stop();

                //Console.WriteLine("Matriz Sample {0}x{0} Time elapsed: {1:hh\\:mm\\:ss}({2})", simulacao, stopwatch.Elapsed, stopwatch.ElapsedMilliseconds);

                
                //}
                //);
                //tasks.Add(t);
            }

            //Task.WaitAll(tasks.ToArray());

            
            /*
            Console.WriteLine("Exec 1");

            Fraction[,] _exe1A = new Fraction[3, 3] { { 1, 1, 0 }, { -1, 0, 2 }, { 1, -1, 0 } };
            Matriz exec1A = new Matriz(_exe1A);

            Fraction[,] _exe1B = new Fraction[3, 3] { { 4, 2, 1 }, { 6, 3, -1 }, { 1, 2, 1 } };
            Matriz exec1B = new Matriz(_exe1B);

            Fraction[,] _permut2_3 = new Fraction[3, 3] { { 1, 0, 0 }, { 0, 0, 1 }, { 0, 1, 0 } };
            Matriz permut2_3 = new Matriz(_permut2_3);

            Console.WriteLine("MAtriz A");
            Console.WriteLine("Determinante A {0}", exec1A.Determinant);
            exec1A.Print();
            Console.WriteLine("Upper A");
            Matriz exec1AU = exec1A.Upper;
            exec1AU.Print();
            Console.WriteLine("Upper Inversa A");
            exec1AU.InversaUpper().Print();
            Console.WriteLine("Lower A");
            Matriz exec1AL = exec1A.Lower;
            exec1AL.Print();
            Console.WriteLine("Lower Inversa A");
            exec1AL.InversaLower().Print();
            Console.WriteLine("Inversa A");
            Matriz exec1AI = exec1A.InversaLU();
            exec1AI.Print();
            Console.WriteLine("MAtriz L*U");
            (exec1AL * exec1AU).Print();
            Console.WriteLine("Teste Inversa");
            (exec1A * exec1AI).Print();

            Console.WriteLine("MAtriz B");
            Console.WriteLine("Determinante B {0}", exec1B.Determinant);
            exec1B.Print();
            permut2_3.Print();
            (permut2_3 * exec1B).Print();
            Matriz exec1BP = (permut2_3 * exec1B);
            Console.WriteLine("Upper B");
            exec1BP.Upper.Print();
            Console.WriteLine("Upper Inversa B");
            exec1BP.Upper.InversaUpper().Print();
            Console.WriteLine("Lower B");
            exec1BP.Lower.Print();
            Console.WriteLine("Lower Inversa B");
            exec1BP.Lower.InversaLower().Print();
            Console.WriteLine("Inversa B");
            exec1BP.InversaLU().Print();
            Console.WriteLine("Inversa B Permut");
            (permut2_3 * exec1BP.InversaLU()).Print();
            Console.WriteLine("MAtriz L*U");
            (exec1BP.Lower * exec1BP.Upper).Print();
            Console.WriteLine("Teste Inversa");
            (exec1B * ( exec1BP.InversaLU() * permut2_3)).Print();
            Console.ReadKey();


            Console.WriteLine("Exec 2");
            Fraction[,] _exe2L = new Fraction[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { "1/2", 0, 1 } };
            Matriz exe2L = new Matriz(_exe2L);

            Fraction[,] _exe2U = new Fraction[3, 3] { { 2, 2, 1 }, { 0, 2, 1 }, { 0, 0, "-3/2" } };
            Matriz exe2U = new Matriz(_exe2U);

            Fraction[,] _permut2 = new Fraction[3, 3] { { 0, 0, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };
            Matriz permut2 = new Matriz(_permut2);

            Fraction[,] _permut2I = new Fraction[3, 3] { { 0, 1, 0 }, { 0, 0, 1 }, { 1, 0, 0 } };
            Matriz permut2I = new Matriz(_permut2I);

            Console.WriteLine("L");
            exe2L.Print(); 
            Console.WriteLine("U");
            exe2U.Print();
            Console.WriteLine("Permut");
            (permut2 * exe2U).Print();
            Console.WriteLine("Permut Inv");
            (permut2I * (permut2 * exe2U)).Print();

            Console.WriteLine("L * U");
            (exe2L * exe2U).Print();

            Console.WriteLine("Matriz B = PA");
            Matriz exe2B = (exe2L * exe2U);
            exe2B.Print();

            Console.WriteLine("Inversa B");
            Matriz exe2BI = exe2U.InversaUpper() *  exe2L.InversaLower();
            exe2BI.Print();

            Console.WriteLine("Teste da Inversa B");
            (exe2B * exe2BI).Print();

            Console.WriteLine("Matriz PA = B");
            Matriz exe2A = permut2.Transposta() * exe2B;
            Console.WriteLine("Matriz A");
            exe2A.Print();

            Matriz exe2AI = permut2I * exe2BI;
            Console.WriteLine("Matriz Inversa A");
            exe2AI.Print();

            Console.WriteLine("Teste da Inversa A");
            (exe2A * exe2AI).Print();

            Fraction[,] _permut3 = new Fraction[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            Matriz permut3 = new Matriz(_permut3);

            Matriz exe11 = (permut2_3 * exec1A);
            exe11.Print();
            exe11.Lower.Print();
            exe11.Upper.Print();
            Console.ReadKey();

            Console.Clear();

            Matriz resp = (permut2.Transposta() * exe2L * exe2U).Inversa();
            exe2A.Print();
            resp.Print();
            (exe2A * resp).Print();
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("L");
            exe2L.Print();
            Console.WriteLine("Inversa L");
            exe2L.InversaLower().Print();

            Console.WriteLine("U");
            exe2U.Print();
            Console.WriteLine("Inversa U");
            exe2U.InversaUpper().Print();

            Console.ReadKey();
            
            Console.Clear();
            Fraction[,] _permut3 = new Fraction[3, 3] { { 1, -3, -3 }, { 0, -4, -4 }, { -2, -6, -6 } };
            Matriz permut3 = new Matriz(_permut3);

            permut3.Print();
            permut3.Escalonamento().Print();
            */
            Console.ReadKey();
        }
    }
}

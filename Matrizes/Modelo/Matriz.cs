using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Preciso melhorar o método de acesso aos itens da matriz, por exemplo se fizer o determinante e mudar um item preciso setar o estado para false
// Matriz nula ou identidade qdo constroe passando a linha e a coluna?
// Criar um método pra fazer uma identidade (DecomposicaoLU e InversaLower precisam)
//Montar os testes de unidade
//Metodo privado pra multiplicar uma linha por uma coluna
//overload do operado[]
namespace Matrizes.Modelo
{
    public class Matriz
    {
        public Matriz Upper {
            get
            {
                if (!isLU) DecomposicaoLU();
                return _upper;                
            }
        }
        public Matriz Lower
        {
            get
            {
                if (!isLU) DecomposicaoLU();
                return _lower;
            }
        }
        public int Linha { get; private set; }
        public int Coluna { get; private set; }
        private Fraction[][] _matriz;

        private bool isDeterminante;
        private Fraction _determinante;
        private Matriz _upper;
        private Matriz _lower;

        public Fraction Determinant {
            get {
                if (isDeterminante) return _determinante;
                return Determinante();
            }
        }

        private bool isLU;

        public Matriz() : this(3, 3)
        {

            //_matriz = new Fraction[3, 3] { { 1, 2, 7 }, { 3, 4, 8 }, { 5, 6, 9 }};
        }

        public Matriz(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            _matriz = new Fraction[Linha][];
            for (int i = 0; i < Linha; i++)
            {
                _matriz[i] = new Fraction[Coluna];
            }
            isDeterminante = false;
            isLU = false;
            //Faz a identidade
            Parallel.For(0, Linha, l =>
            //for (int l = 0; l < Linha; l++)
            {
                for (int c = 0; c < Coluna; c++)
                {
                    this[l, c] = 0;
                }
            }
            );
        }

        public Matriz(Fraction[,] matriz) : this(matriz.GetLength(0), matriz.GetLength(1))
        {
            //_matriz = matriz;
            Parallel.For(0, Linha, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    this[l, c] = matriz[l,c];
                }
            }
            );

            isDeterminante = false;
        }

        public Matriz(Fraction[][] matriz) : this(matriz.Length, matriz[0].Length)
        {
            //_matriz = matriz;
            Parallel.For(0, Linha, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    this[l, c] = matriz[l][c];
                }
            }
            );

            isDeterminante = false;
        }

        public void Print()
        {
            Print(this);
        }

        public void Print(Matriz _tmp)
        {
            for (int l = 0; l < Linha; l++)
            {
                for (int c = 0; c < Coluna; c++)
                {
                    if (c == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write("{0,-4}", _tmp[l, c]);
                    if ((c + 1) == Coluna)
                    {
                        Console.WriteLine("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                } 
            }
            Console.WriteLine();
                       
        }
        public Fraction Determinante()
        {
            if (Linha != Coluna)
                throw new Exception("Matriz não é Quadrada");

            if (Linha == 1 && Coluna == 1)
            {
                Fraction _result = this[0, 0];
                isDeterminante = true;
                _determinante = _result;

                return _result;
            }
            else if (Linha == 2 && Coluna == 2)
            {
                Fraction _result =
                    (this[0, 0] * this[1, 1]) -
                    (this[0, 1] * this[1, 0]);
                isDeterminante = true;
                _determinante = _result;

                return _result;
            }
            else if (Linha == 3 && Coluna == 3)
            {
                Fraction _result =
                       ((this[0, 0] * this[1, 1] * this[2, 2]) +
                        (this[0, 1] * this[1, 2] * this[2, 0]) +
                        (this[0, 2] * this[1, 0] * this[2, 1]))
                       -
                       ((this[0, 0] * this[1, 2] * this[2, 1]) +
                        (this[0, 1] * this[1, 0] * this[2, 2]) +
                        (this[0, 2] * this[1, 1] * this[2, 0]));
                isDeterminante = true;
                _determinante = _result;

                return _result;
            }
            else if (Linha <=5  && Coluna <= 5)
            {
                Fraction _result = 0;
                for (int c = 0; c < Coluna; c++)
                {
                    Matriz mini = this.ExcluiLinhaColuna(0, c);
                    Fraction det = mini.Determinante();
                    if (c % 2 != 0)
                    {
                        det *= -1;
                    }
                    _result += this[0, c] * det;
                }
                isDeterminante = true;
                _determinante = _result;
                return _result;

            }

            List<Task<Fraction> > tasks = new List<Task<Fraction> >();

            int l = 0;
            Fraction result = 0;
            for (int c = 0; c < Coluna; c++)
            {
                Fraction posicao = this[l, c];
                Matriz mini = this.ExcluiLinhaColuna(l, c);
                int mult = 1;
                if ((l + c) % 2 != 0)
                {
                    mult = -1;
                }

                Task<Fraction> t = Task<Fraction>.Factory.StartNew(() => {
                    Fraction det = mini.Determinante();
                    //mini.Print();
                    return ( posicao * mult * det );
                    //Console.WriteLine("Determinante {0}x{1} => {2} * {3} = {4}", mini.Linha, mini.Coluna, det, posicao, pre_result);
                    //list_result.Add(pre_result);
                });
                tasks.Add(t);             
            }

            Task.WaitAll(tasks.ToArray());
            foreach (var presult in tasks)
            {
                result += presult.Result;
            }
            isDeterminante = true;
            _determinante = result;
            return result;
        }

        public void set(Fraction valor, int linha, int coluna)
        {
            this[linha, coluna] = valor;
        }

        public Fraction get(int linha, int coluna)
        {
            return this[linha, coluna];
        }

        public Matriz ExcluiLinhaColuna(int linha, int coluna)
        {
            int new_linha = (Linha - 1);
            int new_coluna = (Coluna - 1);
            Matriz result = new Matriz(new_linha, new_coluna);
            int lin = 0, col = 0;
            //Parallel.For(0, new_linha, l =>
            for (int l = 0; l < new_linha; l++)
            {
                if (l == linha)
                {
                    lin++;
                }

                for (int c = 0; c < new_coluna; c++)
                {
                    if (c == coluna)
                    {
                        col++;
                    }
                    result[l, c] = this[lin, col];
                    col++;
                }
                lin++;

                col = 0;
            }
            //);
            return result;

        }

        public Matriz Cofatores()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Parallel.For(0, Linha, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    Fraction posicao = this[l, c];
                    Matriz mini = this.ExcluiLinhaColuna(l, c);
                    int mult = 1;
                    if ((l + c) % 2 != 0)
                    {
                        mult = -1;
                    }
                    Fraction det = mini.Determinante();
                    result[l, c] = (mult * det);

                }

            }
            );
            return result;
        }

        public Matriz Transposta()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Parallel.For(0, Linha, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    result[l, c] = this[c, l];

                }

            });
            return result;
        }

        public Matriz Adjunta()
        {
            return this.Cofatores().Transposta();
        }


        public Matriz Inversa()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Fraction detA = Determinante();

            if (detA == 0)
                throw new Exception("Não Dividiras por ZERO");

            Matriz ad = Adjunta();

            Parallel.For(0, Coluna, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    result[l, c] = (ad[l, c] / detA);
                }
            }
            );
            return result;
        }

        public Matriz Escalonamento()
        {
            Matriz result = new Matriz(Linha, Coluna);
            result.Clone(this);
            int ultima_linha = 0;
            for (int c = 0; c < (Coluna - 1); c++)
            {
                Fraction pivo = result[c, c];
                if (pivo == 0)
                    throw new Exception("Pivo = Zero Não Dividiras por ZERO");
                int linha_pivo = c;
                //Console.WriteLine("Pivo {0}", pivo);

                for (int l = (c +1); l < Linha; l++)
                {
                    Fraction multiplicador = result[l, c] / pivo;
                    //Console.WriteLine("Mult {0}", multiplicador);
                    for (int col = c; col < Coluna; col++)
                    {
                        result[l, col] = result[l,col] - (multiplicador * result[linha_pivo, col]);
                    }
                    ultima_linha = l;
                }
                //result.Print();
            }
            //result.Print();

            for (int c = ultima_linha; c >= 0; c--)
            {
                Fraction pivo = result[c, c];
                if (pivo != 0)
                {
                    int linha_pivo = c;
                    //Console.WriteLine("Pivo {0}", pivo);

                    for (int l = (c - 1); l >= 0; l--)
                    {
                        Fraction multiplicador = result[l, c] / pivo;
                        //Console.WriteLine("Mult {0}", multiplicador);
                        for (int col = (Coluna - 1); col >= 0; col--)
                        {
                            result[l, col] = result[l, col] - (multiplicador * result[linha_pivo, col]);
                        }
                    }

                }
                //break;
                //throw new Exception("Pivo = Zero Não Dividiras por ZERO");
                //result.Print();
            }

            //Obtendo a ID      
            Parallel.For(0, Linha, i =>
            //for (int i = 0; i < Coluna; i++)
            {
                Fraction div = result[i, i];
                if (div != 0)
                {
                    result[i, i] /= div;
                    result[i, (Coluna - 1)] /= div;

                }
            }
            );

            return result;
        }

        public void DecomposicaoLU()
        {

            _upper = new Matriz(Linha, Coluna);
            _lower = new Matriz(Linha, Coluna);
            _upper.Clone(this);
            //Parallel.For((c + 1), Linha, l =>
            for (int c = 0; c < (Coluna - 1); c++)
            {
                Fraction pivo = _upper[c, c];
                int linha_pivo = c;
                Parallel.For((c + 1), Linha, l =>
                //for (int l = (c + 1); l < Linha; l++)
                {
                    Fraction multiplicador = _upper[l, c] / pivo;
                    _lower[l, c] = multiplicador;
                    Console.WriteLine("Mult {0}, Linha Pivo {1}, Linha Alvo {2}", multiplicador, linha_pivo, l);
                    for (int col = c; col < Coluna; col++)
                    {
                        _upper[l, col] = _upper[l, col] - (multiplicador * _upper[linha_pivo, col]);
                    }
                    _upper.Print();
                });
            }
            Parallel.For(0, Coluna, i =>
            //for (int i = 0; i < Coluna; i++)
            {
                _lower[i, i] = 1;
            }
            );
            //Upper.Print();
            //Lower.Print();
            //Matriz mult = Lower * Upper;
            //mult.Print();

            //if (mult == this)
            //    Console.WriteLine("Deu Ok");
            isLU = true; ;
        }

        public Matriz InversaLU()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Matriz invl = new Matriz();
            Matriz invu = new Matriz();
            if (isLU)
                DecomposicaoLU();
            Task t1 = Task.Factory.StartNew(() =>
            {
                invl = _lower.InversaLower();
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                invu = _upper.InversaUpper();
            });
            t1.Wait();
            t2.Wait();
            result = invu * invl;
            return result;
        }

        public Matriz InversaLower()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Parallel.For(0, Coluna, i =>
            //for (int i = 0; i < Coluna; i++)
            {
                result[i, i] = 1;
            }
            );
            Parallel.For(0, (Coluna - 1), c =>
            //for (int l = 1; l < Linha; l++)
            {
                for (int l = (c + 1); l < Linha; l++)
                {
                    Fraction pivo = 0;
                    for (int cont = 0; cont < l; cont++)
                    {
                        pivo += (this[l, cont] * result[cont, c]);
                    }
                    pivo *= -1;
                    result[l, c] = pivo;
                }
            }
            );
            return result;
        }
        public Matriz InversaUpper()
        {
            Matriz result = new Matriz(Linha, Coluna);
            Parallel.For(0, Coluna, i =>
            //for (int i = 0; i < Coluna; i++)
            {
                result[i, i] = 1 / this[i, i];
            }
            );
            Parallel.For(1, Coluna, c =>
            {
                for (int l = (c - 1); l >= 0; l--)
                {
                    Fraction pivo = 0;
                    int ultpos = 0;
                    for (int cont = c; cont >= l; cont--)
                    {
                        pivo += (this[l, cont] * result[cont, c]);
                        ultpos = cont;
                    }
                    pivo *= -1;
                    result[l, c] = pivo / this[l, ultpos];

                }
                
            }
            );
            return result;
        }

        public static Matriz operator +(Matriz c1, Matriz c2)
        {
            Matriz result = new Matriz(c1.Linha, c1.Coluna);
            Parallel.For(0, c1.Linha, l =>
            {
                for (int c = 0; c < c1.Coluna; c++)
                {
                    result[l, c] = (c1[l, c] + c2[l, c]);
                }
            }
            );
            return result;
        }
        public static Matriz operator -(Matriz c1, Matriz c2)
        {
            Matriz result = new Matriz(c1.Linha, c1.Coluna);
            Parallel.For(0, c1.Linha, l =>
            {
                for (int c = 0; c < c1.Coluna; c++)
                {
                    result[l, c] = (c1[l, c] - c2[l, c]);
                }
            }
            );
            return result;
        }
        public static Matriz operator *(Matriz c1, Matriz c2)
        {
            if (c1.Coluna != c2.Linha)
                throw new Exception("Não dá pra Multiplicar as Matrizes");

            Matriz result = new Matriz(c1.Linha, c1.Coluna);

            Parallel.For(0, c1.Linha, i =>
            {
                for (int j = 0; j < c2.Coluna; ++j) 
                    for (int k = 0; k < c1.Coluna; ++k) 
                        result[i,j] += c1[i,k] * c2[k,j];
            }
            );
            return result;
        }
        public static bool operator ==(Matriz c1, Matriz c2)
        { return c1.Equals(c2); }

        public static bool operator !=(Matriz c1, Matriz c2)
        { return (!c1.Equals(c2)); }

        public override bool Equals(object obj)
        {
            Matriz test = (Matriz)obj;
            if (Coluna != test.Coluna)
                return false;
            if (Linha != test.Linha)
                return false;

            bool result = true;
            Parallel.For(0, Linha, (l, loopstate) =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    if (this[l, c] != test[l, c])
                    {
                        result = false;
                        loopstate.Stop();
                    }                   
                        
                }
            }
            );
            return result;
        }

        public override int GetHashCode()
        {
            return (Convert.ToInt32((Coluna ^ Linha) & 0xFFFFFFFF));
        }

        public Fraction this[int x, int y]
        {
            get { return _matriz[x][y]; }
            set { _matriz[x][y] = value; }
        }


        public bool isIdentidade()
        {
            bool result = true;
            Parallel.For(0, Linha, (l, loopstate) =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    if ((l != c) && this[l,c] != 0)
                    {
                        result = false;
                        loopstate.Stop();
                    }
                    if ((l == c) && this[l, c] != 1)
                    {
                        result = false;
                        loopstate.Stop();
                    }
                }
            }
            );
            return result;
        }

        public bool isLower()
        {
            bool result = true;
            Parallel.For(0, Linha, (l, loopstate) =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    if ((l > c) && this[l, c] != 0)
                    {
                        result = false;
                        loopstate.Stop();
                    }

                }
            }
            );
            return result;
        }

        public bool isUpper()
        {
            bool result = true;
            Parallel.For(0, Linha, (l, loopstate) =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    if ((l < c) && this[l, c] != 0)
                    {
                        result = false;
                        loopstate.Stop();
                    }
                }
            }
            );
            return result;
        }

        public void Clone(Matriz temp)
        {
            Parallel.For(0, Linha, l =>
            {
                for (int c = 0; c < Coluna; c++)
                {
                    this[l, c] = temp[l,c];
                }
            }
            );

        }
    }
}

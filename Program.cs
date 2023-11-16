using System.Text;
internal class Program
{
    static int RomanoToArabico(string Romano)
    {
        //Criando Dicionário
        Dictionary<char, int> RomanosArabicos = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int Arabico = 0;
        //Montando o algarismo Romano
        for (int i = 0; i < Romano.Length; i++)
        {

            if (i + 1 < Romano.Length && RomanosArabicos[Romano[i]] < RomanosArabicos[Romano[i + 1]])
            {
                Arabico -= RomanosArabicos[Romano[i]];
            }
            else
            {
                Arabico += RomanosArabicos[Romano[i]];
            }
        }

        return Arabico;
    }
    private static void Main(string[] args)
    {
        //Criando uma entrada do tipo string para conformar se deseja repetir o processo
        string confirmar;
        //Iniciando o loop do programa
        do
        {
            //Solicitando ao usuário a entrada de dados
            Console.WriteLine("Informe o número romano  ou arabico entre 0 e 3999 para conversão: ");
            object variavel = Console.ReadLine() ?? "";
            //Identificando se a variável é um número ou letras, se for número o objeto é convertido para número real
            for (int i = 0; i < Convert.ToString(variavel).Length; i++)
            {
                if (Convert.ToString(variavel)[i] >= '0' && Convert.ToString(variavel)[i] <= '9')
                {
                    variavel = Convert.ToDouble(variavel);
                }

            }

            //Caso a variável não se ja número, é inicado o processo abaixo
            if (variavel.GetType() == typeof(string) || variavel.GetType() == typeof(char))
            {
                //Caso a entrada seja em letras minúsculas, o algoritmo converte para maíusculas, e armazena em um stringBuilder
                StringBuilder maiusculo = new StringBuilder();
                for (int i = 0; i < Convert.ToString(variavel).Length; i++)
                {
                    if (Convert.ToString(variavel)[i] >= 'a' && Convert.ToString(variavel)[i] <= 'z')
                    {
                        maiusculo.Append(Convert.ToChar(Convert.ToString(variavel)[i] - 'a' + 'A'));

                    }
                    else
                    {
                        maiusculo.Append(Convert.ToString(variavel)[i]);
                    }


                }
                // A entrada passa a ser o conteúdo do stringBuilder
                string Romano = maiusculo.ToString();



                for (int i = 0; i < Romano.Length; i++)
                {
                    //nessa sequência é conferido se as letras digitadas pertence ao dicionário de algarismos romanos
                    while (Romano[i] != 'I' && Romano[i] != 'V' && Romano[i] != 'X' && Romano[i] != 'L' && Romano[i] != 'C' && Romano[i] != 'D' && Romano[i] != 'M' || Romano.Length > 9)
                    {
                        Console.WriteLine("Algarismo romano inexistente, Informe outro: ");
                        Romano = Console.ReadLine() ?? "";

                        StringBuilder maiusculo2 = new StringBuilder();

                        for (int j = 0; j < Romano.Length; j++)
                        {
                            if (Romano[j] >= 'a' && Romano[j] <= 'z')
                            {
                                maiusculo2.Append(Convert.ToChar(Romano[j] - 'a' + 'A'));
                            }
                            else
                            {
                                maiusculo2.Append(Romano[j]);
                            }
                        }

                        Romano = maiusculo2.ToString();


                    }

                }
                //Por fim é dada a resposta
                Console.Write("O número Romano informado, em arábico é: ");
                Console.Write(RomanoToArabico(Romano));
                Console.WriteLine("\n");
                //é perguntado se quer que o processo ocorra novamente
                Console.WriteLine("Deseja repetir o processo?\nSe sim digite \"Sim\"");


            }
            // caso a variável twnha número e seja convertida para double é feito o seguinte processo
            else if (variavel.GetType() == typeof(int) || variavel.GetType() == typeof(double))
            {
                // são iniciados vetores com os números romanos 
                string[] unidades = new string[10] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
                string[] dezenas = new string[10] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
                string[] centenas = new string[10] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
                string[] milhares = new string[4] { "", "M", "MM", "MMM" };
                
                //O valor é aproximado para o inteiro mais próximo caso seja decimal
                double valor = Convert.ToDouble(variavel);
                int valor2 = Convert.ToInt32(Math.Round(valor, 0));

                //confere se o número está dentro do intervalo que os algorismos romanos abrangem
                while (valor > 3999 || valor <= 0)
                {
                    Console.WriteLine("Informe um valor dentro do intervalo");
                    valor = Convert.ToInt32(Console.ReadLine());
                    valor2 = Convert.ToInt32(Math.Round(valor, 0));
                }
                Console.Write("O número arábico informado, em romano é: ");
                Console.Write(milhares[valor2 / 1000]);
                Console.Write(centenas[valor2 % 1000 / 100]);
                Console.Write(dezenas[valor2 % 1000 % 100 / 10]);
                Console.Write(unidades[valor2 % 1000 % 100 % 10]);

                Console.WriteLine("\n");
                //é perguntado se quer que o processo ocorra novamente
                Console.WriteLine("Deseja repetir o processo?\nSe sim digite \"Sim\"");


            }
            //usuário escolher se quer continuar
            confirmar = Console.ReadLine();
        } while (confirmar == "SIM" || confirmar == "sim" || confirmar == "Sim");
    }
}

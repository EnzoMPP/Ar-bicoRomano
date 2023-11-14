using System.Text;
internal class Program
{
    static int RomanoToArabico(string Romano)
    {
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
        string confirmar;
        do{
            Console.WriteLine("Informe o número romano  ou arabico entre 0 e 3999 para conversão: ");
            object variavel=Console.ReadLine()??"";
            for(int i=0; i<Convert.ToString(variavel).Length;i++)
            {
                if(Convert.ToString(variavel)[i]>='0'&&Convert.ToString(variavel)[i]<='9')
                {
                    variavel=Convert.ToInt32(variavel);
                }

            }


            if(variavel.GetType()==typeof(string)||variavel.GetType()==typeof(char))
            {
                StringBuilder maiusculo= new StringBuilder();
                for(int i=0;i<Convert.ToString(variavel).Length;i++)
                {
                    if(Convert.ToString(variavel)[i]>='a'&&Convert.ToString(variavel)[i]<='z')
                    {
                        maiusculo.Append(Convert.ToChar(Convert.ToString(variavel)[i]-'a'+'A'));

                    }
                    else
                    {
                        maiusculo.Append(Convert.ToString(variavel)[i]);
                    }


                }

                string Romano= maiusculo.ToString();



                for(int i=0;i<Romano.Length;i++)
                {
                    while(Romano[i]!='I'&& Romano[i]!='V'&& Romano[i]!='X'&& Romano[i]!='L'&& Romano[i]!='C'&& Romano[i]!='D'&& Romano[i]!='M'|| Romano.Length>9)
                    {
                        Console.WriteLine("Algarismo romano inexistente, Informe outro: ");
                        Romano=Console.ReadLine()??"";

                        StringBuilder maiusculo2=new StringBuilder();

                        for(int j=0;j<Romano.Length;j++)
                        {
                            if(Romano[j]>='a'&& Romano[j]<='z')
                            {
                                maiusculo2.Append(Convert.ToChar(Romano[j]-'a'+'A'));
                            }
                            else
                            {
                                maiusculo2.Append(Romano[j]);
                            }
                        }

                        Romano=maiusculo2.ToString();


                    }

                }
                Console.Write("O número Romano informado, em arábico é: ");
                Console.Write(RomanoToArabico(Romano));
                Console.WriteLine("\n");
                Console.WriteLine("Deseja repetir o processo?\nSe sim digite \"Sim\"");


            }
            else if(variavel.GetType()==typeof(int)||variavel.GetType()==typeof(double))
            {
                string [] unidades= new string [10] {"","I","II","III","IV","V","VI","VII","VIII","IX"};
                string [] dezenas= new string[10]{"","X","XX","XXX","XL","L","LX","LXX","LXXX","XC"};
                string[] centenas= new string [10]{"","C","CC","CCC","CD","D","DC","DCC","DCCC","CM"};
                string[] milhares= new string[4]{"","M","MM","MMM"};


                double valor=Convert.ToDouble(variavel);
                int valor2=Convert.ToInt32(Math.Round(valor,0));


                while(valor>3999 || valor<=0)
                {
                    Console.WriteLine("Informe um valor dentro do intervalo");
                    valor=Convert.ToInt32(Console.ReadLine());
                    valor2=Convert.ToInt32(Math.Round(valor,0));
                }
                Console.Write("O número arábico informado, em romano é: ");
                Console.Write(milhares[valor2/1000]);
                Console.Write(centenas[valor2%1000/100]);
                Console.Write(dezenas[valor2%1000%100/10]);
                Console.Write(unidades[valor2%1000%100%10]);

                Console.WriteLine("\n");

                Console.WriteLine("Deseja repetir o processo?\nSe sim digite \"Sim\"");
               

            }
            confirmar=Console.ReadLine();
        } while (confirmar == "SIM" || confirmar == "sim" || confirmar == "Sim");
    }
}

using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        /*
            W mainie chcemy:
            - Odpytywać użytkownika o to, co chce zrobić. Czy zapisać tekst do, czy odczytać z pliku
            - Wywoływać metodę zapisywacz
            - Określać ścierzkę do pliku
        */

        string scierzka = ("C:/Users/Program-W2/Desktop/moj_output.txt");

        Console.WriteLine("Wpisz swoj wlasny tekst!: ");
        string tekst = Console.ReadLine();

        Console.WriteLine("Teraz, co chcesz zrobic?");
        Console.WriteLine("a) Zapisz tekst");
        Console.WriteLine("b) Wypisz tekst z pliku");
        Console.WriteLine("--");
        string wybor = Console.ReadLine();

        if(!string.IsNullOrEmpty(wybor))
        {
            try
            {
                char menu = char.Parse(wybor);

                if(menu == 'a')
                {
                    //Wywoływanie funkcji:
                     //Odnieś się do instancji(z odpowiednimi danymi)
                    Console.WriteLine("Tekst zostal zapisany!");
                    Save(scierzka, tekst);
                    Console.ReadKey();
                }

                else if(menu == 'b')
                {
                    Read(scierzka);
                }

                else
                {
                    Console.WriteLine("Nie ma takiego wyboru w polu wyboru!");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Wartosc jest niepoprawna!");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Przepraszam, niepoprawny tekst!");
            Console.ReadKey();
        }
    }

    //Tworzymy nową instancję zapisującą, w której będzie znajdowała się metoda Stream. Dodatkowo, należy pamiętać, aby wrzucić zmienną do instancji.
    public static void Save(string scierzka, string tekst)
    {
        using (StreamWriter zapisywacz = new StreamWriter(scierzka, true)) //Wartość true pozwala na zapis do pliku, a nie na jego modyfikacje.
        {
            zapisywacz.WriteLine(tekst);
        }
    }

    //Tworzymy nową instancję odczytującą. Musimy jej podać ścierzkę do pliku
    public static void Read(string scierzka)
    {
        //Próbujemy sprawdzić czy plik istnieje
        try
        {
            if(File.Exists(scierzka))
            {
                //Używamy metody streamwriter do odczytu
                using (StreamReader odczyt = new StreamReader(scierzka))
                {
                    //pętlą while, odczytujemy każdą linijkę po kolei. Dodatkowo tworzymy zmienną na tekst
                    string wiersze;
                    while((wiersze = odczyt.ReadLine()) != null) 
                        Console.WriteLine(wiersze);

                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Plik nie istnieje!");
                Console.ReadKey();
            }
        }
        catch
        {
            Console.WriteLine("Wystapil blad pliku...");
            Console.ReadKey();
        }
    }
}


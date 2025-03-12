// See https://aka.ms/new-console-template for more information
using modul4_103022300119;

class Program
{
    static void Main()
    {
        KodeProduk KodeProduk = new KodeProduk();

        Console.Write("Masukkan nama Produk: ");
        string elektronik = Console.ReadLine();

        Console.WriteLine("Kode Produk: " + KodeProduk.GetKodeProduk(elektronik));

        FanLaptop fan = new FanLaptop();
        fan.tes();
    }
}

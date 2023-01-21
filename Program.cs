using System.Diagnostics;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        int JumlahArray = 0;
        try
        {
            Console.Write("Masukan jumlah data Karyawan yang ingin dimasukan: ");
            JumlahArray = Int32.Parse(Console.ReadLine());
        }
        catch (Exception e){
            Console.WriteLine("Kesalahan Terjadi Karena : " + e.Message);
        }
        int[] Nip = new int[JumlahArray]; string[] Nama = new string[JumlahArray]; int[] KodeGolongan = new int[JumlahArray];
        int[] MenikahAtauBelum = new int[JumlahArray]; int[] JumlahAnak = new int[JumlahArray]; int[] TunjanganIstri = new int[JumlahArray]; int[] TunjanganAnak = new int[JumlahArray];
        string[] StatusPernikahan = new string[JumlahArray]; int[] GajiPokok = new int[JumlahArray]; int[] Tunjangan = new int[JumlahArray];
        int[] GajiBersih = new int[JumlahArray];
        for (int j = 0; j < JumlahArray; j++)
        {
            PrintPogram();
            try
            {
                Console.WriteLine("Masukan NIP Anda");
                Nip[j] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Masukan Nama Anda");
                Nama[j] = Console.ReadLine();
            Ulang:
                Console.WriteLine("Masukan Kode Golongan Anda [1 = 600.000/2 = 700.000/3 = 800.000]");
                KodeGolongan[j] = Int32.Parse(Console.ReadLine());
                if (KodeGolongan[j] < 4)
                {
                    GajiPokok[j] = Gaji(KodeGolongan[j]);
                }
                else
                {
                    Console.WriteLine("Maaf inputkan Hanya Menerima angka 1,2,3");
                    Console.ReadKey();
                    goto Ulang;
                }
                Console.WriteLine("Gaji Pokok Anda Sebesar: " + GajiPokok[j]);
            Ulang2:
                Console.WriteLine("Apakah anda sudah menikah? Ketik 1 kalo sudah, Kalo belum Ketik 2");
                MenikahAtauBelum[j] = Int32.Parse(Console.ReadLine());
                if (MenikahAtauBelum[j] == 2 || MenikahAtauBelum[j] == 1)
                {
                    StatusPernikahan[j] = Pernikahan(MenikahAtauBelum[j]);
                    if (StatusPernikahan[j] == "Sudah Menikah")
                    {
                        Console.WriteLine("Masukan jumlah anak anda ");
                        int Anak = Int32.Parse(Console.ReadLine());
                        JumlahAnak[j] = JumlhAnak(Anak);
                        TunjanganIstri[j] = GajiPokok[j] * 10 / 100;
                        TunjanganAnak[j] = (JumlahAnak[j] * GajiPokok[j]) * 10 / 100;
                        Tunjangan[j] = TunjanganAnak[j] + TunjanganIstri[j];
                        GajiBersih[j] = GajiPokok[j] + Tunjangan[j];
                    }
                    else
                    {
                        int Anak = 0;
                        TunjanganIstri[j] = 0;
                        TunjanganAnak[j] = 0;
                        Tunjangan[j] = 0;
                        GajiBersih[j] = GajiPokok[j] + Tunjangan[j];
                    }
                }
                else
                {
                    Console.WriteLine("Maaf data yang anda masukan tidak sesuai");
                    Console.ReadKey();
                    goto Ulang2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Kesalahan Terjadi Karena : " + e.Message);
            }
        }
        Console.Clear();
        Console.SetCursorPosition(0, 5); Console.Write("|No");
        Console.SetCursorPosition(5, 5); Console.Write("|Nip");
        Console.SetCursorPosition(14, 5); Console.Write("|Nama");
        Console.SetCursorPosition(28, 5); Console.Write("|Gaji Pokok");
        Console.SetCursorPosition(42, 5); Console.Write("|Status Pernikahan");
        Console.SetCursorPosition(64, 5); Console.Write("|TunjanganAnak");
        Console.SetCursorPosition(78, 5); Console.Write("|Tunjangan Istri");
        Console.SetCursorPosition(94, 5); Console.Write("|Tunjangan");
        Console.SetCursorPosition(106, 5); Console.Write("|Gaji Bersih");
        OutputFinal(Nip, Nama, GajiPokok, StatusPernikahan, TunjanganAnak, TunjanganIstri, Tunjangan, GajiBersih, JumlahArray);
    }
    static void PrintPogram()
    {
        Console.WriteLine("Program Menghitung Gaji Bersih Karyawan R07 Negeri Kota Ceria");
        Console.WriteLine("=============================================================");   
    }
    static int Gaji(int Kode) 
    {
        int gaji = 0 ;
        switch (Kode)
        {
            case 1:
                gaji = 600000;
                break;
            case 2:
                gaji = 700000;
                break;
            case 3:
                gaji = 800000;
                break;
        }
        return gaji;
    }
    static string Pernikahan(int Kode) {
        string NikahAtauTidak = "";
        if (Kode == 1) {
            NikahAtauTidak = "Sudah Menikah";
        } else {
            NikahAtauTidak = "Belum Menikah";
        }
        return NikahAtauTidak;
    }
    static int JumlhAnak(int Anak) {
        int anak = 0;
        if (Anak == 1) {
            anak = Anak;
        } else if (Anak >= 2){
            anak = 2;
        }
        return anak;
    }
    static void OutputFinal(int[] nip, string[] nama, int[] gajiPokok, string[] statusPernikahan, int[] tunjanganAnak, int[] tunjanganIstri, int[] tunjangan, int[] gajiBersih, int jumlahArray) {
        for (int a = 0;a<jumlahArray;a++) {
            Console.SetCursorPosition(1, 7 + a); Console.Write(a + 1);
            Console.SetCursorPosition(6, 7 + a); Console.Write(nip[a]);
            Console.SetCursorPosition(15, 7 + a); Console.Write(nama[a]);
            Console.SetCursorPosition(29, 7 + a); Console.Write(gajiPokok[a]);
            Console.SetCursorPosition(43, 7 + a); Console.Write(statusPernikahan[a]);
            Console.SetCursorPosition(65, 7 + a); Console.Write(tunjanganAnak[a]);
            Console.SetCursorPosition(79, 7 + a); Console.Write(tunjanganIstri[a]);
            Console.SetCursorPosition(95, 7 + a); Console.Write(tunjangan[a]);
            Console.SetCursorPosition(107, 7 + a); Console.Write(gajiBersih[a]);
            Console.WriteLine();
        }
    }
}

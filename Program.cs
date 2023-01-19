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
                if (MenikahAtauBelum[j] >= 2 || MenikahAtauBelum[j] <= 1)
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
        for (int a = 0; a < JumlahArray;a++) {
            OutputTotal(Nip[a], Nama[a], GajiPokok[a], StatusPernikahan[a], JumlahAnak[a], TunjanganAnak[a], TunjanganIstri[a], Tunjangan[a], GajiBersih[a]);
        }
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
    static void OutputTotal(int nip, string nama, int gajipokok, string statuspernikahan, int jumlahanak, int tunjangananak, int tunjanganistri, int tunjangan, int gajibersih)
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("=============Hasil Ouput===============");
        Console.WriteLine("=======================================");
        Console.WriteLine("dengan Nip : " + nip);
        Console.WriteLine("Atas Nama: " + nama);
        Console.WriteLine("Dengan Gaji Pokok Sebesar: "+ gajipokok);
        Console.WriteLine("Status Pernikahan: " + statuspernikahan);
        Console.WriteLine("Jumlah anak sebanyak: " + jumlahanak);
        Console.WriteLine("Tunjangan anak sebesar: " + tunjangananak);
        Console.WriteLine("Tunjangan istri sebesar: " + tunjanganistri);
        Console.WriteLine("Mendapat Tunjangan Sebesar: "+ tunjangan);
        Console.WriteLine("Gaji Bersih yang Anda dapat adalah: "+gajibersih);
    }
}
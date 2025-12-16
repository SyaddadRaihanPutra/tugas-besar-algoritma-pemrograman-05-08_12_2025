/*
    KELOMPOK 05_08
    Nama Anggota Kelompok:
    1. Syaddad Raihan Putra (102042500079)
    2. Faishal Hafizh Alfario (102042500001)
    3. Qonita Najiah (102042530016)
    4. Panji Dwi Bayu Prakoso (102042500039)
*/

using System;
using System.Collections.Generic;

class Film
{
    public string Judul_05_08 = "";
    public string Genre_05_08 = "";
    public int Tahun_05_08;
}

class Program
{
    static List<Film> films_0508 = new List<Film>
    {
        new Film { Judul_05_08 = "The Matrix", Genre_05_08 = "Sci-Fi", Tahun_05_08 = 1999 },
        new Film { Judul_05_08 = "Ada Apa Dengan Cinta", Genre_05_08 = "Drama", Tahun_05_08 = 2002 },
        new Film { Judul_05_08 = "Pengabdi Setan", Genre_05_08 = "Horror", Tahun_05_08 = 2017 },
        new Film { Judul_05_08 = "Avengers: Endgame", Genre_05_08 = "Aksi", Tahun_05_08 = 2019 },
        new Film { Judul_05_08 = "Laskar Pelangi", Genre_05_08 = "Drama", Tahun_05_08 = 2008 }
    };

    static List<string> genreFilm_0508 = new List<string>
    {
        "Aksi", "Komedi", "Drama", "Horror", "Romantis", "Sci-Fi", "Dokumenter"
    };

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
                Console.WriteLine("======================================="); // Tampilkan menu pilihan_05_08 
                Console.WriteLine("|| PILIH MENU                        ||");
                Console.WriteLine("|| 1. Tambah Film                    ||");
                Console.WriteLine("|| 2. Lihat Data Film                ||");
                Console.WriteLine("|| 3. Update Data Film               ||");
                Console.WriteLine("|| 4. Hapus Data Film                ||");
                Console.WriteLine("|| 5. Cari Film (judul)              ||");
                Console.WriteLine("|| 6. Filter berdasarkan Genre       ||");
                Console.WriteLine("|| 0. Keluar                         ||");
                Console.WriteLine("=======================================");
                Console.Write("Ketik Nomor Menu (1/2/3/4/5/6/0): ");

                int pilihan_05_08 = int.Parse(Console.ReadLine()!);

                switch (pilihan_05_08)
                {
                    case 1:
                        TambahFilm();
                        break;
                    case 2:
                        LihatFilm();
                        break;
                    case 3:
                        UpdateFilm();
                        break;
                    case 4:
                        HapusFilm();
                        break;
                    case 5:
                        CariFilm();
                        break;
                    case 6:
                        FilterGenre();
                        break;
                    case 0:
                        Console.WriteLine("Terima kasih.");
                        return;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }

            Console.WriteLine("\nTekan Enter...");
            Console.ReadLine();
        }
    }

    static void TambahFilm()
    {
        try
        {
            string judul_05_08;
            while (true)
            {
                Console.Write("Judul: ");
                judul_05_08 = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(judul_05_08))
                {
                    Console.WriteLine("Judul tidak boleh kosong.");
                    continue;
                }
                // Hilangkan spasi di awal/akhir dan spasi berlebih di tengah (tanpa regex, mudah dibaca)
                judul_05_08 = judul_05_08.Trim();
                while (judul_05_08.Contains("  "))
                {
                    judul_05_08 = judul_05_08.Replace("  ", " ");
                }
                if (judul_05_08.Length == 0)
                {
                    Console.WriteLine("Judul tidak boleh kosong.");
                    continue;
                }
                break;
            }

            int genreIndex_05_08 = -1;
            while (true)
            {
                Console.WriteLine("Pilih Genre:");
                for (int i = 0; i < genreFilm_0508.Count; i++)
                    Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");

                Console.Write("Masukkan nomor genre: ");
                string inputGenre_05_08 = Console.ReadLine()!;
                if (int.TryParse(inputGenre_05_08, out genreIndex_05_08) &&
                    genreIndex_05_08 > 0 &&
                    genreIndex_05_08 <= genreFilm_0508.Count)
                {
                    genreIndex_05_08 -= 1;
                    break;
                }
                Console.WriteLine("Input genre tidak valid.");
            }

            int tahun_05_08;
            while (true)
            {
                Console.Write("Tahun: ");
                string inputTahun_05_08 = Console.ReadLine()!;
                if (int.TryParse(inputTahun_05_08, out tahun_05_08) && tahun_05_08 > 1800 && tahun_05_08 <= DateTime.Now.Year)
                    break;
                Console.WriteLine("Tahun tidak valid.");
            }

            Film filmBaru = new Film
            {
                Judul_05_08 = judul_05_08,
                Genre_05_08 = genreFilm_0508[genreIndex_05_08],
                Tahun_05_08 = tahun_05_08
            };

            films_0508.Add(filmBaru);
            Console.WriteLine("Film berhasil ditambahkan.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat menambah film: {ex.Message}");
        }
    }

    static void LihatFilm()
    {
        try
        {
            Console.WriteLine("\nDAFTAR FILM:");
            Console.WriteLine("+======================================================================+");
            Console.WriteLine($"|| {"No",-3} || {"Judul",-30} || {"Genre",-15} || {"Tahun",-5} ||");
            Console.WriteLine("+======================================================================+");
            for (int i = 0; i < films_0508.Count; i++)
            {
                Console.WriteLine($"|| {(i + 1) + ".",-3} || {films_0508[i].Judul_05_08,-30} || {films_0508[i].Genre_05_08,-15} || {films_0508[i].Tahun_05_08,-5} ||");
            }
            Console.WriteLine("+======================================================================+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat menampilkan daftar film: {ex.Message}");
        }
    }

    static void UpdateFilm()
    {
        try
        {
            LihatFilm();
            Console.Write("Pilih nomor film: ");
            string inputIndex_05_08 = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(inputIndex_05_08))
            {
                Console.WriteLine("Tidak ada perubahan.");
                return;
            }
            int index_05_08 = int.Parse(inputIndex_05_08) - 1;
            if (index_05_08 < 0 || index_05_08 >= films_0508.Count)
            {
                Console.WriteLine("Nomor film tidak valid.");
                return;
            }

            // Judul baru
            Console.Write($"Judul baru (Enter untuk tidak mengubah, sekarang: {films_0508[index_05_08].Judul_05_08}): ");
            string judulBaru_05_08 = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(judulBaru_05_08))
            {
                // Hilangkan spasi di awal/akhir dan spasi berlebih di tengah (tanpa regex, mudah dibaca)
                judulBaru_05_08 = judulBaru_05_08.Trim();
                while (judulBaru_05_08.Contains("  "))
                {
                    judulBaru_05_08 = judulBaru_05_08.Replace("  ", " ");
                }
                if (judulBaru_05_08.Length == 0)
                {
                    Console.WriteLine("Judul tidak boleh kosong. Judul tidak diubah.");
                }
                else
                {
                    films_0508[index_05_08].Judul_05_08 = judulBaru_05_08;
                }
            }

            // Genre baru
            Console.WriteLine("Pilih Genre baru (Enter untuk tidak mengubah):");
            for (int i = 0; i < genreFilm_0508.Count; i++)
                Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");
            Console.Write($"Masukkan nomor genre (sekarang: {films_0508[index_05_08].Genre_05_08}): ");
            string inputGenre = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(inputGenre))
            {
                int genreIndexBaru_05_08;
                if (int.TryParse(inputGenre, out genreIndexBaru_05_08) &&
                    genreIndexBaru_05_08 > 0 &&
                    genreIndexBaru_05_08 <= genreFilm_0508.Count)
                {
                    films_0508[index_05_08].Genre_05_08 = genreFilm_0508[genreIndexBaru_05_08 - 1];
                }
                else
                {
                    Console.WriteLine("Input genre tidak valid. Genre tidak diubah.");
                }
            }

            // Tahun baru
            Console.Write($"Tahun baru (Enter untuk tidak mengubah, sekarang: {films_0508[index_05_08].Tahun_05_08}): ");
            string inputTahun_05_08 = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(inputTahun_05_08))
            {
                int tahunBaru;
                if (int.TryParse(inputTahun_05_08, out tahunBaru) && tahunBaru > 1800 && tahunBaru <= DateTime.Now.Year)
                {
                    films_0508[index_05_08].Tahun_05_08 = tahunBaru;
                }
                else
                {
                    Console.WriteLine("Tahun tidak valid. Tahun tidak diubah.");
                }
            }

            Console.WriteLine("Data film berhasil diupdate.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat mengupdate data film: {ex.Message}");
        }
    }

    static void HapusFilm()
    {
        try
        {
            LihatFilm();
            Console.Write("Pilih nomor film: ");
            int index_05_08 = int.Parse(Console.ReadLine()!) - 1;
            if (index_05_08 < 0 || index_05_08 >= films_0508.Count)
            {
                Console.WriteLine("Nomor film tidak valid.");
                return;
            }

            // Konfirmasi penghapusan
            Console.Write($"Apakah yakin ingin menghapus film '{films_0508[index_05_08].Judul_05_08}'? (y/n): ");
            string konfirmasi = Console.ReadLine()!.ToLower();
            if (konfirmasi != "y")
            {
                Console.WriteLine("Film batal dihapus.");
                return;
            }

            films_0508.RemoveAt(index_05_08);
            Console.WriteLine("Film berhasil dihapus.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat menghapus film: {ex.Message}");
        }
    }

    static void CariFilm()
    {
        try
        {
            Console.Write("Cari judul: ");
            string katakunci_05_08 = Console.ReadLine()!.ToLower();

            bool ditemukan = false;
            Console.WriteLine("\nDAFTAR FILM:");
            Console.WriteLine("+======================================================================+");
            Console.WriteLine($"|| {"No",-3} || {"Judul",-30} || {"Genre",-15} || {"Tahun",-5} ||");
            Console.WriteLine("+======================================================================+");
            for (int i = 0; i < films_0508.Count; i++)
            {
                Film f = films_0508[i];
                if (f.Judul_05_08.ToLower().Contains(katakunci_05_08))
                {
                    Console.WriteLine($"|| {(i + 1) + ".",-3} || {f.Judul_05_08,-30} || {f.Genre_05_08,-15} || {f.Tahun_05_08,-5} ||");
                    ditemukan = true;
                }
            }
            if (!ditemukan)
            {
                Console.WriteLine("|| Film tidak ditemukan.");
            }
            Console.WriteLine("+======================================================================+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat mencari film: {ex.Message}");
        }
    }

    static void FilterGenre()
    {
        try
        {
            Console.WriteLine("\nPilih Genre:");
            for (int i = 0; i < genreFilm_0508.Count; i++)
                Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");

            Console.Write("Masukkan nomor genre: ");
            int index_05_08 = int.Parse(Console.ReadLine()!) - 1;
            string genre_05_08 = genreFilm_0508[index_05_08];

            bool ditemukan = false;
            Console.WriteLine("\nFILTER FILM BERDASARKAN GENRE:");
            Console.WriteLine("+======================================================================+");
            Console.WriteLine($"|| {"No",-3} || {"Judul",-30} || {"Genre",-15} || {"Tahun",-5} ||");
            Console.WriteLine("+======================================================================+");
            for (int i = 0; i < films_0508.Count; i++)
            {
                Film f = films_0508[i];
                if (f.Genre_05_08 == genre_05_08)
                {
                    Console.WriteLine($"|| {(i + 1) + ".",-3} || {f.Judul_05_08,-30} || {f.Genre_05_08,-15} || {f.Tahun_05_08,-5} ||");
                    ditemukan = true;
                }
            }
            if (!ditemukan)
            {
                Console.WriteLine("Tidak ada film dengan genre tersebut.");
            }
            Console.WriteLine("+======================================================================+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi kesalahan saat memfilter genre: {ex.Message}");
        }
    }
}

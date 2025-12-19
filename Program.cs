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
    public string Judul_0508 = "";
    public string Genre_0508 = "";
    public int Tahun_0508;
}

class Program
{
    static List<Film> films_0508 = new List<Film>
    {
        new Film { Judul_0508 = "Siksa Kubur", Genre_0508 = "Horror", Tahun_0508 = 2025 },
        new Film { Judul_0508 = "Ada Apa Dengan Cinta", Genre_0508 = "Drama", Tahun_0508 = 2002 },
        new Film { Judul_0508 = "Pengabdi Setan", Genre_0508 = "Horror", Tahun_0508 = 2017 },
        new Film { Judul_0508 = "Avengers: Endgame", Genre_0508 = "Aksi", Tahun_0508 = 2019 },
        new Film { Judul_0508 = "Laskar Pelangi", Genre_0508 = "Drama", Tahun_0508 = 2008 },
        new Film { Judul_0508 = "G30S/PKI", Genre_0508 = "Dokumenter", Tahun_0508 = 1984 },
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
                Console.WriteLine("======================================="); // Tampilkan menu pilihan_0508 
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

                int pilihan_0508 = int.Parse(Console.ReadLine()!);

                switch (pilihan_0508)
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
            string judul_0508;
            while (true)
            {
                Console.Write("\nMasukkan Judul: ");
                judul_0508 = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(judul_0508) || judul_0508.Length == 0)
                {
                    Console.WriteLine("Judul tidak boleh kosong.");
                    continue;
                }
                if (judul_0508.Length > 30)
                {
                    Console.WriteLine("Judul terlalu panjang (maksimal 30 karakter).");
                    continue;
                }
                // Hilangkan spasi di awal/akhir dan spasi berlebih di tengah (tanpa regex, mudah dibaca)
                judul_0508 = judul_0508.Trim();
                while (judul_0508.Contains("  "))
                {
                    judul_0508 = judul_0508.Replace("  ", " ");
                }
                break;
            }

            int genreIndex_0508 = -1;

            // tampilkan list genre SATU KALI
            Console.WriteLine("\nDAFTAR GENRE:");
            Console.WriteLine("+==========================+");
            Console.WriteLine($"|| {"No",-3} || {"Genre",-15} ||");
            Console.WriteLine("+==========================+");
            for (int i = 0; i < genreFilm_0508.Count; i++)
            {
                Console.WriteLine($"|| {(i + 1) + ".",-3} || {genreFilm_0508[i],-15} ||");
            }
            Console.WriteLine("+==========================+");

            // loop khusus validasi input
            while (true)
            {
                Console.Write("Masukkan nomor genre: ");
                string inputGenre_0508 = Console.ReadLine()!;

                if (int.TryParse(inputGenre_0508, out genreIndex_0508) &&
                    genreIndex_0508 > 0 &&
                    genreIndex_0508 <= genreFilm_0508.Count)
                {
                    genreIndex_0508 -= 1; // konversi ke index list
                    break;
                }

                Console.WriteLine("Input genre tidak valid. Silakan masukkan ulang.");
            }


            int tahun_0508;
            while (true)
            {
                Console.Write("Masukkan Tahun: ");
                string inputTahun_0508 = Console.ReadLine()!;
                if (int.TryParse(inputTahun_0508, out tahun_0508) && tahun_0508 > 1800 && tahun_0508 <= DateTime.Now.Year)
                    break;
                Console.WriteLine("Tahun tidak valid.");
            }

            Film filmBaru = new Film
            {
                Judul_0508 = judul_0508,
                Genre_0508 = genreFilm_0508[genreIndex_0508],
                Tahun_0508 = tahun_0508
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
                Console.WriteLine($"|| {(i + 1) + ".",-3} || {films_0508[i].Judul_0508,-30} || {films_0508[i].Genre_0508,-15} || {films_0508[i].Tahun_0508,-5} ||");
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
            string inputIndex_0508 = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(inputIndex_0508))
            {
                Console.WriteLine("Tidak ada perubahan.");
                return;
            }
            int index_0508 = int.Parse(inputIndex_0508) - 1;
            if (index_0508 < 0 || index_0508 >= films_0508.Count)
            {
                Console.WriteLine("Nomor film tidak valid.");
                return;
            }

            // Judul baru
            Console.Write($"Judul baru (Enter untuk tidak mengubah, sekarang: {films_0508[index_0508].Judul_0508}): ");
            string judulBaru_0508 = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(judulBaru_0508))
            {
                // Hilangkan spasi di awal/akhir dan spasi berlebih di tengah (tanpa regex, mudah dibaca)
                judulBaru_0508 = judulBaru_0508.Trim();
                while (judulBaru_0508.Contains("  "))
                {
                    judulBaru_0508 = judulBaru_0508.Replace("  ", " ");
                }
                if (judulBaru_0508.Length == 0)
                {
                    Console.WriteLine("Judul tidak boleh kosong. Judul tidak diubah.");
                }
                else if (judulBaru_0508.Length > 30)
                {
                    Console.WriteLine("Judul terlalu panjang (maksimal 30 karakter). Judul tidak diubah.");
                }
                else
                {
                    films_0508[index_0508].Judul_0508 = judulBaru_0508;
                }
            }

            // Genre baru
            Console.WriteLine("Pilih Genre baru (Enter untuk tidak mengubah):");
            for (int i = 0; i < genreFilm_0508.Count; i++)
                Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");
            Console.Write($"Masukkan nomor genre (sekarang: {films_0508[index_0508].Genre_0508}): ");
            string inputGenre_0508 = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(inputGenre_0508))
            {
                int genreIndexBaru_0508;
                if (int.TryParse(inputGenre_0508, out genreIndexBaru_0508) &&
                    genreIndexBaru_0508 > 0 &&
                    genreIndexBaru_0508 <= genreFilm_0508.Count)
                {
                    films_0508[index_0508].Genre_0508 = genreFilm_0508[genreIndexBaru_0508 - 1];
                }
                else
                {
                    Console.WriteLine("Input genre tidak valid. Genre tidak diubah.");
                }
            }

            // Tahun baru
            Console.Write($"Tahun baru (Enter untuk tidak mengubah, sekarang: {films_0508[index_0508].Tahun_0508}): ");
            string inputTahun_0508 = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(inputTahun_0508))
            {
                int tahunBaru_0508;
                if (int.TryParse(inputTahun_0508, out tahunBaru_0508) && tahunBaru_0508 > 1800 && tahunBaru_0508 <= DateTime.Now.Year)
                {
                    films_0508[index_0508].Tahun_0508 = tahunBaru_0508;
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
            int index_0508 = int.Parse(Console.ReadLine()!) - 1;
            if (index_0508 < 0 || index_0508 >= films_0508.Count)
            {
                Console.WriteLine("Nomor film tidak valid.");
                return;
            }

            // Konfirmasi penghapusan
            Console.Write($"Apakah yakin ingin menghapus film '{films_0508[index_0508].Judul_0508}'? (y/n): ");
            string konfirmasi_0508 = Console.ReadLine()!.ToLower();
            if (konfirmasi_0508 != "y")
            {
                Console.WriteLine("Film batal dihapus.");
                return;
            }

            films_0508.RemoveAt(index_0508);
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
            string katakunci_0508 = Console.ReadLine()!.ToLower();

            bool ditemukan_0508 = false;
            Console.WriteLine("\nDAFTAR FILM:");
            Console.WriteLine("+======================================================================+");
            Console.WriteLine($"|| {"No",-3} || {"Judul",-30} || {"Genre",-15} || {"Tahun",-5} ||");
            Console.WriteLine("+======================================================================+");
            for (int i = 0; i < films_0508.Count; i++)
            {
                Film f = films_0508[i];
                if (f.Judul_0508.ToLower().Contains(katakunci_0508))
                {
                    Console.WriteLine($"|| {(i + 1) + ".",-3} || {f.Judul_0508,-30} || {f.Genre_0508,-15} || {f.Tahun_0508,-5} ||");
                    ditemukan_0508 = true;
                }
            }
            if (!ditemukan_0508)
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
            int index_0508 = int.Parse(Console.ReadLine()!) - 1;
            string genre_0508 = genreFilm_0508[index_0508];

            bool ditemukan_0508 = false;
            Console.WriteLine("\nFILTER FILM BERDASARKAN GENRE:");
            Console.WriteLine("+======================================================================+");
            Console.WriteLine($"|| {"No",-3} || {"Judul",-30} || {"Genre",-15} || {"Tahun",-5} ||");
            Console.WriteLine("+======================================================================+");
            for (int i = 0; i < films_0508.Count; i++)
            {
                Film f = films_0508[i];
                if (f.Genre_0508 == genre_0508)
                {
                    Console.WriteLine($"|| {(i + 1) + ".",-3} || {f.Judul_0508,-30} || {f.Genre_0508,-15} || {f.Tahun_0508,-5} ||");
                    ditemukan_0508 = true;
                }
            }
            if (!ditemukan_0508)
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

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

class Program
{
    // Koleksi film sebagai List statis yang menyimpan data film
    static List<string> films_0508 = new List<string>();

    // Daftar genre film yang tersedia untuk dipilih pengguna
    static List<string> genreFilm_0508 = new List<string>
    {
        "Aksi", "Komedi", "Drama", "Horror", "Romantis", "Sci-Fi", "Dokumenter"
    };

    static void Main(string[] args)
    {
        try
        {
            // Loop utama yang terus berjalan sampai pengguna memilih keluar
            while (true)
            {
                Console.Clear(); // Bersihkan layar konsol
                // Tampilkan header aplikasi
                Console.WriteLine("=======================================");
                Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
                Console.WriteLine("=======================================");
                // Tampilkan menu pilihan
                Console.WriteLine("||   PILIH MENU                      ||");
                Console.WriteLine("||   1. Tambah Film                  ||");
                Console.WriteLine("||   2. Lihat Data Film              ||");
                Console.WriteLine("||   3. Update Data Film             ||");
                Console.WriteLine("||   4. Hapus Data Film              ||");
                Console.WriteLine("||   5. Cari Film (judul)            ||");
                Console.WriteLine("||   6. Filter berdasarkan Genre     ||");
                Console.WriteLine("||   0. Keluar                       ||");
                Console.WriteLine("=======================================");
                Console.Write("Ketik Nomor Menu (1/2/3/4/5/6/0): ");

                // Baca input pilihan menu dari pengguna dan konversi ke integer
                int pilihan_0508 = int.Parse(Console.ReadLine()!);

                // Cek pilihan pengguna dan jalankan fungsi yang sesuai
                if (pilihan_0508 == 1)
                    TambahFilm(); // Jalankan fungsi menambah film
                else if (pilihan_0508 == 2)
                    LihatDataFilm(); // Jalankan fungsi melihat daftar film
                else if (pilihan_0508 == 3)
                    UpdateFilm(); // Jalankan fungsi mengubah data film
                else if (pilihan_0508 == 4)
                    HapusFilm(); // Jalankan fungsi menghapus film
                else if (pilihan_0508 == 5)
                    CariFilm(); // Jalankan fungsi mencari film
                else if (pilihan_0508 == 6)
                    FilterGenre(); // Jalankan fungsi filter berdasarkan genre
                else if (pilihan_0508 == 0)
                {
                    Console.WriteLine("Keluar... Terima kasih.");
                    break; // Keluar dari loop utama dan akhiri program
                }
                else
                    // Tampilkan pesan jika pilihan tidak valid
                    Console.WriteLine("Pilihan_0508 tidak valid.");
                // Beri waktu untuk melihat hasil sebelum kembali ke menu
                Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
                Console.ReadLine();
            }
        }
        catch (Exception)
        {
            // Tangkap semua error yang terjadi dan tampilkan pesan error
            Console.WriteLine("Terjadi kesalahan dalam aplikasi.");
        }
    }

    static void TambahFilm()
    {
        Console.Clear(); // Bersihkan layar
        // Tampilkan header bagian tambah film
        Console.WriteLine("=======================================");
        Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
        Console.WriteLine("=======================================");
        Console.WriteLine("==|     (TAMBAH ENTRI FILM BARU)    |==");
        Console.WriteLine("=======================================");

        // ===== INPUT JUDUL FILM =====
        Console.WriteLine("\n=====================================");
        Console.Write("Masukkan Judul Film: ");
        // Baca judul film dari pengguna
        string judulFilm_0508 = Console.ReadLine()!;

        // Validasi: pastikan judul tidak kosong dan tidak ada spasi berlebih
        while (string.IsNullOrWhiteSpace(judulFilm_0508) || judulFilm_0508 != judulFilm_0508.Trim() || judulFilm_0508.Contains("  "))
        {
            Console.WriteLine("Judul film tidak valid. Gunakan format yang benar (contoh: 'Lorem Ipsum').");
            Console.Write("Masukkan Judul Film: ");
            judulFilm_0508 = Console.ReadLine()!;
        }

        Console.WriteLine("=====================================");

        // ===== INPUT GENRE FILM =====
        Console.WriteLine("\n=== Pilih Genre ===");
        // Tampilkan daftar genre yang tersedia dengan nomor
        for (int i = 0; i < genreFilm_0508.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");
        }

        Console.Write("Ketik Nomor Genre: ");
        // Baca input nomor genre dari pengguna
        string genreInput_0508 = Console.ReadLine()!;
        int nomorGenre_0508 = -1; // Inisialisasi dengan nilai -1 (invalid)
        string genre_0508 = ""; // Variabel untuk menyimpan genre yang dipilih

        // Validasi input genre berulang sampai valid
        while (nomorGenre_0508 < 1 || nomorGenre_0508 > genreFilm_0508.Count)
        {
            try
            {
                // Coba konversi input menjadi integer
                nomorGenre_0508 = int.Parse(genreInput_0508);
                // Cek apakah nomor genre valid (antara 1 dan jumlah genre)
                if (nomorGenre_0508 >= 1 && nomorGenre_0508 <= genreFilm_0508.Count)
                {
                    // Ambil genre dari list berdasarkan nomor (dikurangi 1 karena index mulai dari 0)
                    genre_0508 = genreFilm_0508[nomorGenre_0508 - 1];
                    break; // Keluar dari loop jika valid
                }
                else
                {
                    // Tampilkan error jika nomor di luar range
                    Console.WriteLine("Pilihan genre tidak valid. Silakan pilih nomor genre yang benar.");
                    Console.Write("Ketik Nomor Genre: ");
                    genreInput_0508 = Console.ReadLine()!;
                }
            }
            catch (FormatException)
            {
                // Tangkap error jika input bukan angka
                Console.WriteLine("Pilihan genre tidak valid. Silakan pilih nomor genre yang benar.");
                Console.Write("Ketik Nomor Genre: ");
                genreInput_0508 = Console.ReadLine()!;
            }
        }

        Console.WriteLine("=====================================");

        // ===== INPUT TAHUN RILIS =====
        Console.WriteLine("\n=== Masukkan Tahun Rilis ===");
        Console.Write("Masukkan Tahun Rilis: ");
        // Baca input tahun rilis dari pengguna
        string tahunInput_0508 = Console.ReadLine()!;
        int tahunRilis_0508 = 0; // Variabel untuk menyimpan tahun rilis

        // Validasi input tahun berulang sampai valid
        while (true)
        {
            try
            {
                // Coba konversi input menjadi integer
                tahunRilis_0508 = int.Parse(tahunInput_0508);
                // Cek apakah tahun valid: lebih besar dari 1800 dan tidak melebihi tahun sekarang
                if (tahunRilis_0508 > 1800 && tahunRilis_0508 <= DateTime.Now.Year)
                {
                    break; // Keluar dari loop jika valid
                }
                else
                {
                    // Tampilkan error jika tahun di luar range
                    Console.WriteLine("Tahun rilis tidak valid. Masukkan tahun yang benar (misalnya: 1999).");
                    Console.Write("Masukkan Tahun Rilis: ");
                    tahunInput_0508 = Console.ReadLine()!;
                }
            }
            catch (FormatException)
            {
                // Tangkap error jika input bukan angka
                Console.WriteLine("Tahun rilis tidak valid. Masukkan tahun yang benar (misalnya: 1999).");
                Console.Write("Masukkan Tahun Rilis: ");
                tahunInput_0508 = Console.ReadLine()!;
            }
        }

        Console.WriteLine("=====================================");

        // ===== TAMBAHKAN FILM KE KOLEKSI =====
        // Buat string dengan format: "Judul: ..., Genre: ..., Tahun: ..."
        string filmBaru_0508 = $"Judul: {judulFilm_0508}, Genre: {genre_0508}, Tahun: {tahunRilis_0508}";
        // Tambahkan film baru ke list films_0508
        films_0508.Add(filmBaru_0508);
        // Tampilkan pesan sukses
        Console.WriteLine($"Film '{judulFilm_0508}' ({genre_0508}, {tahunRilis_0508}) berhasil ditambahkan.");
        Console.WriteLine("=====================================");
    }

    static void LihatDataFilm()
    {
        Console.Clear(); // Bersihkan layar
        // Tampilkan header bagian lihat data film
        Console.WriteLine("=======================================");
        Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
        Console.WriteLine("=======================================");
        Console.WriteLine("==|          (DAFTAR FILM)          |==");
        Console.WriteLine("=======================================");

        // Cek apakah list film kosong
        if (films_0508.Count == 0)
        {
            Console.WriteLine("Belum ada film.");
            return; // Keluar dari fungsi jika tidak ada film
        }

        // Inisialisasi nomor urut untuk ditampilkan
        int nomor_0508 = 1;
        // Loop untuk menampilkan setiap film di list
        foreach (string film_0508 in films_0508)
        {
            // Tampilkan film dengan nomor urut, lalu increment nomor
            Console.WriteLine($"{nomor_0508++}. {film_0508}");
        }
    }

    static void UpdateFilm()
    {
        Console.Clear(); // Bersihkan layar
                         // Tampilkan header bagian update film
        Console.WriteLine("=======================================");
        Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
        Console.WriteLine("=======================================");
        Console.WriteLine("==|       (UPDATE ENTRI FILM)       |==");
        Console.WriteLine("=======================================");

        // Cek apakah list film kosong
        if (films_0508.Count == 0)
        {
            Console.WriteLine("Belum ada film.");
            return; // Keluar dari fungsi jika tidak ada film
        }

        // Tampilkan daftar film menggunakan fungsi LihatDataFilm
        LihatDataFilm();

        // Minta pengguna memilih nomor film yang akan diupdate
        Console.Write("Pilih nomor film yang akan diupdate: ");
        string inputNomorFilm_0508 = Console.ReadLine()!;
        int nomorFilm_0508 = -1; // Inisialisasi dengan nilai -1 (invalid)

        // Validasi input nomor film berulang sampai valid
        while (nomorFilm_0508 < 1 || nomorFilm_0508 > films_0508.Count)
        {
            try
            {
                // Coba konversi input menjadi integer
                nomorFilm_0508 = int.Parse(inputNomorFilm_0508);
                // Cek apakah nomor film valid
                if (nomorFilm_0508 < 1 || nomorFilm_0508 > films_0508.Count)
                {
                    // Tampilkan error jika nomor tidak valid
                    Console.WriteLine("Nomor film tidak valid. Pilih nomor yang sesuai.");
                    Console.Write("Pilih nomor film yang akan diupdate: ");
                    inputNomorFilm_0508 = Console.ReadLine()!;
                }
            }
            catch (Exception)
            {
                // Tangkap error jika input bukan angka
                Console.WriteLine("Input tidak valid. Masukkan angka yang benar.");
                Console.Write("Pilih nomor film yang akan diupdate: ");
                inputNomorFilm_0508 = Console.ReadLine()!;
            }
        }

        // Ambil film yang dipilih dari list (kurangi 1 karena index mulai dari 0)
        string filmYangDipilih_0508 = films_0508[nomorFilm_0508 - 1];
        Console.WriteLine($"Film yang dipilih: {filmYangDipilih_0508}");

        // Helper: parse film string menjadi bagian yang sudah di-trim dan aman
        string[] ParseAndNormalize(string film)
        {
            // Pisahkan berdasarkan koma lalu trim setiap bagian
            string[] parts = film.Split(',');
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
            }
            // Pastikan ada minimal 3 bagian: Judul, Genre, Tahun
            if (parts.Length < 3)
            {
                Array.Resize(ref parts, 3);
                for (int i = 0; i < parts.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(parts[i]))
                    {
                        if (i == 0) parts[i] = "Judul: ";
                        else if (i == 1) parts[i] = "Genre: ";
                        else parts[i] = "Tahun: ";
                    }
                }
            }
            return parts;
        }

        // Ambil bagian film yang sudah dinormalisasi
        string[] bagianFilmSaatIni = ParseAndNormalize(filmYangDipilih_0508);

        // ===== UPDATE JUDUL =====
        Console.Write("Masukkan Judul Baru (kosongkan untuk tidak mengubah): ");
        string judulBaru_0508 = Console.ReadLine()!;

        // Jika input tidak kosong dan tidak hanya spasi, lakukan validasi judul
        if (!string.IsNullOrWhiteSpace(judulBaru_0508))
        {
            // Validasi judul dengan while loop
            while (!string.IsNullOrWhiteSpace(judulBaru_0508) &&
                   (judulBaru_0508 != judulBaru_0508.Trim() ||
                    judulBaru_0508.Contains("  ")))
            {
                Console.WriteLine("Judul film tidak valid. Gunakan format yang benar (contoh: 'Lorem Ipsum').");
                Console.Write("Masukkan Judul Film (kosongkan untuk tidak mengubah): ");
                judulBaru_0508 = Console.ReadLine()!;

                // Jika user langsung enter (kosong), keluar dari loop → tidak mengubah judul
                if (string.IsNullOrWhiteSpace(judulBaru_0508))
                {
                    break;
                }
            }

            // Jika input valid (tidak kosong dan lolos validasi), update judul
            if (!string.IsNullOrWhiteSpace(judulBaru_0508))
            {
                // Ganti bagian judul dengan judul baru (tanpa spasi ekstra)
                bagianFilmSaatIni[0] = $"Judul: {judulBaru_0508.Trim()}";
            }
        }

        // ===== UPDATE GENRE =====
        Console.WriteLine("\n=== Pilih Genre Baru ===");
        // Tampilkan daftar genre yang tersedia dengan nomor
        for (int i = 0; i < genreFilm_0508.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");
        }
        Console.WriteLine("0. Tidak mengubah genre");

        Console.Write("Ketik Nomor Genre (0 untuk tidak mengubah): ");
        string genreInput_0508 = Console.ReadLine()!;
        int nomorGenre_0508 = -1;

        // Validasi input genre berulang sampai valid
        while (true)
        {
            try
            {
                nomorGenre_0508 = int.Parse(genreInput_0508);
                // Jika 0, tidak mengubah genre
                if (nomorGenre_0508 == 0)
                {
                    break;
                }
                // Cek apakah nomor genre valid (antara 1 dan jumlah genre)
                if (nomorGenre_0508 >= 1 && nomorGenre_0508 <= genreFilm_0508.Count)
                {
                    // Ambil genre dari list berdasarkan nomor dan trim untuk keamanan
                    string genreBaru_0508 = genreFilm_0508[nomorGenre_0508 - 1].Trim();
                    // Ganti bagian genre dengan genre baru (tanpa spasi ekstra)
                    bagianFilmSaatIni[1] = $"Genre: {genreBaru_0508}";
                    break;
                }
                else
                {
                    // Tampilkan error jika nomor di luar range
                    Console.WriteLine("Pilihan genre tidak valid. Silakan pilih nomor genre yang benar.");
                    Console.Write("Ketik Nomor Genre (0 untuk tidak mengubah): ");
                    genreInput_0508 = Console.ReadLine()!;
                }
            }
            catch (FormatException)
            {
                // Tangkap error jika input bukan angka
                Console.WriteLine("Pilihan genre tidak valid. Silakan pilih nomor genre yang benar.");
                Console.Write("Ketik Nomor Genre (0 untuk tidak mengubah): ");
                genreInput_0508 = Console.ReadLine()!;
            }
        }

        // ===== UPDATE TAHUN RILIS =====
        Console.Write("Masukkan Tahun Rilis Baru (kosongkan untuk tidak mengubah): ");
        string tahunRilisInput_0508 = Console.ReadLine()!;

        // Jika input tidak kosong dan tidak hanya spasi, update tahun
        if (!string.IsNullOrWhiteSpace(tahunRilisInput_0508))
        {
            int tahunRilis_0508;
            bool tahunValid = false;

            // Validasi tahun dengan while loop
            while (!tahunValid)
            {
                try
                {
                    // Coba konversi input menjadi integer
                    tahunRilis_0508 = int.Parse(tahunRilisInput_0508);
                    // Validasi tahun
                    if (tahunRilis_0508 > 1800 && tahunRilis_0508 <= DateTime.Now.Year)
                    {
                        // Ganti bagian tahun dengan tahun baru (tanpa spasi ekstra)
                        bagianFilmSaatIni[2] = $"Tahun: {tahunRilis_0508}";
                        tahunValid = true;
                    }
                    else
                    {
                        // Tampilkan error jika tahun tidak valid
                        Console.WriteLine("Tahun rilis tidak valid. Masukkan tahun yang benar (misalnya: 1999).");
                        Console.Write("Masukkan Tahun Rilis Baru (kosongkan untuk tidak mengubah): ");
                        tahunRilisInput_0508 = Console.ReadLine()!;
                        // Jika user langsung enter → keluar tanpa mengubah
                        if (string.IsNullOrWhiteSpace(tahunRilisInput_0508))
                        {
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    // Tampilkan error jika tahun tidak valid
                    Console.WriteLine("Tahun rilis tidak valid. Masukkan tahun yang benar (misalnya: 1999).");
                    Console.Write("Masukkan Tahun Rilis Baru (kosongkan untuk tidak mengubah): ");
                    tahunRilisInput_0508 = Console.ReadLine()!;
                    // Jika user langsung enter → keluar tanpa mengubah
                    if (string.IsNullOrWhiteSpace(tahunRilisInput_0508))
                    {
                        break;
                    }
                }
            }
        }

        // ===== SIMPAN PERUBAHAN =====
        // Gabungkan kembali string yang sudah dipisah dan di-trim dengan format konsisten
        filmYangDipilih_0508 = $"{bagianFilmSaatIni[0].Trim()}, {bagianFilmSaatIni[1].Trim()}, {bagianFilmSaatIni[2].Trim()}";

        // Update film di list dengan data yang sudah dimodifikasi
        films_0508[nomorFilm_0508 - 1] = filmYangDipilih_0508;
        Console.WriteLine("Data film berhasil diupdate.");
    }

    static void HapusFilm()
    {
        Console.Clear(); // Bersihkan layar
        // Tampilkan header bagian hapus film
        Console.WriteLine("=======================================");
        Console.WriteLine("==| APLIKASI MANAJEMEN KOLEKSI FILM |==");
        Console.WriteLine("=======================================");
        Console.WriteLine("==|          (HAPUS FILM)           |==");
        Console.WriteLine("=======================================");

        // Cek apakah list film kosong
        if (films_0508.Count == 0)
        {
            Console.WriteLine("Belum ada film.");
            return; // Keluar dari fungsi jika tidak ada film
        }

        // Tampilkan daftar film menggunakan fungsi LihatDataFilm
        LihatDataFilm();

        // Minta pengguna memilih nomor film yang akan dihapus
        Console.Write("Pilih nomor film yang akan dihapus: ");
        // Gunakan TryParse untuk konversi yang lebih aman (menghindari exception)
        // Jika konversi gagal atau nomor tidak valid, tampilkan error dan keluar
        if (!int.TryParse(Console.ReadLine()!, out int nomor_0508Film) || nomor_0508Film < 1 || nomor_0508Film > films_0508.Count)
        {
            Console.WriteLine("Pilihan_0508 tidak valid.");
            return;
        }

        // ===== HAPUS FILM =====
        // Ambil film yang akan dihapus sebelum dihapus (untuk ditampilkan di pesan)
        string filmYangDihapus = films_0508[nomor_0508Film - 1];
        // Hapus film dari list berdasarkan index (kurangi 1 karena index mulai dari 0)
        films_0508.RemoveAt(nomor_0508Film - 1);

        // Tampilkan pesan sukses
        Console.WriteLine($"Film '{filmYangDihapus}' berhasil dihapus.");
    }

    static void CariFilm()
    {
        Console.Write("\nMasukkan kata kunci judul untuk mencari: ");
        // Baca kata kunci pencarian, gunakan ?? untuk menangani null dan Trim() untuk menghilangkan spasi
        string kataKunci = (Console.ReadLine()! ?? "").Trim();

        // Cari semua film yang mengandung kata kunci (case-insensitive)
        // ToLower() mengubah huruf besar menjadi huruf kecil untuk perbandingan yang tidak peka huruf
        var hasilPencarian = films_0508.FindAll(film => film.ToLower().Contains(kataKunci.ToLower()));

        // Tampilkan jumlah hasil pencarian
        Console.WriteLine($"\nHasil pencarian ({hasilPencarian.Count}):");

        // Jika tidak ada hasil, beri pemberitahuan
        if (hasilPencarian.Count == 0)
        {
            Console.WriteLine("Tidak ditemukan film yang sesuai dengan kata kunci.");
            return;
        }

        // ===== TAMPILKAN HASIL PENCARIAN =====
        // Loop untuk menampilkan setiap film hasil pencarian
        for (int urutanFilm = 0; urutanFilm < hasilPencarian.Count; urutanFilm++)
        {
            // Tampilkan film dengan nomor urut
            Console.WriteLine($"{urutanFilm + 1}. {hasilPencarian[urutanFilm]}");
        }
    }

    static void FilterGenre()
    {
        Console.WriteLine("\n== Filter berdasarkan Genre ==");
        Console.WriteLine("Daftar genre:");

        // ===== TAMPILKAN DAFTAR GENRE =====
        // Loop untuk menampilkan semua genre dari list genreFilm_0508
        for (int i = 0; i < genreFilm_0508.Count; i++)
        {
            // Tampilkan setiap genre dengan nomor urut
            Console.WriteLine($"{i + 1}. {genreFilm_0508[i]}");
        }

        // Minta pengguna memilih nomor genre
        Console.Write("Pilih nomor genre: ");
        string inputNomorGenre = Console.ReadLine()!;
        int nomorGenre = -1; // Inisialisasi dengan nilai -1 (invalid)

        // Validasi input nomor genre berulang sampai valid
        while (nomorGenre < 1 || nomorGenre > genreFilm_0508.Count)
        {
            try
            {
                // Coba konversi input menjadi integer
                nomorGenre = int.Parse(inputNomorGenre);
                // Cek apakah nomor genre valid
                if (nomorGenre < 1 || nomorGenre > genreFilm_0508.Count)
                {
                    // Tampilkan error jika nomor tidak valid
                    Console.WriteLine("Nomor genre tidak valid. Pilih nomor genre yang sesuai.");
                    Console.Write("Pilih nomor genre: ");
                    inputNomorGenre = Console.ReadLine()!;
                }
            }
            catch (FormatException)
            {
                // Tangkap error jika input bukan angka
                Console.WriteLine("Input tidak valid. Masukkan angka yang benar.");
                Console.Write("Pilih nomor genre: ");
                inputNomorGenre = Console.ReadLine()!;
            }
        }

        // ===== AMBIL GENRE YANG DIPILIH =====
        // Ambil genre dari list berdasarkan nomor yang dipilih (kurangi 1 karena index mulai dari 0)
        string genre = genreFilm_0508[nomorGenre - 1];

        // ===== CARI FILM BERDASARKAN GENRE =====
        // Cari semua film yang mengandung genre yang dipilih (case-insensitive)
        var hasilPencarian = films_0508.FindAll(film => film.Contains(genre, StringComparison.OrdinalIgnoreCase));

        // ===== TAMPILKAN HASIL FILTER =====
        // Tampilkan genre dan jumlah film yang ditemukan
        Console.WriteLine($"\nFilm dengan genre '{genre}' ({hasilPencarian.Count}):");

        // Jika tidak ada film dengan genre tersebut
        if (hasilPencarian.Count == 0)
        {
            Console.WriteLine("Tidak ada film.");
        }
        else
        {
            // Loop untuk menampilkan setiap film hasil filter
            for (int i = 0; i < hasilPencarian.Count; i++)
            {
                // Tampilkan film dengan nomor urut
                Console.WriteLine($"{i + 1}. {hasilPencarian[i]}");
            }
        }
    }
}
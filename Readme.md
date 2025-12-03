
# Deskripsi Proyek

  

Aplikasi Manajemen Koleksi Film adalah aplikasi berbasis konsol yang digunakan untuk mengelola dan mengorganisir koleksi film pribadi dengan mudah dan efisien.

  

## Fitur-Fitur:

- **Tambah Film** - Menambahkan film baru ke koleksi dengan informasi judul, genre, dan tahun rilis

- **Lihat Data Film** - Menampilkan daftar semua film yang tersimpan dalam koleksi

- **Update Data Film** - Mengubah atau memperbarui informasi film yang sudah ada (judul, genre, tahun rilis)

- **Hapus Data Film** - Menghapus film dari koleksi

- **Cari Film** - Mencari film berdasarkan judul dengan kata kunci pencarian

- **Filter Berdasarkan Genre** - Menampilkan film-film yang termasuk dalam genre tertentu (Aksi, Komedi, Drama, Horror, Romantis, Sci-Fi, Dokumenter)

## CRUD Breakdown:

1. **Create**: `films_0508.Add()` pada method `TambahFilm()` untuk menambahkan entri film baru ke dalam List dengan format string yang berisi judul, genre, dan tahun rilis

2. **Read**: `foreach` pada method `LihatDataFilm()` untuk menampilkan semua film yang tersimpan, serta `FindAll()` pada `CariFilm()` dan `FilterGenre()` untuk membaca dan memfilter data berdasarkan kriteria

3. **Update**: `films_0508[index] = filmYangDipilih_0508` pada method `UpdateFilm()` untuk mengubah data film yang dipilih dengan memisahkan string menggunakan `Split()` dan menggabungkannya kembali dengan informasi yang diperbarui

4. **Delete**: `films_0508.RemoveAt()` pada method `HapusFilm()` untuk menghapus film dari List berdasarkan nomor urut yang dipilih pengguna

5. **Search**: `FindAll()` dengan `Contains()` pada method `CariFilm()` untuk mencari film berdasarkan kata kunci judul yang diinputkan pengguna

6. **Filter**: `FindAll()` dengan `Contains()` pada method `FilterGenre()` untuk menampilkan film-film yang sesuai dengan genre tertentu yang dipilih pengguna (Aksi, Komedi, Drama, Horror, Romantis, Sci-Fi, Dokumenter)`enter code here`

# SHA512 & Eliptik Eğri Kriptografisi (ECC) Web Uygulaması

Bu proje, .NET tabanlı modern bir web arayüzü ile **SHA512 özet fonksiyonu** ve **Eliptik Eğri Kriptografisi (ECC)** tabanlı şifreleme/şifre çözme işlemlerini bir arada sunar.

## Özellikler

- **SHA512 Özet Fonksiyonu**
  - Metin veya dosya yükleyerek SHA512 hash (özet) değeri oluşturma.
- **Eliptik Eğri Kriptografisi (ECC)**
  - Metin şifreleme (Encrypt)
  - Şifreli metni ve private key ile çözme (Decrypt)
- Modern, cyber ve responsive arayüz
- Tamamen Türkçe ve kullanıcı dostu

<img width="1440" alt="Ekran Resmi 2025-07-03 05 33 24" src="https://github.com/user-attachments/assets/430bee4c-71a3-437c-b52c-470e6b07aa73" />


Ana fonksiyonların ekran görüntülerini aşağıda bulabilirsiniz:

<img width="1440" alt="Ekran Resmi 2025-07-03 05 35 47" src="https://github.com/user-attachments/assets/185e0113-0e33-4fa8-87c3-3d3a5f094a8c" />
<br/>
<img width="1440" alt="Ekran Resmi 2025-07-03 05 36 31" src="https://github.com/user-attachments/assets/9ab62936-747e-4972-92ba-4f0b3fab7e36" />
<br/>
<img width="1440" alt="Ekran Resmi 2025-07-03 05 36 50" src="https://github.com/user-attachments/assets/ffd0a50a-f349-42b8-9fa4-cb00b6a58ef4" />
<br/>
<img width="1440" alt="Ekran Resmi 2025-07-03 05 37 05" src="https://github.com/user-attachments/assets/22326bc5-a499-44b9-8d33-de477b0fe10a" />
<br/>
<img width="1440" alt="Ekran Resmi 2025-07-03 05 38 02" src="https://github.com/user-attachments/assets/3ad98b95-a29f-4950-ac97-a8f02d27eef7" />
<br/>
<img width="1440" alt="Ekran Resmi 2025-07-03 05 39 32" src="https://github.com/user-attachments/assets/96864918-ecaa-4dcf-bad6-4a6e9c9ac9ad" />





## Kurulum

1. Bu repoyu klonlayın:
   ```sh
   git clone https://github.com/yelfettah/SHA_512.git
   cd SHA512App
   ```
2. Gerekli .NET SDK (en az .NET 7) yüklü olmalı.
3. Projeyi başlatmak için:
   ```sh
   dotnet run --project SHA512App/SHA512App.csproj
   ```
4. Tarayıcıdan `http://localhost:5283` adresine gidin.

## Kullanım

- **SHA512:** Ana menüden SHA512’ye tıklayın, metin girin veya dosya yükleyin, “SHA512 Hesapla”ya basın.
- **ECC:** Ana menüden ECC’ye tıklayın, metin girip şifreleyin veya şifreli metin ve anahtar girip çözün.

## Teknolojiler

- .NET 7 (C#)
- ASP.NET Core MVC
- HTML, CSS (Cyber/Modern tema)
- ECC ve SHA512 algoritmaları

## Katkı ve Lisans

- Katkıda bulunmak için PR gönderebilirsiniz.


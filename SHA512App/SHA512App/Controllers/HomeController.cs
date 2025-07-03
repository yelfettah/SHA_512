using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SHA512App.Models;
using System.Security.Cryptography;
using System.Text;

namespace SHA512App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // ECC SAYFASI - SIFIRDAN
    [HttpGet]
    public IActionResult ECC()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ECC(string eccAction, string? PlainText, string? EncryptedText, string? PrivateKey)
    {
        ViewBag.Result = null;
        ViewBag.Error = null;
        ViewBag.PrivateKey = null;
        ViewBag.PublicKey = null;

        try
        {
            if (eccAction == "encrypt" && !string.IsNullOrWhiteSpace(PlainText))
            {
                // Anahtar çifti oluştur
                using var ecdh = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
                var privateKey = ecdh.ExportECPrivateKey();
                var publicKey = ecdh.ExportSubjectPublicKeyInfo();
                var privateKeyB64 = Convert.ToBase64String(privateKey);
                var publicKeyB64 = Convert.ToBase64String(publicKey);

                // AES anahtarı üret
                using var aes = Aes.Create();
                aes.KeySize = 256;
                aes.GenerateKey();
                aes.GenerateIV();

                // Metni şifrele
                var plainBytes = Encoding.UTF8.GetBytes(PlainText);
                var encryptor = aes.CreateEncryptor();
                var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                // Sonuç: IV + Key + Cipher
                var resultBytes = aes.IV.Concat(aes.Key).Concat(cipherBytes).ToArray();
                var resultB64 = Convert.ToBase64String(resultBytes);

                ViewBag.Result = resultB64;
                ViewBag.PrivateKey = privateKeyB64;
                ViewBag.PublicKey = publicKeyB64;
            }
            else if (eccAction == "decrypt" && !string.IsNullOrWhiteSpace(EncryptedText) && !string.IsNullOrWhiteSpace(PrivateKey))
            {
                var encryptedBytes = Convert.FromBase64String(EncryptedText);
                if (encryptedBytes.Length < 48)
                {
                    ViewBag.Error = "Şifreli veri formatı hatalı.";
                    return View();
                }
                var iv = encryptedBytes.Take(16).ToArray();
                var key = encryptedBytes.Skip(16).Take(32).ToArray();
                var cipher = encryptedBytes.Skip(48).ToArray();

                // Private key'i yükle
                var privateKeyBytes = Convert.FromBase64String(PrivateKey);
                using var ecdh = ECDiffieHellman.Create();
                ecdh.ImportECPrivateKey(privateKeyBytes, out _);

                // AES ile çöz
                using var aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;
                var decryptor = aes.CreateDecryptor();
                var plainBytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);
                var plainText = Encoding.UTF8.GetString(plainBytes);
                ViewBag.Result = plainText;
            }
            else
            {
                ViewBag.Error = "Lütfen gerekli alanları doldurun.";
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Hata: " + ex.Message;
        }
        return View();
    }

    // SHA512 SAYFASI
    [HttpGet]
    public IActionResult SHA512Hash()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SHA512Hash(string? InputText, IFormFile? InputFile)
    {
        string hashResult = string.Empty;
        if (!string.IsNullOrEmpty(InputText))
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(InputText);
                byte[] hash = sha512.ComputeHash(bytes);
                hashResult = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        else if (InputFile != null && InputFile.Length > 0)
        {
            using (SHA512 sha512 = SHA512.Create())
            using (var stream = InputFile.OpenReadStream())
            {
                byte[] hash = sha512.ComputeHash(stream);
                hashResult = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
        ViewBag.Hash = hashResult;
        return View();
    }
}



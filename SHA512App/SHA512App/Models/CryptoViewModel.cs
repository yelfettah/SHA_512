namespace SHA512App.Models;

public class CryptoViewModel
{
    // SHA512 için
    public string? InputText { get; set; }
    public string? Sha512Hash { get; set; }

    // ECC için
    public string? PlainText { get; set; }
    public string? EncryptedText { get; set; }
    public string? DecryptedText { get; set; }
    public string? PublicKey { get; set; }
    public string? PrivateKey { get; set; }
    public string? ECCMessage { get; set; } // İşlem sonucu mesajı
} 
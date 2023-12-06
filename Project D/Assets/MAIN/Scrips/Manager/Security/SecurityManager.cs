using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;  

public class SecurityManager :MonoBehaviour
{
    private static SecurityManager instance;
    private RSACryptoServiceProvider rsaProvider;

    public static SecurityManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SecurityManager>();

            }
            return instance;    
        }
    }

    private void Awake()
    {
        rsaProvider = new RSACryptoServiceProvider();
    }

    public string Encrypt(string plainText)
    {
        byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, true);
        string encryptedText = Convert.ToBase64String(encryptedBytes);
        return encryptedText;
    }

    public string Decrypt(string encryptedText)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = rsaProvider.Decrypt(encryptedBytes, true);
        string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);
        return decryptedText;
    }

/*    Khi ??i t??ng SecurityManager ???c t?o, m?t ??i t??ng RSACryptoServiceProvider m?i c?ng ???c t?o và l?u tr? trong bi?n rsaProvider.?i?u này ??ng ngh?a v?i vi?c c?p khóa RSA(khóa công khai và khóa bí m?t) c?ng ???c t?o và gán cho ??i t??ng rsaProvider.

B?n có th? s? d?ng ph??ng th?c rsaProvider.ExportParameters(false) ?? truy c?p thông tin v? khóa công khai(public key) và rsaProvider.ExportParameters(true) ?? truy c?p thông tin v? khóa bí m?t(private key). Tuy nhiên, trong ?o?n mã này, vi?c truy c?p và s? d?ng khóa bí m?t không ???c tri?n khai.*/
}

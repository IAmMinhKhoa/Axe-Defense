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

/*    Khi ??i t??ng SecurityManager ???c t?o, m?t ??i t??ng RSACryptoServiceProvider m?i c?ng ???c t?o v� l?u tr? trong bi?n rsaProvider.?i?u n�y ??ng ngh?a v?i vi?c c?p kh�a RSA(kh�a c�ng khai v� kh�a b� m?t) c?ng ???c t?o v� g�n cho ??i t??ng rsaProvider.

B?n c� th? s? d?ng ph??ng th?c rsaProvider.ExportParameters(false) ?? truy c?p th�ng tin v? kh�a c�ng khai(public key) v� rsaProvider.ExportParameters(true) ?? truy c?p th�ng tin v? kh�a b� m?t(private key). Tuy nhi�n, trong ?o?n m� n�y, vi?c truy c?p v� s? d?ng kh�a b� m?t kh�ng ???c tri?n khai.*/
}

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
    public void PrintKeyPair()
    {
        string publicKey = rsaProvider.ToXmlString(false);
        string privateKey = rsaProvider.ToXmlString(true);

        Debug.Log("Public key:\n" + publicKey);
        Debug.Log("Private key:\n" + privateKey);
    }
}

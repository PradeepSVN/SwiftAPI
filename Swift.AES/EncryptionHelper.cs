using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Swift.AES
{
	public static class EncryptionHelper
	{
		//	//private static readonly string EncryptionKey = GenerateRandomKey(256);
		//	private static readonly string EncryptionKey = GenerateRandomKey(256);

		//	public static string Encrypt(string plainText)
		//	{
		//		using (Aes aesAlg = Aes.Create())
		//		{
		//			aesAlg.Key = Convert.FromBase64String(EncryptionKey);
		//			aesAlg.IV = GenerateRandomIV(); // Generate a random IV for each encryption

		//			aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

		//			ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

		//			using (MemoryStream msEncrypt = new MemoryStream())
		//			{
		//				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
		//				{
		//					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
		//					{
		//						swEncrypt.Write(plainText);
		//					}
		//				}
		//				return Convert.ToBase64String(aesAlg.IV.Concat(msEncrypt.ToArray()).ToArray());
		//			}
		//		}
		//	}

		//	public static string Decrypt(string cipherText)
		//	{
		//		byte[] cipherBytes = Convert.FromBase64String(cipherText);

		//		using (Aes aesAlg = Aes.Create())
		//		{
		//			aesAlg.Key = Convert.FromBase64String(EncryptionKey);
		//			aesAlg.IV = cipherBytes.Take(16).ToArray();

		//			aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

		//			ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

		//			using (MemoryStream msDecrypt = new MemoryStream(cipherBytes, 16, cipherBytes.Length - 16))
		//			{
		//				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
		//				{
		//					using (StreamReader srDecrypt = new StreamReader(csDecrypt))
		//					{
		//						return srDecrypt.ReadToEnd();
		//					}
		//				}
		//			}
		//		}
		//	}

		//	private static byte[] GenerateRandomIV()
		//	{
		//		using (Aes aesAlg = Aes.Create())
		//		{
		//			aesAlg.GenerateIV();
		//			return aesAlg.IV;
		//		}
		//	}

		//	private static string GenerateRandomKey(int keySizeInBits)
		//	{
		//		// Convert the key size to bytes
		//		int keySizeInBytes = keySizeInBits / 8;

		//		// Create a byte array to hold the random key
		//		byte[] keyBytes = new byte[keySizeInBytes];

		//		// Use a cryptographic random number generator to fill the byte array
		//		using (var rng = new RNGCryptoServiceProvider())
		//		{
		//			rng.GetBytes(keyBytes);
		//		}

		//		// Convert the byte array to a base64-encoded string for storage
		//		return Convert.ToBase64String(keyBytes);
		//	}

		//}


		//#region Static Functions

		///// <summary>
		///// Encrypts a string
		///// </summary>
		///// <param name="PlainText">Text to be encrypted</param>
		///// <param name="Password">Password to encrypt with</param>
		///// <param name="Salt">Salt to encrypt with</param>
		///// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
		///// <param name="PasswordIterations">Number of iterations to do</param>
		///// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
		///// <param name="KeySize">Can be 128, 192, or 256</param>
		///// <returns>An encrypted string</returns>
		//public static string Encrypt(string PlainText, string Password,
		//	string Salt = "Kosher", string HashAlgorithm = "SHA1",
		//	int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY",
		//	int KeySize = 256)
		//{
		//	if (string.IsNullOrEmpty(PlainText))
		//		return "";
		//	byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
		//	byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
		//	byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
		//	PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
		//	byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
		//	RijndaelManaged SymmetricKey = new RijndaelManaged();
		//	SymmetricKey.Mode = CipherMode.CBC;
		//	byte[] CipherTextBytes = null;
		//	using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
		//	{
		//		using (MemoryStream MemStream = new MemoryStream())
		//		{
		//			using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
		//			{
		//				CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
		//				CryptoStream.FlushFinalBlock();
		//				CipherTextBytes = MemStream.ToArray();
		//				MemStream.Close();
		//				CryptoStream.Close();
		//			}
		//		}
		//	}
		//	SymmetricKey.Clear();
		//	return Convert.ToBase64String(CipherTextBytes);
		//}

		///// <summary>
		///// Decrypts a string
		///// </summary>
		///// <param name="CipherText">Text to be decrypted</param>
		///// <param name="Password">Password to decrypt with</param>
		///// <param name="Salt">Salt to decrypt with</param>
		///// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
		///// <param name="PasswordIterations">Number of iterations to do</param>
		///// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
		///// <param name="KeySize">Can be 128, 192, or 256</param>
		///// <returns>A decrypted string</returns>
		//public static string Decrypt(string CipherText, string Password,
		//	string Salt = "Kosher", string HashAlgorithm = "SHA1",
		//	int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY",
		//	int KeySize = 256)
		//{
		//	if (string.IsNullOrEmpty(CipherText))
		//		return "";
		//	byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
		//	byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
		//	byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
		//	PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
		//	byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
		//	RijndaelManaged SymmetricKey = new RijndaelManaged();
		//	SymmetricKey.Mode = CipherMode.CBC;
		//	byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
		//	int ByteCount = 0;
		//	using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
		//	{
		//		using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
		//		{
		//			using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
		//			{

		//				ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
		//				MemStream.Close();
		//				CryptoStream.Close();
		//			}
		//		}
		//	}
		//	SymmetricKey.Clear();
		//	return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
		//}

		//#endregion


		//public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		public static string EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return Convert.ToBase64String(encrypted);
			//return encrypted;
		}

		public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}

			return plaintext;
		}
	}
}

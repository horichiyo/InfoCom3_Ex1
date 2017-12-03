using System;
using System.Text;
using System.Security.Cryptography;

namespace ex1
{
	public static class Crypt
	{
		//暗号化(DES)関数
		public static byte[] EncryptText(string str, byte[] Key)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider()
			{
				Key = Key,
				IV = Key
			};
			byte[] bstr = Encoding.UTF8.GetBytes(str);

			ICryptoTransform transform = des.CreateEncryptor();
			byte[] encrypted = transform.TransformFinalBlock(bstr, 0, bstr.Length);
			transform.Dispose();
			return encrypted;
		}

		//暗号化(DES)関数
		public static byte[] EncryptText(byte[] bstr, byte[] Key)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider()
			{
				Key = Key,
				IV = Key
			};

			ICryptoTransform transform = des.CreateEncryptor();
			byte[] encrypted = transform.TransformFinalBlock(bstr, 0, bstr.Length);
			transform.Dispose();
			return encrypted;
		}

		//復号化(DES)関数
		public static byte[] DecryptText(byte[] bcrypt, byte[] Key)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider()
			{
				Key = Key,
				IV = Key
			};

			ICryptoTransform destransform = des.CreateDecryptor();
			byte[] decrypted = destransform.TransformFinalBlock(bcrypt, 0, bcrypt.Length);
			destransform.Dispose();
			return decrypted;

		}
		//Caisar関数(mode True:暗号化 False:復号化)
		public static byte[] CaiserCipher(byte[] str, int shiftSize, Boolean mode)
		{
			var i = shiftSize;
			byte[] result = new byte[str.Length];
			if(!mode){
				i *= -1;
			}
			for(var j = 0; j < str.Length; j++){
				result[j] = (byte)((256 * shiftSize / 256 + (str[j] + shiftSize)) % 256);
			}
			return result;
		}
	}
}

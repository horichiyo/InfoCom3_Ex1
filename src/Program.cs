using System;
using System.Text;
using System.Security.Cryptography;

namespace ex1
{
	class MainClass
	{
		public static void Main()
		{
			byte[] secretKey = {
				0x13,
				0xCB,
				0x73,
				0xBE,
				0xA1, 
				0xC1, 
				0xED,
				0x5B
			};

			//引数で指定したテキストを暗号化（DES暗号）
			string textData = "The majestic red rock landscape here is awe inspiring,\nand I want to capture it with my camera.\nBut the area is so vast that I can only see a part of it with my lens.";
			byte[] encryptdata = Crypt.EncryptText(textData, secretKey);

			//復号化（DES暗号）
			byte[] decryptdata = Crypt.DecryptText(encryptdata, secretKey);
			if(textData.Equals(Encoding.GetEncoding(50220).GetString(decryptdata))){
				Console.WriteLine(textData);
				Console.WriteLine("文字列復号化完了");
				Console.WriteLine("-以下暗号化したあとの文字列---------------");
				Console.WriteLine(Encoding.GetEncoding(50220).GetString(encryptdata));
				Console.WriteLine("-以上暗号化したあとの文字列---------------");
			}

			//BMP画像の暗号化（Caiser，DES）
			byte[] result;
			byte[] resultDes;
			var fileName = "Lenna.bmp";

			//Caiserで画像を暗号化
			Bmp.Load(fileName, out Bmp.BITMAPFILEHEADER bfh, out Bmp.BITMAPINFOHEADER bih, out byte[] bitData);
			result = Crypt.CaiserCipher(bitData, 3, true);
			Bmp.Save("resultCaiser.bmp", bih.biWidth, bih.biHeight, bih.biBitCount, result);

			//BMP画像の暗号化（DES）
			Bmp.Load(fileName, out bfh, out bih, out bitData);
			resultDes = Crypt.EncryptText(bitData, secretKey);
			for(int i = 0; i < result.Length; i++){
				result[i] = resultDes[i];
			}

			//BMP画像の復号化（DES）
			if(Bmp.Save("resultDes.bmp", bih.biWidth, bih.biHeight, bih.biBitCount, result)){
				Console.WriteLine("画像復号化完了");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScoreClass.Web.Extensions
{
	public static class QRCodeGenerator
	{
		private const string URL = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=http://nitcoin.azurewebsites.net/Parceria/Validar/";

		internal static byte[] Gerar(string codigo)
		{
			var link = URL + codigo;

			var http = new HttpClient();
			var image = http.GetByteArrayAsync(new Uri(link));

			return image.Result;
		}
	}
}

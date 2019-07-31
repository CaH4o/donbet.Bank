using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_bank_bankomat_client
{
	// Banc:
	//   содержит список клиентов
	//   метод для записи данных в файл
	//   метод для считывания данных из файла
	//   метод для генерирования данных о карте
	//   метод для генерирования пароля

	class Bank
	{
		List<Client> clients = null;

		public Bank()
		{
			clients = new List<Client>();
		}



		public string GetNewCardNo()
		{
			return GetNewNumbers(16);
		}

		public string GetNewPassword()
		{
			return GetNewNumbers(4);
		}

		private string GetNewNumbers(int lingth)
		{
			Random r = new Random();
			string newNumber = "";

			for (int i = 0; i < lingth; i++)
			{
				newNumber += r.Next(10).ToString();
			}

			return newNumber;
		}

	}
}

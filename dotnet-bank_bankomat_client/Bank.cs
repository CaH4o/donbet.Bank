using System;
using System.Collections.Generic;
using System.IO;
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
		string _filePath = "db.dat";

		public Bank()
		{
			clients = new List<Client>();
			ReadDB();
		}

		public void NewClient(decimal money = 0)
		{
			Client Temp = new Client(GetNewCardNo(), GetNewPassword());
			Temp.Money = money;
			clients.Add(Temp);
			WriteDB();
		}

		private void ReadDB()
		{
			FileInfo dir = new FileInfo(_filePath);

			if (!dir.Exists) return;

			using (FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (BinaryReader sr = new BinaryReader(fs, Encoding.Unicode))
				{
					long count = sr.ReadInt64();
					string noCard;
					string password;
					Console.WriteLine(count);

					for (int i = 0; i < count; i++)
					{
						noCard = sr.ReadString();
						password = sr.ReadString();

						Client cTemp = new Client(noCard, password);
						cTemp.Money = sr.ReadDecimal();
						clients.Add(cTemp);

						Console.WriteLine(cTemp);
					}

					Console.ReadKey();
				}
			}
		}

		private void WriteDB()
		{
			long count = clients.Count;

			if (count == 0) return;

			using (FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
				{
					bw.Write(count);

					for (int i = 0; i < count; i++)
					{
						bw.Write(clients[i].NoCard);
						bw.Write(clients[i].Password);
						bw.Write(clients[i].Money);
					}
				}
			}
		}

		public string GetNewCardNo()
		{
			return GetNumber(16);
		}

		public string GetNewPassword()
		{
			return GetNumber(4);
		}

		private string GetNumber(int length)
		{
			Random rand = new Random();
			string newNumber = "";

			for (int i = 0; i < length; ++i)
			{
				newNumber += rand.Next(10).ToString();
			}

			return newNumber;
		}

		public override string ToString()
		{
			string res = "";
			foreach (var item in clients)
			{
				res += item + "\n\n";
			}

			return res;
		}
	}
}

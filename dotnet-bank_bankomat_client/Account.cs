using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_bank_bankomat_client
{
	// Account:
	//   методы для зачисления/растраты денег
	//   метод проверки пароля при авторизации
	//   метод для установки значения в поле "опасных" попыток авторизации.
	//   После "правильной" авторизации значение обнуляется.
	//   Вывод данных по аккаунту
	//   метод для изменения пароля

	class Account
	{
		Client _client;
		int _countMiss = 0;

		public Account(Client client)
		{
			this._client = client;
		}

		public void ChangeMoney(decimal money)
		{

		}

		public bool CheckPassword(string password)
		{
			if (_countMiss > 3) return false;

			if (_client.Password == password)
			{
				_countMiss = 0;
				return true;
			}
			else
			{
				++_countMiss;
				return false;
			}
		}

		public void ChangePassword(string noCard, string password)
		{
			_client.ChangePassword(noCard, password);

		}
	}
}

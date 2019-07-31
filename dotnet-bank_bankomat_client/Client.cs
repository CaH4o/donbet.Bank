using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_bank_bankomat_client
{
	// Client:
	//   номер карты
	//   пароль
	//   сумма на счету

	class Client
	{
		public Client(string noCard, string password)
		{
			this.NoCard = noCard;
			this.Password = password;
			this._money = 0;
		}

		public bool ChangePassword(string noCard, string password)
		{
			if (noCard == this.NoCard)
			{
				this.Password = password;
				return true;
			}

			return false;
		}

		public string NoCard { get;  }
		public string Password { get; private set; }
		decimal _money;
		public decimal Money {
			get { return _money; }
			set { if(_money + value >= 0) _money += value; }
		}
	}
}

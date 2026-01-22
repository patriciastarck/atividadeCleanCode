using System;

namespace CleanCode
{
	public static class DescontoConfig
	{
		private const decimal DESCONTO_REGULAR = 0.05m;
		private const decimal DESCONTO_PREMIUM = 0.10m;
		private const decimal DESCONTO_VIP = 0.15m;

		public static decimal ObterPercentual(ClienteTipo tipo, bool aplicaDesconto)
		{
			if (!aplicaDesconto)
				return 0m;

			return tipo switch
			{
				ClienteTipo.Regular => DESCONTO_REGULAR,
				ClienteTipo.Premium => DESCONTO_PREMIUM,
				ClienteTipo.Vip => DESCONTO_VIP,
				_ => 0m
			};
		}
	}
}
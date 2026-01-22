namespace CleanCode;

public class CalculadoraPrecoServico
{
	public decimal CalcularValorFinal(Pedido pedido)
	{
		ValidarPedido(pedido);

		decimal valorBruto = pedido.Quantidade * pedido.PrecoUnitario;

		decimal percentualDesconto = DescontoConfig.ObterPercentual(
			pedido.TipoCliente,
			pedido.AplicaDesconto);

		decimal valorDesconto = valorBruto * percentualDesconto;
		decimal valorFinal = valorBruto - valorDesconto;

		return valorFinal;
	}

	private static void ValidarPedido(Pedido pedido)
	{
		if (pedido.Quantidade <= 0)
			throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(pedido.Quantidade));

		if (pedido.PrecoUnitario <= 0)
			throw new ArgumentException("Preço unitário deve ser maior que zero.", nameof(pedido.PrecoUnitario));
	}
}
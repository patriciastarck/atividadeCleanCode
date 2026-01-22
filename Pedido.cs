using System;

public class Pedido
{
	public int Quantidade { get; }
	public decimal PrecoUnitario { get; }
	public ClienteTipo TipoCliente { get; }
	public bool AplicaDesconto { get; }

	public Pedido(
		int quantidade,
		decimal precoUnitario,
		ClienteTipo tipoCliente,
		bool aplicaDesconto)
	{
		Quantidade = quantidade;
		PrecoUnitario = precoUnitario;
		TipoCliente = tipoCliente;
		AplicaDesconto = aplicaDesconto;
	}
}
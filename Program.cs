using CleanCode; // <--- ESSA LINHA É O SEGREDO! Ela importa suas outras classes.

Console.WriteLine("Hello, World!");

var pedido = new Pedido(
	quantidade: 5,
	precoUnitario: 120.00m,
	tipoCliente: ClienteTipo.Vip,
	aplicaDesconto: true
);

var calculadora = new CalculadoraPrecoServico();
decimal valorFinal = calculadora.CalcularValorFinal(pedido);

Console.WriteLine($"Valor final: {valorFinal:C}");
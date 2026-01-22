Alunas: Gabriela Miranda e Patricia Bernardi

🧹 Exercício de Refatoração - Clean Code 
Este projeto consiste na refatoração de um sistema legado de vendas. O objetivo é transformar um código difícil de ler e manter em uma solução orientada a objetos, legível e extensível, aplicando os princípios de Clean Code.

📋 Descrição do Cenário
O sistema possui um módulo responsável por calcular o valor final de um pedido. As regras de negócio são:

Entrada de Dados: O método recebe a quantidade, valor unitário, tipo do cliente e se o desconto deve ser aplicado.

Validação: Quantidade e valor unitário devem ser maiores que zero.

Cálculo Base: O valor bruto é Quantidade * Preço Unitário.

Regras de Desconto:

Cliente Regular: 5% de desconto.

Cliente Premium: 10% de desconto.

Cliente VIP: 15% de desconto.

💀 O Problema (Antes)
Abaixo está o código original. Observe o uso de nomes obscuros, "números mágicos" e alta complexidade ciclomática.

C#

public class P {
    public double M(int q, double p, int t, bool d) {
        double r = 0;
        if (q <= 0 || p <= 0) { return 0; }

        if (t == 1) {
            r = q * p;
            if (d) {
                r = r - (r * 0.05);
            }
        }
        else if (t == 2) {
            r = q * p;
            if (d) {
                r = r - (r * 0.10);
            }
        }
        else if (t == 3) {
            r = q * p;
            if (d) { r = r - (r * 0.15); }
        }
        else {
            r = q * p;
        }

        return r;
    }
}
🚩 Violações de Clean Code Identificadas:
Nomes não descritivos: Classes (P), Métodos (M) e Variáveis (q, p, t) que não revelam intenção.

Magic Numbers: Uso de 1, 2, 3 para tipos de cliente e 0.05, etc., para descontos espalhados no código.

Obsessão por Primitivos: Uso de int para definir tipos de clientes em vez de um Enum.

Violação DRY (Don't Repeat Yourself): A lógica de multiplicação r = q * p é repetida várias vezes.

Retorno de Erro Silencioso: Retorna 0 quando a validação falha, em vez de lançar uma exceção clara.

✨ A Solução (Depois)
O código foi refatorado dividindo as responsabilidades em classes coesas e utilizando nomes significativos.

Estrutura do Projeto
CalculadoraPrecoServico.cs: Classe responsável exclusivamente pela regra de negócio do cálculo.

Pedido.cs: Classe de domínio (Data Object) que agrupa os dados necessários, evitando listas longas de parâmetros.

ClienteTipo.cs: Enum para representar os tipos de cliente, eliminando a ambiguidade de números inteiros.

DescontoConfig.cs: Configuração centralizada das taxas de desconto (eliminação de números mágicos).

Principais Melhorias Aplicadas:
Nomes Significativos: CalculadoraPrecoServico, CalcularValorFinal, ValorBruto. O código agora se lê como prosa.

Fail Fast (Validação Imediata): O método ValidarPedido lança exceções (ArgumentException) imediatamente se os dados estiverem errados, protegendo a integridade do sistema.

Single Responsibility Principle (SRP):

A lógica de qual desconto aplicar foi movida para DescontoConfig.

A calculadora foca apenas no fluxo do cálculo.

Uso de Enums: Substituição de 1, 2, 3 por ClienteTipo.Regular, etc.

Modern C# Features: Uso de Switch Expressions para deixar a seleção de descontos mais limpa e concisa.


Valor final: R$ 510,00
📚 Arquivos do Projeto
CalculadoraPrecoServico.cs
Contém a lógica principal, orquestrando a validação e o cálculo.



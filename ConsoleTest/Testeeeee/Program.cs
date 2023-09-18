double faturamentoSP = 67836.43;
double faturamentoRJ = 36678.66;
double faturamentoMG = 29229.88;
double faturamentoES = 27165.48;
double faturamentoOutros = 19849.53;

double faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG + faturamentoES + faturamentoOutros;

double participacaoSP = (faturamentoSP / faturamentoTotal) * 100;
double participacaoRJ = (faturamentoRJ / faturamentoTotal) * 100;
double participacaoMG = (faturamentoMG / faturamentoTotal) * 100;
double participacaoES = (faturamentoES / faturamentoTotal) * 100;
double participacaoOutros = (faturamentoOutros / faturamentoTotal) * 100;


Console.WriteLine($"Participação de SP: {participacaoSP:F2}");
Console.WriteLine($"Participação de RJ: {participacaoRJ:F2}");
Console.WriteLine($"Participação de MG: {participacaoMG:F2}");
Console.WriteLine($"Participação de ES: {participacaoES:F2}");
Console.WriteLine($"Participação de Outros: {participacaoOutros:F2}");
﻿using Xunit;

namespace Features.Tests._03_Order;

[TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
public class OrdemTestes
{
    public static bool Teste1Chamado;
    public static bool Teste2Chamado;
    public static bool Teste3Chamado;
    public static bool Teste4Chamado;

    [Fact(DisplayName = "Teste 4"), TestPriority(3)]
    public void Teste04()
    {
        Teste4Chamado = true;

        Assert.True(Teste3Chamado);
        Assert.True(Teste1Chamado);
        Assert.False(Teste2Chamado);
    }

    [Fact(DisplayName = "Teste 1"), TestPriority(2)]
    public void Teste01()
    {
        Teste1Chamado = true;

        Assert.True(Teste3Chamado);
        Assert.False(Teste4Chamado);
        Assert.False(Teste2Chamado);
    }

    [Fact(DisplayName = "Teste 3"), TestPriority(1)]
    public void Teste03()
    {
        Teste3Chamado = true;

        Assert.False(Teste1Chamado);
        Assert.False(Teste2Chamado);
        Assert.False(Teste4Chamado);
    }

    [Fact(DisplayName = "Teste 2"), TestPriority(4)]
    public void Teste02()
    {
        Teste2Chamado = true;

        Assert.True(Teste3Chamado);
        Assert.True(Teste4Chamado);
        Assert.True(Teste1Chamado);
    }
}

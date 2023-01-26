global using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes;
public class NavegandoNaPaginaHome
{
    [Fact]
    public void CarregaPaginaHomeEVerificaTituloDaPagina()
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        driver.Navigate().GoToUrl("https://localhost:44309");

        Assert.Contains("WebApp", driver.Title);
    }

    [Fact]
    public void CarregarDaPaginaHomeVerificaExistenciaLinkLoginEHome()
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        driver.Navigate().GoToUrl("https://localhost:44309");

        Assert.Contains("Login", driver.PageSource);
        Assert.Contains("Home", driver.PageSource);
    }

    [Fact]
    public void ValidaLinkDeLoginNaHome()
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        driver.Navigate().GoToUrl("https://localhost:44309");
        var linkLogin = driver.FindElement(By.LinkText("Login"));
        linkLogin.Click();

        Assert.Contains("img", driver.PageSource);
    }

    [Fact]
    public void TentaAcessarPaginaSemEstarLogado()
    {
        IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

        Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
        Assert.Contains("401", driver.PageSource);
    }
}

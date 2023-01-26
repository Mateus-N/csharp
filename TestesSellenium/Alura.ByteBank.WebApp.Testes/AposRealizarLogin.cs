using Alura.ByteBank.WebApp.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes;

public class AposRealizarLogin
{
    private readonly IWebDriver driver;

    public AposRealizarLogin()
    {
        driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location ));
    }

    [Fact]
    public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
    {
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.Logar();

        Assert.Contains("Agencia", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginSemPreencherCampos()
    {
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
        loginPO.Logar();

        Assert.Contains("The Email field is required.", driver.PageSource);
        Assert.Contains("The Senha field is required.", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginComSenhaInvalida()
    {
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
        loginPO.PreencherCampos("andre@email.com", "senha010");
        loginPO.Logar();

        Assert.Contains("Login", driver.PageSource);
    }

    [Fact]
    public void RealizaLoginAcessaMenuECadastraCliente()
    {
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.Logar();

        driver.FindElement(By.LinkText("Cliente")).Click();
        driver.FindElement(By.LinkText("Adicionar Cliente")).Click();
        driver.FindElement(By.Name("Identificador")).Click();
        driver.FindElement(By.Name("Identificador")).SendKeys("2df71922-ca7d-4d43-b142-0767b32f822a");
        driver.FindElement(By.Name("CPF")).Click();
        driver.FindElement(By.Name("CPF")).SendKeys("69981034096");
        driver.FindElement(By.Name("Nome")).Click();
        driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
        driver.FindElement(By.Name("Profissao")).Click();
        driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

        driver.FindElement(By.CssSelector(".btn-primary")).Click();
        driver.FindElement(By.LinkText("Home")).Click();

        Assert.Contains("Logout", driver.PageSource);
    }
}

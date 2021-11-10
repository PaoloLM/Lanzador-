using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;
using TuTiendaTest_Selenium.Pruebas;
using System.Linq;
using OpenQA.Selenium.Interactions;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Models;

namespace TuTiendaTest_Selenium.Pruebas
{
    public class CP_11_Gestionar_Pedido : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;
        public static Random rnd = new Random();

        [Fact]
        public static void AgregarProductoCarrito()
        {        
            CP_05_Cerrar_Sesion.Logout();
            Thread.Sleep(2000);

            CP_04_Iniciar_Sesion.Login();
            Thread.Sleep(2000);

            int[] productos = {1, 4, 9, 10, 11, 12, 13, 14, 15, 16, 18, 19, 20, 22, 23 }; int await = productos.Length;

            for (int i = 0; i < rnd.Next(1, 3); i++)
            {               
                Thread.Sleep(1000);
                var indice = productos[rnd.Next(0, 16)]; 

                _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser/ProductoDetalle/" + indice);
                var cantidadElement = _driver.FindElement(By.Id("cantidad"));
                cantidadElement.Clear(); cantidadElement.SendKeys(rnd.Next(1, 5).ToString());
                Thread.Sleep(2000);

                var añadirElement = _driver.FindElement(By.ClassName("add-to-cart-btn")); añadirElement.Click();
                Thread.Sleep(1000);

                productos.Where((source, index) => index != indice).ToArray(); await--;

                _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser");
            }
            Console.WriteLine("Prueba de agregar producto al carrito correcto \n");
            Thread.Sleep(2000);           
        }

        [Fact]
        public void GuardarPedido()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser/ListarCarrito");
            Thread.Sleep(2000);

            var comprarElement = _driver.FindElement(By.ClassName("btn-primary")); comprarElement.Click();

            Console.WriteLine("Prueba de guardar pedido correcto \n");
            Thread.Sleep(2000);
        }

        [Fact]
        public void ListarPedido()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser/ListarPedidos");

            Console.WriteLine("Prueba de listar pedido correcto \n");
            Thread.Sleep(2000);
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}

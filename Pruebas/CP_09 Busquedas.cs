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
    public class CP_09_Busquedas : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;

        [Fact]
        public void BuscarUsuario()
        {
            CP_05_Cerrar_Sesion.Logout();
            Thread.Sleep(2000);

            CP_04_Iniciar_Sesion.LoginAdmin();
            Thread.Sleep(2000);

            _driver.Navigate().GoToUrl("http://localhost:50928/Usuario/Index");
            Thread.Sleep(2000);

            var buscarElement = _driver.FindElements(By.ClassName("form-control-sm"));
            var element = buscarElement[1];
            element.Clear(); element.SendKeys("Al");

            Console.WriteLine("Prueba de busqueda de usuario correcto \n");
            Thread.Sleep(2000);           
        }

        [Fact]
        public void BuscarProducto()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Producto/Index");
            Thread.Sleep(2000);

            var buscarElement = _driver.FindElements(By.ClassName("form-control-sm"));
            var element = buscarElement[1];

            string[] categorias = {"Leche", "Gaseosa", "Papa", "Pechuga"
                , "Para", "Yogurt", "Cremas", "Mayo"};

            for (int i = 0; i < categorias.Length; i++)
            {
                element.Clear(); element.SendKeys(categorias[i]);
                Thread.Sleep(1000);
            }

            Console.WriteLine("Prueba de busqueda de producto correcto \n");
        }

        [Fact]
        public void BuscarTienda()
        {
            
        }

        [Fact]
        public void BuscarPedido()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Pedido/Index");
            Thread.Sleep(2000);

            var buscarElement = _driver.FindElements(By.ClassName("form-control-sm"));
            var element = buscarElement[1];

            Random rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                element.Clear(); element.SendKeys("P-" + rnd.Next(1,15));
                Thread.Sleep(1000);
            }

            Console.WriteLine("Prueba de busqueda de pedido correcto \n");
        }

        [Fact]
        public void BuscarCategoria()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Producto/Index");
            Thread.Sleep(2000);

            var buscarElement = _driver.FindElements(By.ClassName("form-control-sm"));
            var element = buscarElement[1];

            string[] categorias = {"Lacteos", "Embutidos", "Carnes", "Bebidas"
                , "Conservas", "Licores", "Cremas", "Limpieza"
                , "Snacks", "Medicina", "Pollos", "Menestras" };

            for (int i = 0; i < categorias.Length; i++)
            {
                element.Clear(); element.SendKeys(categorias[i]);
                Thread.Sleep(1500);
            }

            Console.WriteLine("Prueba de busqueda de producto correcto \n");
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}

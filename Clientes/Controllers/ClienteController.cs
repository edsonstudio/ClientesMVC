using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clientes.DAO;
using Clientes.Models;

namespace Clientes.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            var lista = clienteDAO.SelecionarTodos();
            ViewBag.clientes = lista;

            var listaNome = clienteDAO.SelecionarTodos();
            listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesN = listaNome;

            var listaCpf = clienteDAO.SelecionarTodos();
            listaCpf.Sort((c1, c2) => c1.Cpf.ToUpper().CompareTo(c2.Cpf.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesC = listaCpf;

            return View();
        }

        //FORMA 1
        //static int CompareClientes(Cliente c1, Cliente c2)
        //{
        //    return c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper());
        //}

        //public ActionResult OrdenarNome()
        //{
        //    ClienteDAO clienteDAO = new ClienteDAO();

        //    var listaNome = clienteDAO.SelecionarTodos();
        //    // lista.Sort(CompareClientes); //Delegate <<<<<< FORMA 1
        //    //Comparison<Cliente> comp = (c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()); //Função anônima - LAMBDA - FORMA 2
        //    //lista.Sort(comp); // FORMA 2
        //    //FORMA 3
        //    listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort

        //    ViewBag.clientes = listaNome;

        //    return RedirectToAction("Form", listaNome);
        //}

        public ActionResult Pesquisar(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            var lista = clienteDAO.SelecionarTodos();
            var clientePesq = clienteDAO.PesqId(cliente);
            ViewBag.clientes = lista;
            ViewBag.Cliente = clientePesq;

            var listaNome = clienteDAO.SelecionarTodos();
            listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesN = listaNome;

            var listaCpf = clienteDAO.SelecionarTodos();
            listaCpf.Sort((c1, c2) => c1.Cpf.ToUpper().CompareTo(c2.Cpf.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesC = listaCpf;

            return View();
        }

        public ActionResult PesquisarNm(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            var lista = clienteDAO.SelecionarTodos();
            var clientePesq = clienteDAO.PesqNm(cliente);
            ViewBag.clientes = lista;
            ViewBag.Cliente = clientePesq;

            var listaNome = clienteDAO.SelecionarTodos();
            listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesN = listaNome;

            var listaCpf = clienteDAO.SelecionarTodos();
            listaCpf.Sort((c1, c2) => c1.Cpf.ToUpper().CompareTo(c2.Cpf.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesC = listaCpf;

            return RedirectToAction("Pesquisar", clientePesq);
        }

        public ActionResult PesquisarCpf(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            var lista = clienteDAO.SelecionarTodos();
            var clientePesq = clienteDAO.PesqCpf(cliente);
            ViewBag.clientes = lista;
            ViewBag.Cliente = clientePesq;

            var listaNome = clienteDAO.SelecionarTodos();
            listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesN = listaNome;

            var listaCpf = clienteDAO.SelecionarTodos();
            listaCpf.Sort((c1, c2) => c1.Cpf.ToUpper().CompareTo(c2.Cpf.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesC = listaCpf;

            return RedirectToAction("Pesquisar", clientePesq);
        }

        public ActionResult Editar(Cliente cliente)
        {

            ClienteDAO clienteDAO = new ClienteDAO();

            var lista = clienteDAO.SelecionarTodos();
            ViewBag.clientes = lista;
            var clientePesq = clienteDAO.PesqId(cliente);
            ViewBag.Cliente = clientePesq;

            var listaNome = clienteDAO.SelecionarTodos();
            listaNome.Sort((c1, c2) => c1.Nome.ToUpper().CompareTo(c2.Nome.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesN = listaNome;

            var listaCpf = clienteDAO.SelecionarTodos();
            listaCpf.Sort((c1, c2) => c1.Cpf.ToUpper().CompareTo(c2.Cpf.ToUpper()));//Expressão "LAMBDA inline", diretamente como argumento da função Sort
            ViewBag.clientesC = listaCpf;

            return View();
        }

        public ActionResult Adicionar(string nome, string cpf)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Cpf = cpf;

            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.Adicionar(cliente);

            ViewBag.Cliente = cliente;

            return RedirectToAction("Form");
        }

        public ActionResult Delete(int id)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.Delete(id);

            return RedirectToAction("Form");
        }

        public ActionResult Atualizar(Cliente cliente) //o pesquisar tem que ser semelhante
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.Atualizar(cliente);

            ViewBag.Cliente = cliente;

            return RedirectToAction("Form");
        }
    }
}
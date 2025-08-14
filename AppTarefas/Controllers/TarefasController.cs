using System.Security.Cryptography.X509Certificates;
using AppTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefasController : Controller
    {
        // Lista de memória( grava as informações apenas enquanto a aplicação está rodando)
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;

        // GET : Tarefas    
        public IActionResult Index()
        {
            return View(_tarefas); // Envia a lista de tarefas como parametro para a pargina Index
        }

        // GET : Tarefas/Create
        // GET -> Metodo para "pegar" a pagina e exibir
        public IActionResult Create()
        {
            return View();
        }

        // POST : Tarefas/Create
        [HttpPost] // Especifica que este metodo responde a requisições POST
        [ValidateAntiForgeryToken] // Protege contra ataques
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                // Atribui um ID unico para a tarefa
                tarefa.TarefaID = _proximoId++;
                // Adiciona a tarefa a lista de tarefas (_tarefas)
                _tarefas.Add(tarefa);
                // Redireciona para a pagina Index
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        // GET : Tarefas/Edit/1
        public IActionResult Edit(int id)
        {
            // Busca a tarefa pelo ID
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);
            return View(tarefa);
        }

        // POST : Tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;
            return RedirectToAction("Index");
        }

        // GET : Tarefas/Deteils/1
        public IActionResult Details(int id)
        {
            // Busca a tarefa pelo ID
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);
            return View(tarefa);
        }


        //POST: Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa); // Remove a tarefa da lista.
            }
            return RedirectToAction("Index"); // Redireciona para a página de listagem de tarefas.
        }
    }
}
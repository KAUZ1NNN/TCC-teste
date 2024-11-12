using Microsoft.AspNetCore.Mvc;
using TCCteste2.Models;
using System.Collections.Generic;
using System.Linq;

namespace TCCteste2.Controllers
{
    public class CollaboratorController : Controller
    {
        // Lista para armazenar os colaboradores temporariamente (em vez de um banco de dados)
        private static List<Collaborator> collaborators = new List<Collaborator>();

        // Método para exibir a lista de colaboradores
        public IActionResult Index()
        {
            return View(collaborators);
        }

        // Método para exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        // Método para processar o formulário de criação
        [HttpPost]
        public IActionResult Create(Collaborator collaborator)
        {
            collaborator.Id = collaborators.Count + 1;
            collaborators.Add(collaborator);
            return RedirectToAction("Index");
        }

        // Método para exibir o formulário de edição
        public IActionResult Edit(int id)
        {
            var collaborator = collaborators.FirstOrDefault(c => c.Id == id);
            if (collaborator == null)
            {
                return NotFound();
            }
            return View(collaborator);
        }

        // Método para processar o formulário de edição
        [HttpPost]
        public IActionResult Edit(Collaborator collaborator)
        {
            var existingCollaborator = collaborators.FirstOrDefault(c => c.Id == collaborator.Id);
            if (existingCollaborator == null)
            {
                return NotFound();
            }

            existingCollaborator.Name = collaborator.Name;
            existingCollaborator.Email = collaborator.Email;
            existingCollaborator.InsuranceType = collaborator.InsuranceType;

            return RedirectToAction("Index");
        }

        // Método para exibir a confirmação de exclusão
        public IActionResult Delete(int id)
        {
            var collaborator = collaborators.FirstOrDefault(c => c.Id == id);
            if (collaborator == null)
            {
                return NotFound();
            }
            return View(collaborator);
        }

        // Método para processar a exclusão
        [HttpPost]
     public IActionResult DeleteConfirmed(int id)
        {
            var collaborator = collaborators.FirstOrDefault(c => c.Id == id);
            if (collaborator != null)
            {
                collaborators.Remove(collaborator);
            }
            return RedirectToAction("Index");
        }
    }
}

using newEmpty.Models;
using newEmpty.Data;
using Microsoft.AspNetCore.Mvc;

namespace newEmpty.Controllers
{
    public class ProfessorController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
      
        
        public ProfessorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: StudentController
        public IActionResult Index()
        {
            return View(_dbContext.Professors);
        }

        [HttpGet]  
        public IActionResult ShowDetailsProf(int id)
        {
            var professor = _dbContext.Professors.FirstOrDefault(s => s.ProfessorId == id);

            if (professor == null)
            {
                return NotFound();
            }

            ViewBag.professor = professor;
            return View();
        }

        [HttpGet]
        public IActionResult CreateProfessor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            // verification de la validite du model avec ModelState
            if (ModelState.IsValid)
        {
            _dbContext.Add(professor); // L'ID sera généré automatiquement
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Redirige vers l'index après la création
        }

            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Professors); // retourne la vue Index.cshtml avec la nouvelle liste
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            // Return View au sein de l'action Edit retournera la vue Edit.cshtml
            Professor? intrs = _dbContext.Professors.FirstOrDefault<Professor>(ins => ins.ProfessorId == id);

            if (intrs != null)
            {
                return View(intrs);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(Professor professor)
        {
            // verification de la validite du model avec ModelState
            if (!ModelState.IsValid)
            {
                return View();
            }

            Professor? instr = _dbContext.Professors.FirstOrDefault<Professor>(ins => ins.ProfessorId == professor.ProfessorId);

            if (instr != null)
            {
                instr.FirstName = professor.FirstName;
                instr.LastName = professor.LastName;
                instr.Matiere = professor.Matiere;

                _dbContext.SaveChanges();

                // return View("Index", _dbContext.Instructors);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Professor? instr = _dbContext.Professors.FirstOrDefault<Professor>(ins => ins.ProfessorId == id);

            if (instr != null) // Si l'instructeur est trouvé
            {
                return View(instr); // On retourne la vue Delete.cshtml avec l'instructeur à supprimer
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
            //return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int ProfessorId)

        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Professor? instr = _dbContext.Professors.FirstOrDefault<Professor>(ins => ins.ProfessorId == ProfessorId);


            if (instr != null) // Si l'instructeur est trouvé
            {
                _dbContext.Professors.Remove(instr); // On le supprime de la liste
                _dbContext.SaveChanges(); // On sauvegarde les modifications
                // return View("Index", _dbContext.Instructors); // On retourne la vue Index.cshtml avec la nouvelle liste
                return RedirectToAction("Index");
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
        }
    }

}

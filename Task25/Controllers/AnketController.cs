using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Task25.BLL.DTO;
using Task25.BLL.Interfaces.IServices;
using Task25.Models;

namespace Task25.Controllers
{
    public class AnketController : Controller
    {
        IAnketService anketServ;

        public AnketController(IAnketService anketServ)
        {
            this.anketServ = anketServ;
        }

        // GET: Anket
        public ActionResult Index()
        {
            var anketDto = anketServ.GetAnketByName("Main");

            var mapper = MapAnketRec();
            var getAnket = mapper.Map<AnketDTO, AnketViewModel>(anketDto);

            var Response = new AnketResponseViewModel();
            Response.Anket = getAnket;
            Response.FindService = new List<AnswerCheckBoxViewModel>();
            foreach (var item in Response.Anket.Questions.SingleOrDefault(x => x.Name == "FindService")?.AnketChoices)
            {
                Response.FindService.Add(new AnswerCheckBoxViewModel { Option = item.Name, Response = Response });
            }

            return View(Response);

        }


        /// <summary>Create view by POST method</summary>
        /// <param name="response">The response with user entered info</param>
        /// <returns>View of anketing result</returns>
        //[HttpPost]
        public ActionResult Result(AnketResponseViewModel response)
        {
            if (ModelState.IsValidField("BDate") && response.BDate > DateTime.Now.AddYears(-18))
                ModelState.AddModelError("BDate", "Age must be greate than or equal 18");

            var nameRgx = new Regex(@"^[a-zA-Z][a-zA-Z\s`-]+$");
            if (ModelState.IsValidField("FirstName") && !nameRgx.IsMatch(response.FirstName ?? ""))
                ModelState.AddModelError("FirstName", "Name must be only latin alphabet (can use - ` )");

            if (ModelState.IsValidField("SecondName") && !nameRgx.IsMatch(response.SecondName ?? ""))
                ModelState.AddModelError("SecondName", "Surname must be only latin alphabet (can use - ` )");
            
            var anketDto = anketServ.GetAnketByName("Main");
            var mapper = MapAnketRec();
            var getAnket = mapper.Map<AnketDTO, AnketViewModel>(anketDto);

            if (ModelState.IsValidField("OftenVisit") && !getAnket["OftenVisit"].AnketChoices.Select(x => x.Name).Contains(response.OftenVisit))
                ModelState.AddModelError("OftenVisit", "Uncorrect variant of question about often visit(please try to choose again or update page)");
            if (ModelState.IsValidField("Edu") && !getAnket["Edu"].AnketChoices.Select(x => x.Name).Contains(response.Edu))
                ModelState.AddModelError("Edu", "Uncorrect variant of question about education(please try to choose again or update page)");
            if (ModelState.IsValidField("EmploymentStatus") && !getAnket["EmploymentStatus"].AnketChoices.Select(x => x.Name).Contains(response.EmploymentStatus))
                ModelState.AddModelError("EmploymentStatus", "Uncorrect variant of question about employment status(please try to choose again or update page)");
            if (ModelState.IsValidField("FindService") && (response.FindService is null || response.FindService.Where(x => x.State).Count() == 0 ||
                getAnket["FindService"].AnketChoices.Select(x => x.Name).Intersect(response.FindService.Select(x => x.Option)).Count() != response.FindService.Select(x => x.Option).Count()))
                ModelState.AddModelError("FindService", "Uncorrect variant of question about how did you find out about lib(please try to choose again or update page)");

            if (!ModelState.IsValid)
            {
                response.Anket = getAnket;
                return View("Index", response);
            }
            response.AnketId = getAnket.Id;

            var mapperResp = new MapperConfiguration(cfg => {   
                cfg.CreateMap<AnketResponseViewModel, AnketResponseDTO>();
                cfg.CreateMap<AnswerCheckBoxViewModel, AnswerCheckBoxDTO>(); 
            }).CreateMapper();
            var responseDTO = mapperResp.Map<AnketResponseViewModel, AnketResponseDTO>(response);
            
            anketServ.AddResponse(responseDTO);


            return View(response);
        }

        #region Services
        IMapper MapAnketRec()
        {
             var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<AnketDTO, AnketViewModel>();
                cfg.CreateMap<AnketChoiceDTO, AnketChoiceViewModel>();
                cfg.CreateMap<AnketQuestionDTO, AnketQuestionViewModel>();
                cfg.CreateMap<AnketResponseDTO, AnketResponseViewModel>();
                cfg.CreateMap<AnswerCheckBoxDTO, AnswerCheckBoxViewModel>();
                cfg.CreateMap<QuestionTypeDTO, QuestionTypeViewModel>();
            }).CreateMapper();

            return mapper;
        }

        public JsonResult SurnameValidate(string SecondName)
        {
            var nameRgx = new Regex(@"^[a-zA-Z][a-zA-Z\s`-]+$");
            if(!nameRgx.IsMatch(SecondName ?? ""))
                return Json("remote - Surname must be only latin alphabet (can use - ` )", JsonRequestBehavior.AllowGet);
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}
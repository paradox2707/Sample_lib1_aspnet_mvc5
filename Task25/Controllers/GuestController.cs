using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task25.BLL.Interfaces.IServices;
using Task25.BLL.DTO;
using AutoMapper;
using Task25.Models;
using System.Text.RegularExpressions;
using Task25.Models.Pagination;

namespace Task25.Controllers
{
    public class GuestController : Controller
    {
        ICommentService commentService;

        public GuestController(ICommentService commentSer)
        {
            commentService = commentSer;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {            
            var commentDtos = commentService.GetAllCommentsSortByDesc(x => x.Date);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);
            int pageSize = 5;
            IEnumerable<CommentViewModel> commentPerPages = comments.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = comments.Count };
            PageCommentsViewModel commentsVM = new PageCommentsViewModel { PageInfo = pageInfo, Comments = commentPerPages };
            var comment = new CommentViewModel();
            comment.PageComments = commentsVM;
            return View(comment);
        }

        /// <summary>Create view by POST method</summary>
        /// <returns>View of Comments</returns>
        [HttpPost]
        public ActionResult Index(CommentViewModel comment)
        {
            List<CommentViewModel> listOfComments;
            comment.Date = DateTime.Now;

            var nameRgx = new Regex(@"^[a-zA-Z][a-zA-Z\s`-]+$");
            if (ModelState.IsValidField("Author") && !nameRgx.IsMatch(comment.Author ?? ""))
                ModelState.AddModelError("Author", "Name must be only latin alphabet (can use - ` )");

            if (ModelState.IsValidField("Text") && (comment.Text ?? "").Replace("\t", " ").Trim() == String.Empty)
                ModelState.AddModelError("Text", "Comment is empty or incorrect");

            IEnumerable<CommentDTO> commentDtos;
            IMapper mapper;
            List<CommentViewModel> comments;

            int pageSize = 5;
            IEnumerable<CommentViewModel> commentPerPages;
            PageInfo pageInfo;
            PageCommentsViewModel commentsVM;

            if (!ModelState.IsValid)
            {
                commentDtos = commentService.GetAllCommentsSortByDesc(x => x.Date);
                mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
                comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);

                commentPerPages = comments.Skip(0).Take(pageSize);
                pageInfo = new PageInfo { PageNumber = 1, PageSize = pageSize, TotalItems = comments.Count };
                commentsVM = new PageCommentsViewModel { PageInfo = pageInfo, Comments = commentPerPages };
                comment.PageComments = commentsVM;
                return View(comment);
            }

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, CommentDTO>()).CreateMapper();
            CommentDTO commentMap = mapper.Map<CommentViewModel, CommentDTO>(comment);
            commentService.Add(commentMap);

            commentDtos = commentService.GetAllCommentsSortByDesc(x => x.Date);
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            comments = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);

            commentPerPages = comments.Skip(0).Take(pageSize);
            pageInfo = new PageInfo { PageNumber = 1, PageSize = pageSize, TotalItems = comments.Count };
            commentsVM = new PageCommentsViewModel { PageInfo = pageInfo, Comments = commentPerPages };
            comment.PageComments = commentsVM;

            ModelState.Clear();
            return View(comment);
        }

    }
}

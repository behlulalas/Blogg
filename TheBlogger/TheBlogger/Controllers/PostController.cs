using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using TheBlogger.ViewModel;
using TheBlogger.Models.Comments;

namespace TheBlogger.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PostController(IPostRepository postRepository, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _postRepository = postRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult AddPost()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(Post post)
        {
            // ModelState nesnesini temizliyoruz
            ModelState.Clear();
            // formda eksik olan kullanıcı alanını dolduruyoruz
            post.user = await _userManager.GetUserAsync(HttpContext.User);
            // formu tekrar doğruluyoruz
            TryValidateModel(post);
            if (ModelState.IsValid)
            {
                _postRepository.AddPost(post);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> RemovePost(int id)
        {
            // giriş yapan kullanıcıyı alıyoruz
            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                // ilgili post giriş yapan kullanıcıya mı ait?
                if (_postRepository.GetPost(id).user == user)
                    _postRepository.RemovePost(id);
                else
                    return NotFound("404 Sayfa Bulunamadı");
            }
            catch (Exception e)
            {
                return NotFound("404 Sayfa Bulunamadı");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> UpdatePost(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var post = _postRepository.GetPost(id);
            if (post == null) return NotFound("404 Sayfa Bulunamadı");
            if (post.user != user) return NotFound("404 Sayfa Bulunamadı");
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            ModelState.Clear();
            post.user = await _userManager.GetUserAsync(HttpContext.User);
            TryValidateModel(post);
            if (ModelState.IsValid)
            {
                _postRepository.UpdatePost(id, post);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        public async Task<IActionResult> MyPosts()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(_postRepository.GetByUser(user));
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {

            var temp = vm.UserName;
            if (!ModelState.IsValid)
            {


                return RedirectToAction("post", temp, new { id = vm.PostId });
            }
            var post = _postRepository.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,
                    UserName = _userManager.GetUserName(User),
                });
                _postRepository.UpdatePost2(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now,
                    UserName = _userManager.GetUserName(User),
                };
                _postRepository.AddSubComment(comment);
            }
            await _postRepository.SaveChangesAsync();
            return RedirectToAction("post", temp, new { id = vm.PostId });


        }
    }
}
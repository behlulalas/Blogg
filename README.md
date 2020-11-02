# The Blogger

The blogger ASP .NET Core ile kodlanmış kişisel bir blog sitesidir.

## Kurulum


```bash
Repository klonladıktan sonra Microsoft Visual Studio 2017 de açarak projeyi çalıştırabilirsiniz
```

## Projede Kullanılan Teknolojiler:

```bash
Visual Studio 2017
.NET Core 2.1
Entity Framework
SQL Lite
```
## Projenin özellikleri
```bash
-Authorization
-Authentication
-AddPost
-RemovePost
-UpdatePost
-UpdatePostState
-CommentSection
-SubCommentSection
``` 
## Proje Demosu:

Demo:http://theblogger.somee.com/

## Projenin yapım aşaması
Öncelikle Visual Studio üzerinden TheBlogger adında boş(empty) bir Asp.Net Core Web Application projesi başlatıyorum.

![Screen](https://github.com/behlulalas/Blogg/blob/master/images/1.png)

Bizi yukarıdaki gibi bir bomboş bir çözüm gezgini karşılayacak. Burada NuGet, paket yöneticisi oluyor. NuGet yardımıyla yüklediğimiz paketler NuGet altına yerleşerek projemize dahil oluyor. NuGetten paket yüklemek için proje adına sağ tıklayıp Manage Nuget Packages seçeneğini seçiyoruz. wwwroot klasörü altına js, css dosyalarımız veya kullanıcıdan alacağımız resim, fotoğraf gibi dosyaları koyabiliriz. 2 adet ise cs dosyamız var bunlardan Program.cs bizim main fonksiyonumu içeren sınıfı barındırıyor. Startup.cs ise projemizin ayarlarını yaptığımız sınıfı içeriyor.

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace TheBlogger
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
``` 
Yukarıdaki gibi gelen sınıfın içeriği aşağıdaki gibi düzenliyoruz.
```C#
public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();  // Mvc yapısını ekledik
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(); // Mvc yapısını kullanılabilir kıldık
            app.UseStaticFiles(); // wwwroot altında static dosyalarını araması için
            app.UseMvcWithDefaultRoute(); // default link yönlendirme yapısını kullanmasını sağladık

        }
    }
``` 
Burada app.Run fonksiyonun bir önemi olmadığı için sildim, diğer adımların ne olduğu ise zaten yazıyor. Şimdi proje ana dizini içinde Models, Views ve Controllers adında 3 klasör oluşturalım.
Controllers dizinine sağ tıklayıp Add Controller diyelim ve Empty Controller seçelim. İsim olarak ise HomeController yazalım.
Visual Studio benim için bir controller sınıfı oluşturdu ve içersine Index adında IActionResult tipini geri döndüren bir fonksiyon ekledi. 

Bu fonksiyon Views/Home/ dizini aldında Index.cshtml adındaki dosyayı render edip tarayıcımızda gösterebiliyor. Dosylarımızı aşağıdaki şekilde düzenleyelim.
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheBlogger.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using 

@{
    ViewData["Title"] = "Index";
}

<h2>Merhaba Dünya</h2>
```

Index.cshtml dosyasını otomatik oluşturmak için Index Fonksiyonuna sağ tıklayıp Add View seçeneğini seçebilirsiniz.

Projeyi çalıştırdığınızda ekranda Merhaba Dünya yazısını göreceksiniz. Hemen controller sınıfımıza bir fonksiyon daha ekleyelim ve sonucu görelim.
```C#
@{
    ViewData["Title"] = "Deneme";
}

<h2>Deneme</h2>
```
```C#
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
```
Projemizi çalıştıırdığımızda bizi Merhaba Dünya yazan ekran karşılayacak. Eğer adres çubuğuna /Home/Index yazarsanız yine Merhaba Dünya yazan aynı ekrana gidersiniz. /Home/Deneme yazarsanız ise içerisinde Deneme yazan ekrana ulaşırsınız. Tüm bu işlemi yapan şey startup.cs dosyasında tanımladığımız app.UseMvcWithDefaultRoute(); satırıdır.

Bu satır sayesinde projemizdeki Controller Sınıflarının isimleri linkin ilk parçasını sınıf içindeki fonksiyonlar ise linkin ikinci parçasını tutar böylece istenen action link girilerek doğru şekilde çağırılır.

Biz hiç bişey yazmadığımız halde Home/Index linkine gittiğini de gözden kaçırmamak gerek. Tüm bu ayarlar değiştirilebilir ve ilerleyen yazılarda bunlarla nasıl oynayabileceğimizi göreceğiz.

Deneme fonksiyonu ve Deneme.cshtml dosyalarını silebilirsiniz bir sonraki ders bu dosyaları kullanmayacağım sadece link yönlendirme yapısını göstermek için kullandım.

### Bootstrap Eklemek

Şimdi projemize bir tasarım ekleyeceğiz bunun için tasarım sitelerinde bulunan hazır bootstrap tasarımlardan birini kullancağım.

Tasarım Linki:https://themes.3rdwavemedia.com/download/1842/

Yukarıya linkini bıraktığım tasarımı kullancağım. Bunun için yukarıdaki linkten indirip zip içindeki assets dosyasını wwwroot klasörüne atalım.

Daha sonra Views klasörü altında Shared isimli bir klasör daha oluşturup içerisine _Layout.cshtml isimli bir dosya oluşturuyoruz. Ardından aşağıdaki gibi düzenleme yapıyoruz.
```CSHTML
<!DOCTYPE html>
<html lang="en">
<head>
    <title>The Blogger</title>

    <!-- Meta -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Blog Template">
    <meta name="author" content="The Blogger">
    <link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico">

    <link href="~/css/Comments.css" rel="stylesheet" />
    <!-- FontAwesome JS-->
    <script defer src="~/assets/fontawesome/js/all.min.js"></script>

    <!-- Theme CSS -->
    <link id="theme-style" rel="stylesheet" href="~/assets/css/theme-2.css">

</head>

<body>

    <header class="header text-center">
        <h1 class="blog-name pt-lg-4 mb-0"><a href="~/Home/Index">The Blogger</a></h1>

        <nav class="navbar navbar-expand-lg navbar-dark">

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navigation" aria-controls="navigation" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div id="navigation" class="collapse navbar-collapse flex-column">
                <div class="profile-section pt-3 pt-lg-0">
                    <ul class="social-list list-inline py-3 mx-auto">
                        <li class="list-inline-item"><a href="#"><i class="fab fa-twitter fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-linkedin-in fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-github-alt fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-stack-overflow fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-codepen fa-fw"></i></a></li>
                    </ul><!--//social-list-->
                  
                    <hr>
                </div><!--//profile-section-->
                <ul class="navbar-nav flex-column text-left">
                    <li class="nav-item">
                        <a class="nav-link" href="~/Home/Index"><i class="fas fa-home fa-fw mr-2"></i>Blog Home <span class="sr-only">(current)</span></a>
                    </li>
                    
                       
                            <li class="nav-item">
                                <a class="nav-link" href="~/Admin/Home"><i class="fas fa-user-astronaut fa-fw mr-2"></i>Admin Paneli <span class="sr-only">(current)</span></a>
                            </li>

                        <li class="nav-item">
                            <a class="nav-link" href="~/Post/AddPost"><i class="fas fa-plus fa-fw mr-2"></i>Yazı Ekle <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="~/Post/MyPosts"><i class="fas fa-pen-fancy fa-fw mr-2"></i>Yazılarım <span class="sr-only">(current)</span></a>
                        </li>
                 
                        <li class="nav-item">
                            <a class="nav-link" href="~/Account/Register"><i class="fas fa-bookmark fa-fw mr-2"></i>Kayıt Ol</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="~/Account/Login"><i class="fas fa-user fa-fw mr-2"></i>Giriş Yap</a>
                        </li>

                </ul>
            </div>
        </nav>
    </header>

    @RenderBody()


    <script src="~/assets/plugins/jquery-3.4.1.min.js"></script>
    <script src="~/assets/plugins/popper.min.js"></script>
    <script src="~/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="~/assets/js/demo/style-switcher.js"></script>


    <script>
        $(document).ready(function () {
            $('.navbar-nav.flex-column.text-left').find('[href="' + window.location.pathname + '"]').parent().addClass('active');
        });
    </script>
</body>
</html>
```


```CSHTML

@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
                <div class="item mb-5">
                    <div class="media">
                        <img class="mr-3 img-fluid post-thumb d-none d-md-flex" src="~/assets/images/blog/blog-post-thumb-1.jpg" alt="image">
                        <div class="media-body">
                            <h3 class="title mb-1"><a href=""></a></h3>
                            <div class="meta mb-1"><span class="date"></span><span class="user-block"></span></div>
                            <div class="intro">
                            </div>
                            <a class="more-link" href="/@item.user/post/@item.id">Daha Fazla &rarr;</a>
                        </div><!--//media-body-->
                    </div><!--//media-->
                </div><!--//item-->
        </div>
    </section>
</div><!--//main-wrapper-->
```
Projeyi çalıştırdığınızda herşeyin düzgün olduğunu göreceksiniz. bu işlem bizi sürekli temayı tekrar etmekten kurtardı. Bundan sonra oluşturacağımız her dosyada Layout olarak _Layout dosyasını göstermemiz yeterli. Index.cshtml içersine yazdığımız kodlar ise _Layout.cshtml dosyasındaki RenderBody() fonksiyonunun olduğu yere eklenerek çalıştırılır.


Eğer tüm dosyalarda tek tek Layout belirtmek istemiyorsak Views klasörü içine _ViewStart.cshtml adında bir dosya eklemek ve içeriğini aşağıdaki gibi düzenlemek yeterli.

```C#
@{
    Layout = "_Layout";
}
```
Bu noktadan sonra oluşturduğunuz cshtml uzantılı dosyalara Layout vermeniz gerekmez. DotNet Core sizin için bu bağlantıyı gerçekleştirecektir.


### Model Eklemek

Modeller veritabanı ile ilişki kurmamızı sağlar. Bu yazıda gerçek bir veritabanı ile bağlantı kurmadan basit bir şekilde model tanımlayacak, sahte bir şekilde veri ekleyip sileceğiz.


Öncelikle models klasörümüze Post adında bir sınıf ekleyeceğiz bu sınıf bizim verimizi tanımlayacak. Ardından bu veri tipi ile veri tabanı arasında bağlantı kuracak bir repository yazacağız. Tabi bu yazıda veritabanı yerine List<Post> veri yapısıyla bağlantı kuracak ama sonraki derslerde veritabanı bağlantısını yapacağız.

IPostRepository.cs
```C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void RemovePost(int id);
    }
}
```
Post.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        
    }
}

```
PostRepository.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models
{
    public class PostRepository: IPostRepository
    {
        List<Post> posts = new List<Post>();

        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return posts;
        }

        public Post GetPost(int id)
        {
            Post temp = posts.FirstOrDefault(i => i.id == id);
            return temp;
        }

        public void RemovePost(int id)
        {
            Post temp = posts.FirstOrDefault(i => i.id == id);
            posts.Remove(temp);
        }
    }
}
```
Burada öncelikle Post sınıfı ile verimizi tanımladık ardından PostRepository için interface yazdık ve ardından PostRepository sınıfı ile implemente ettik.

Kabaca bakacak olursak PostRepository sınıfında içerisinde Post nesnelerini tutan bir liste(List<Post>) var. Sınıf içindeki fonksiyonlar ise bu veri tipine veri ekleme silme ve veriyi döndürme gibi işlemler yapıyor. Bu fonksiyonların içeriği çok basit olduğu için anlatmaya gerek duymuyorum.

Gelinen noktada verilerin veritabanına değil belleğe yazıldığını dolayısıyla server her çalıştırıldığında List<Post> yapısının içerisinin boş olacağını unutmamalıyız.

Şimdi ise HomeController içerisinde birkaç veri ekleyip alarak sistemin çalışıp çalışmadığını test edelim.

HomeController.cs
```C#
   public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // repository nesnesinden bir örnek alıyoruz
            PostRepository repo = new PostRepository();
            // bir post nesnesi oluşturuyoruz
            var obj = new Post
            {
                id = 1,
                title = "Test",
                content = "Test"
            };
            // nesneyi kayıt ediyoruz
            repo.AddPost(obj);
            // ikinci bir post nesnesi oluşturuyoruz
            var obj2 = new Post
            {
                id = 2,
                title = "Test2",
                content = "Test2"
            };
            // obj2 nesnesini kayıt ediyoruz
            repo.AddPost(obj2);
            // obj3 içerisine id'si 1 olan nesneyi atıyoruz
            var obj3 = repo.GetPost(1);
            // ViewData ile obj3 içindeki değeri html içerisinde çağırmak için kayıt ediyoruz
            ViewData["secilenNesne"] = obj3;
            
            // View'e farklı veri tipleri geçerek cshtml içerisinde
            // ekrana basabiliriz
            return View(repo.GetAllPosts());
        }

    }
```
Index.cshtml
```C#

// Model liste tipli bir değişken olduğu için tek tek içerisindeki değerleri alıyoruz
@model IEnumerable<Post>
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            @foreach (var item in Model)
            {
                <div class="item mb-5">
                    <div class="media">
                        <img class="mr-3 img-fluid post-thumb d-none d-md-flex" src="~/assets/images/blog/blog-post-thumb-1.jpg" alt="image">
                        <div class="media-body">
                            <h3 class="title mb-1"><a href="/@item.user/post/@item.id">@item.title</a></h3>
                            <div class="meta mb-1"><span class="date"></span><span class="user-block"></span></div>
                            <div class="intro">

                                @{
                                    string icerik = "";
                                    if (item.content.Length <= 15)
                                    {
                                        icerik = item.content;
                                    }
                                    else
                                    {
                                        icerik = item.content.Substring(0, 15);
                                    }
                                }
                                @Html.Raw(icerik)   ...
                            </div>
                            <a class="more-link" href="/@item.user/post/@item.id">Daha Fazla &rarr;</a>
                        </div><!--//media-body-->
                    </div><!--//media-->
                </div><!--//item-->
            }


        </div>
    </section>
</div><!--//main-wrapper-->
```
cshtml dosyaları içerisinde @ işaretini kullanarak c# kodları çalıştırdığımızı fark etmişsinizdir.


Sonuç ise beklediğim gibi:

![Screen](https://github.com/behlulalas/Blogg/blob/master/images/2.png)

### Entity Framework Core


Entity Framework Core veritabanı ile alakalı bağlantıyı yapan ve veriyi manipüle ederken kullanılan bir kütüphanedir. Genelde DotNet Core ile birlikte MsSql kullanımı anlatılsada ben basit bir dosya tabanlı veritabanı olan sqlite ile bağlantı kurup verileri bunun üzerine yazacağım.

Öncelikle Nuget üzerinden Microsoft.EntityFrameworkCore.Sqlite isimli paketi kuruyoruz. Bu işi visual studioda proje üzerine sağ tıklayıp Nuget Paketlerini Yönet seçeneğini seçip kolayca yapabilirsiniz.

Ardından Models klasörü altında AppDbContex adlı bir sınıf oluşturuyoruz ve Startup.cs dosyasına aşağıdaki iki servisi ekliyoruz.



Startup.cs
```C#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


public void ConfigureServices(IServiceCollection services)
        {
             // veritabanı bilgileri
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=blog.db"));
            // DependencyInjection için 
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddMvc();
        }
        
```
AppDbContext içerisindeki post değişkeni veritabanından alınan verileri temsil ediyor.


Artık PostRepository dosyasını da veritabanı bağlantısına göre düzenlememiz gekecek. Daha önce List<Post> için tasarladığımız yapıyı bu kez DbSet<Post> için düzenleyeceğiz.

Postlarımızın daha professyonel gözükmesi için yeni alanlar eklenecek eklenmeden önce postlarımıza yorum atılabilmesi için models klasörü içerisine Comments klasörü ekleyip içerisine 3 Model daha eklenecek...

Comment.cs
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }

    }
}

```
MainComment.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models.Comments
{
    public class MainComment : Comment
    {
        public List<SubComment> subComments { get; set; }
    }
}

```
SubComment.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.Models.Comments
{
    public class SubComment : Comment
    {
        public int MainCommentId { get; set; }
    }
}

```
Post.cs
```C#
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TheBlogger.Models.Comments;

namespace TheBlogger.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public List<MainComment> MainComments { get; set; }
        public IdentityUser user { get; set; }
        public int PostState { get; set; } = 0;
    }
}

```
AppDbContext.cs
```C#
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheBlogger.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TheBlogger.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Post> posts { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }

    }
}
```
DotNet Core bizim için kullanıcı işlemlerini kolaylaştıran bir paket sunuyor bu yüzden bizim oturup sıfırdan bir kullanıcımı yönetimi yazmamıza gerek yok. 
Database yapımızı Authorization için de Microsofta ait olan IdentityUser sınıfını kullanarak modelimize dahil ettik.


Startup.cs dosyasına gidip ConfigureServices fonksiyonunu
```C#
services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
```




Configure fonksiyonuna ise
```C#
app.UseAuthentication();
```


Şimdi migration işlemlerini yapalım. Nuget Paket Yöneticisi Konsolunu açıyoruz ve

```C#
add-migration Identity
update-database
```
komutlarını sırasıyla veriyoruz. Identity yerine istediğiniz başka bir şeyi yazabilirsiniz.
![Screen](https://github.com/behlulalas/Blogg/blob/master/images/3.png)


## Login  -  Register 

Bu noktadan sonra sisteme üye kaydı alma ve login olma özelliklerini ekleyeceğiz. Bunun için öncelikle AccountController adında bir controller oluşturalım.

AccountController.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogger.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBlogger.Models;

namespace TheBlogger.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public AccountController(IPostRepository postRepository, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _postRepository = postRepository;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                // Girilen kullanıcı adına sahip kullanıcı varse user değişkenine atıyoruz
                var user = await _userManager.FindByNameAsync(obj.username);

                // eğer kullanıcı varsa if içerisine giriyoruz
                if (user != null)
                {
                    // kullanıcı girişi yapıyoruz
                    var result = await _signInManager.PasswordSignInAsync(user, obj.password, false, false);

                    // eğer giriş ilemi başarılıysa anasayfaya yönlendiriyoruz
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                // böyle bir kullanıcı yoksa geriye hata döndürüyoruz
                // ilk parametre key ikinci parametre value
                ModelState.AddModelError("", "Kullanıcı adı veya Parola hatalı.");
                return View(obj);
            }
            return View(obj);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Login obj)
        {
            if (ModelState.IsValid)
            {
                // yeni bir kullanıcı nesnesi oluşturuyoruz
                var user = new IdentityUser()
                { UserName = obj.username };
                // oluşturulan kullanıcıyı parola(hash) ile birlikte kayıt ediyoruz
                var result = await _userManager.CreateAsync(user, obj.password);

                var isEmailAlreadyExists = _userManager.FindByNameAsync(obj.username);
                // kayıt işlemi başarılı ise Login sayfasına yönlendiriyoruz
                if (result.Succeeded)
                {
                    var result2 = await _signInManager.PasswordSignInAsync(user, obj.password, false, false);

                    // eğer giriş ilemi başarılıysa anasayfaya yönlendiriyoruz
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (isEmailAlreadyExists != null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten var");
                }


                return View(obj);
            }
            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
```
Login.cs
```C#
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.ViewModel
{
    public class Login
    {
        [Required]
        [Display(Name = "Kullanıcı Adınız")]
        public string username { get; set; }
        [Required]
        [Display(Name = "Parolanız")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = " {0} 6 karakterden az olmamalıdır.", MinimumLength = 6)]
        public string password { get; set; }
    }
}

```
Login.cshtml
```C#
@model TheBlogger.ViewModel.Login

@{
    ViewData["Title"] = "Login";
}
<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            <h2>Giriş Yap</h2>

            <hr />
            <div class="row">
                <div class="col-md-4">
                    <form asp-action="Login" method="post">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <div class="form-group">
                            <label asp-for="username" class="control-label"></label>
                            <input asp-for="username" class="form-control" />
                            <span asp-validation-for="username" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <label asp-for="password" class="control-label"></label>
                            <input asp-for="password" class="form-control" />
                            <span asp-validation-for="password" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Giriş Yap" class="btn btn-success" />
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</div>
```
Register.cs
```C#
@model TheBlogger.ViewModel.Login

@{
    ViewData["Title"] = "Register";
}
<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            <h2>Kayıt Ol</h2>
            <hr />
            <div class="row">
                <div class="col-md-4">
                    <form asp-action="Register" method="post">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <div class="form-group">
                            <label asp-for="username" class="control-label"></label>
                            <input asp-for="username" class="form-control" />
                            <span asp-validation-for="username" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <label asp-for="password" class="control-label"></label>
                            <input asp-for="password" class="form-control" />
                            <span asp-validation-for="password" class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Kayıt Ol" class="btn btn-success" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</div>
```

İlk bahsetmek istediğim Login.cs dosyası bu dosyayı ViewModels adında bir klasör altına oluşturdum. ViewModeller veritabanına kayıt edilmeyen, formları binding ederken ihtiyaç duyduğumuz modellerdir. Bu sebeple normal modellerle karışmamaları için ayrı bir klasörde tutmakta fayda var. Ayrıca yine bu dosyada zorunlu alanları nasıl [Required] ile belirttiğimize dikkat edin. DataAnnotations ile ilgili daha detaylı bilgi için şu linki kullanabilirsiniz.

Register.cshtml ve Login.cshtml dosyalarını anlatmaya zaten gerek yok her şey ortada...


AccountController ile ilgili açıklamaları ise kod üzerinde yorum satırı olarak yapmaya çalıştım. Dikkatinizi çektiyse eğer kayıt işlemi için ayrı bir ViewModel yazmadım login için yazdığımı kullandım siz isterseniz veritabanındaki mail, telefon numarası gibi diğer alanlarıda içeren bir model yazıp kullanabilirsiniz.

Gelelim giriş yapan kullanıcıyı navbarda göstermeye, öncelikle _layout.cshtml dosyanızın 

Bu Projede Hem User Side Hem Admin Side olduğu için giriş yapan kişi admin ise navbarda gözükecek menüde farklılıklar olacaktır...

_Layout.cshtml
```C#
@inject SignInManager<IdentityUser> SignInManager
```

ekleyip. Navbarda uygun gördüğünüz bir yere de aşağıdaki kodu ekleyin


_Layout.cshtml
```C#
 <div id="navigation" class="collapse navbar-collapse flex-column">
                <div class="profile-section pt-3 pt-lg-0">
                    <ul class="social-list list-inline py-3 mx-auto">
                        <li class="list-inline-item"><a href="#"><i class="fab fa-twitter fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-linkedin-in fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-github-alt fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-stack-overflow fa-fw"></i></a></li>
                        <li class="list-inline-item"><a href="#"><i class="fab fa-codepen fa-fw"></i></a></li>
                    </ul><!--//social-list-->
                    @if (SignInManager.IsSignedIn(User))
                    {
                        <a>@User.Identity.Name</a>
                        <a style="color:aliceblue!important" href="~/Account/Logout">Logout</a>
                    }
                    else
                    {
                        //

                    }
                    <hr>
                </div><!--//profile-section-->
                <ul class="navbar-nav flex-column text-left">
                    <li class="nav-item">
                        <a class="nav-link" href="~/Home/Index"><i class="fas fa-home fa-fw mr-2"></i>Blog Home <span class="sr-only">(current)</span></a>
                    </li>
                    @if (SignInManager.IsSignedIn(User))
                    {
                        @if ((await AuthorizationService.AuthorizeAsync(User, "Admin")).Succeeded)
                        {
                            <li class="nav-item">
                                <a class="nav-link" href="~/Admin/Home"><i class="fas fa-user-astronaut fa-fw mr-2"></i>Admin Paneli <span class="sr-only">(current)</span></a>
                            </li>

                        }
                        <li class="nav-item">
                            <a class="nav-link" href="~/Post/AddPost"><i class="fas fa-plus fa-fw mr-2"></i>Yazı Ekle <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="~/Post/MyPosts"><i class="fas fa-pen-fancy fa-fw mr-2"></i>Yazılarım <span class="sr-only">(current)</span></a>
                        </li>
                    }
                    else
                    {
                        <li class="nav-item">
                            <a class="nav-link" href="~/Account/Register"><i class="fas fa-bookmark fa-fw mr-2"></i>Kayıt Ol</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="~/Account/Login"><i class="fas fa-user fa-fw mr-2"></i>Giriş Yap</a>
                        </li>

                    }
                </ul>
            </div>
```

if bloğu kullanıcı giriş yapmışsa adını ekrana basar ve bir logout linki koyar ve kullanıcıya ait bazı sayfalar navbara eklenir, else bloğu ise login ve register linklerini ekrana basar.

Burdan sonra gidip Startup.cs Dosyamızdaki Configure Alanına Şu Rol kontrolü Policy ını yazmamız gerekir.
Startup.cs
```C#
 services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Admin");
                    });
            });
```
Böylelikle Giriş yapan kişi eğer admin ise Soldaki menüde admin paneline giden bir link eklenecektir.

![Screen](https://github.com/behlulalas/Blogg/blob/master/images/4.png)


-PostAdd
-PostRemove
-PostUpdate
-GetAllPost

işlemleri için IPostRepository.cs ve PostRepository.cs dosyasını aşşağıdaki gibi düzenliyoruz...

IPostRepository.cs
```C#
public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetPost(int id);
        List<Post> GetAllPosts();
        void RemovePost(int id);
        void UpdatePost(int id, Post post);
        void UpdatePost2(Post post);
        void UpdatePostState(int id, Post post);
        int GetStatePost(int id);
        List<Post> GetByUser(IdentityUser user);
        void AddSubComment(SubComment comment);
        Task<bool> SaveChangesAsync();

    }
```

PostRepository.cs
```C#
public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPost(Post post)
        {
            _appDbContext.posts.Add(post);
            _appDbContext.SaveChanges();
        }

        public List<Post> GetAllPosts()
        {
            return _appDbContext.posts.Include(c => c.user).Where(x => x.PostState == 1).ToList<Post>();
        }

        public List<Post> GetByUser(IdentityUser user)
        {
            var temp = _appDbContext.posts.Include(i => i.user).ToList<Post>();
            foreach (var i in temp.ToArray())
            {
                if (i.user != user) temp.Remove(i);
            }
            return temp;
        }




        public Post GetPost(int id)
        {
            return _appDbContext.posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.subComments)
                .FirstOrDefault(p => p.id == id);
        }
        public int GetStatePost(int id)
        {
            int poststate = 1;
            var temp = GetPost(id);
            if (temp != null)
            {
                poststate = temp.PostState;
            }
            return poststate;
        }

        public void RemovePost(int id)
        {
            Post temp = _appDbContext.posts.FirstOrDefault(i => i.id == id);
            _appDbContext.posts.Remove(temp);
            _appDbContext.SaveChanges();
        }

        public void UpdatePost(int id, Post post)
        {
            var temp = GetPost(id);
            temp.title = post.title;
            temp.content = post.content;
            _appDbContext.Update(temp);
            _appDbContext.SaveChanges();
        }
        public void UpdatePost2(Post post)
        {
            _appDbContext.posts.Update(post);
        }
        public void UpdatePostState(int id, Post post)
        {
            var temp = GetPost(id);
            temp.PostState = 1;
            _appDbContext.Update(temp);
            _appDbContext.SaveChanges();
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _appDbContext.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddSubComment(SubComment comment)
        {

            _appDbContext.SubComments.Add(comment);
        }
    }
```

Bu işlemleri yaptıktan sonra PostController adında bir Controller ekliyip şu şekilde düzenliyoruz:

PostController.cs
```C#
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
```
Anasayfa kısmında postlara tıkladığımızda post içeriğini görüntülemek için HomeController ı aşşağıdaki gibi düzenleyip Views>Home Klasörüne PostOfUser.cshtml dosyasyını ekliyoruz. ayrıca yorum eklemek için _CommentAdd.cshtml adında bir view ekliyoruz ve aşşağıdaki gibi düzenliyoruz

HomeController.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBlogger.Models;
using Microsoft.AspNetCore.Identity;

namespace TheBlogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository repo;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IPostRepository postRepository, UserManager<IdentityUser> userManager)
        {
            repo = postRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(repo.GetAllPosts());
        }

        [Route("{username}")]
        public async Task<IActionResult> PostsofUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("404 Sayfa Bulunamadı");
            var temp = repo.GetByUser(user);
            return View("Index", temp);
        }

        [Route("{username}/post/{id?}")]
        public IActionResult PostofUser(string username, int id)
        {
            if (repo.GetStatePost(id) != 0)
            {
                return View(repo.GetPost(id));
            }
            else
            {
                return NotFound("Post yayınlanmak için onaylanmadı... !");

            }
        }


    }
}
```
PostofUser.cshtml
```C#
@model TheBlogger.Models.Post
@{
    ViewData["Title"] = "PostofUser";

}
@{int j = 0;}
@{int k = 0;}
@foreach (var c in Model.MainComments)
{
    j++;
    foreach (var sc in c.subComments)
    {
        k++;
    }
}
@{
    int toplamyorum = j + k;
}
<div class="main-wrapper">
    @{
        string Tarih = Model.TimeStamp.ToShortDateString();
        string Saat = Model.TimeStamp.ToShortTimeString();
    }
    <article class="blog-post px-3 py-5 p-md-5">
        <div class="container">
            <header class="blog-post-header">
                <h2 class="title mb-2">@Html.DisplayFor(model => model.title)</h2>
                <div class="meta mb-3"><span class="date">Tarih: @Tarih</span><span class="time">Saat: @Saat</span><span class="comment">Yorum (@toplamyorum)<a href="#"></a></span></div>
            </header>

            <div class="blog-post-body">

                @Html.Raw(Model.content)
            </div><!--//blog-comments-section-->
            @{

                await Html.RenderPartialAsync("_CommentAdd", new CommentViewModel() { PostId = Model.id, MainCommentId = 0 });

            }

            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="comments">
                            <div class="comments-details">
                                <span class="total-comments comments-sort">Yorumlar(@toplamyorum)</span>
                                <span class="dropdown">

                                </span>
                            </div>

                            @{int i = 0;}
                            @foreach (var comment in Model.MainComments)
                            {

                                <div class="comment-box">
                                    <span class="commenter-pic">
                                        <img src="https://bootdey.com/img/Content/user_1.jpg" alt="" class="img-fluid">
                                    </span>
                                    <span class="commenter-name">
                                        @if (comment.UserName == null)
                                        {
                                            <a href="#">Misafir</a>
                                        }
                                        else
                                        {
                                            <a href="#">@comment.UserName</a>
                                        } <span class="comment-time">@comment.Created</span>
                                    </span>
                                    <p class="comment-txt more">@comment.Message</p>


                                    <div class="panel-group" id="accordion_@i">
                                        <div class="panel panel-default" id="panel_@i">
                                            <div class="panel-heading">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-target="#collapseOne_@i" href="#collapseOne_@i">
                                                        Yanıtla
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne_@i" class="panel-collapse collapse in">
                                                <div class="panel-body">
                                                    @{
                                                        await Html.RenderPartialAsync("_CommentAdd", new CommentViewModel() { PostId = Model.id, MainCommentId = comment.Id });
                                                    }
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    @foreach (var item in comment.subComments)
                                    {
                                        <div class="comment-box replied">
                                            <span class="commenter-pic">
                                                <img src="https://bootdey.com/img/Content/user_1.jpg" alt="" class="img-fluid">
                                            </span>
                                            <span class="commenter-name">
                                                @if (item.UserName == null)
                                                {
                                                    <a href="#">Misafir</a>
                                                }
                                                else
                                                {
                                                    <a href="#">@item.UserName</a>
                                                }

                                                <span class="comment-time">@item.Created</span>
                                            </span>
                                            <p class="comment-txt more">@item.Message</p>


                                        </div>
                                    }

                                </div>
                                i++;
                            }

                        </div>
                    </div>
                </div>
            </div>

        </div><!--//container-->
    </article>

    <!--//promo-section-->
</div>



```
Yorumları validate etmek için bir view modele ihtiyacımız var onu ekleyip içerisine aşşağıdaki kodları yazıyoruz.


CommentViewModel.cs
```C#
using TheBlogger.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogger.ViewModel
{
    public class CommentViewModel
    {
        public int PostId { get; set; }
        public int MainCommentId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }

        List<MainComment> mainComments { get; set; }
        List<SubComment> subComments { get; set; }
    }
}


```
CommentAdd.cshtml
```C#
@model TheBlogger.ViewModel.CommentViewModel


<div class="container">
    <div class="row">
        <div class="col-12">
            <div class="comments">
                <div class="comments-details">

                    <span class="dropdown">

                    </span>
                </div>
                <div class="comment-box add-comment">
                    <span class="commenter-pic">
                        <img src="https://bootdey.com/img/Content/user_1.jpg" alt="" class="img-fluid">
                    </span>
                    <span class="commenter-name">
                        <form action="~/Post/Comment" method="post">
                            <input asp-for="PostId" type="hidden">
                            <input asp-for="MainCommentId" type="hidden">
                            <input asp-for="Message" type="text" placeholder="Bir yorum yaz">
                            <input asp-for="UserName" type="hidden">

                            <button type="submit" class="btn btn-primary">Yorum Yap</button>
                        </form>
                    </span>
                </div>


            </div>
        </div>
    </div>
</div>


```
PostController içerisindeki AddPost actionu için AddPost.cshtml adlı görünümü ekliyoruz.

AddPost.cshtml
```C#
@model TheBlogger.Models.Post

@{
    ViewData["Title"] = "AddPost";
}

<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <form asp-action="AddPost">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <div class="form-group">
                            <label asp-for="title" class="control-label">Yazı Başlığı</label>
                            <input asp-for="title" class="form-control" />
                            <span asp-validation-for="title" class="text-danger"></span>
                        </div>
                        <div class="form-group">

                            <textarea class="ckeditor" id="ckeditor1" asp-for="content"></textarea>

                        </div>
                        <div class="form-group">
                            <input type="submit" value="Ekle" class="btn btn-primary" />
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </section>
</div>
<script src="~/ckeditor/ckeditor.js"></script>
<script>
    CKEDITOR.replace('ckeditor1', {
    });
</script>
```
CK Editor bir özelleştirilmiş textarea componentidir internetten araştırabilirsiniz.

Sadece Kendi eklediğimiz postlara bakabilmek için oluşturmuş olduğumuz görünüm

MyPosts.cshtml
```C#
@model IEnumerable<Post>
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            @foreach (var item in Model)
            {

                <div class="item mb-5">
                    <div class="media">
                        <img class="mr-3 img-fluid post-thumb d-none d-md-flex" src="~/assets/images/blog/blog-post-thumb-1.jpg" alt="image">
                        <div class="media-body">
                            <h3 class="title mb-1"><a href="/@item.user/post/@item.id">@item.title</a></h3>
                            <div class="meta mb-1"><span class="date">Published 2 days ago</span><span class="time">5 min read</span><span class="comment"><a href="#">8 comments</a></span></div>
                            <div class="intro">

                                @{
                                    string icerik = "";
                                    if (item.content.Length <= 15)
                                    {
                                        icerik = item.content;
                                    }
                                    else
                                    {
                                        icerik = item.content.Substring(0, 15);
                                    }
                                }
                                @Html.Raw(icerik)   ...
                            </div>
                            <a class="more-link" href="/post/UpdatePost/@item.id">Düzenle &rarr;</a>
                            <a class="more-link" href="/post/RemovePost/@item.id">Sil &rarr;</a>
                        </div><!--//media-body-->
                    </div><!--//media-->
                </div><!--//item-->
            }


        </div>
    </section>



</div><!--//main-wrapper-->
```
Oluşturduğumuz postları düzenleme (UpdatePost) adlı action için gerekli view ekranı

UpdatePost.cshtml
```C#
@model TheBlogger.Models.Post

@{
    ViewData["Title"] = "UpdatePost";
}

<div class="main-wrapper">
    <section class="cta-section theme-bg-light py-5">
        <div class="container text-center">
            <h2 class="heading">The Blogger</h2>
            <div class="intro">Blog sayfama hoş geldiniz...</div>


        </div><!--//container-->
    </section>
    <section class="blog-list px-3 py-5 p-md-5">
        <div class="container">
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <form asp-action="UpdatePost">
                        <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                        <div class="form-group">
                            <label asp-for="title" class="control-label">Yazı Başlığı</label>
                            <input asp-for="title" class="form-control" />
                            <span asp-validation-for="title" class="text-danger"></span>
                        </div>
                        <div class="form-group">

                            <textarea class="ckeditor" id="ckeditor1" asp-for="content"></textarea>

                        </div>
                        <div class="form-group">
                            <input type="submit" value="Kaydet" class="btn btn-primary" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</div>
<script src="~/ckeditor/ckeditor.js"></script>
<script>
    CKEDITOR.replace('ckeditor1', {
    });
</script>
```
Şimdi User Side Tarafındaki işimiz tamamiyle bitti. Sıra Admin Side tarafında bizim senaryomuzda kullanıcılar postları yayınlamak istediklerinde önce admin kontrolünden geçip onaylanması gerekmekte bu yüzden PostState diye bi alanımız var Post state eğer 1 ise onaylanmış bir post anlamına geliyor eğer 0 ise onaylanmamış post demektir bu yüzden postlar ilk eklendiğinde varsayılan olarak PostState=0 olarak ayarlandı.

Admin içerikte bir uygunsuzluk tespit etmezse postun yayınlanması için onay verir ve eklediğiniz post anasayfada görünmeye başlar...

Şimdi AdminSide için ayrı bi area oluşturmamız gerekiyor Projemize sağ tıklayıp yeni bi area ekleyip içerisine Admin adında bir klasör oluşturdum ve Startuptaki yönlendirme işlemi için Configure alanına aşşağıdaki Kodu ekledim.
```C#
app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
```
Ben internet üzerinden hazır bootstrap tasarımlı bir template buldum css dosyalarımı wwwroot klasörüme aktardım 
ardından _AdminLayout.cshtml dosyamı aşşağıdaki gibi düzenledim...

_AdminLayout.cshtml
```C#
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>The Blogger | Admin Paneli</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="robots" content="all,follow">
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Bootstrap CSS-->
    <script src="https://cdn.ckeditor.com/4.14.0/standard/ckeditor.js"></script>
    <link rel="stylesheet" href="~/admin/vendor/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome CSS-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Custom Font Icons CSS-->
    <link rel="stylesheet" href="~/admin/css/font.css">
    <!-- Google fonts - Muli-->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Muli:300,400,700">
    <!-- theme stylesheet-->
    <link rel="stylesheet" href="~/admin/css/style.default.css" id="theme-stylesheet">
    <!-- Custom stylesheet - for your changes-->
    <link rel="stylesheet" href="~/admin/css/custom.css">
    <!-- Favicon-->
    <link rel="shortcut icon" href="img/favicon.ico">

</head>
<body>
    <header class="header">
        <nav class="navbar navbar-expand-lg">

            <div class="container-fluid d-flex align-items-center justify-content-between">
                <div class="navbar-header">
                    <!-- Navbar Header--><a href="~/Home/Index" class="navbar-brand">
                        <div class="brand-text brand-big visible text-uppercase"><strong class="text-primary">The</strong><strong>Blogger</strong></div>
                        <div class="brand-text brand-sm"><strong class="text-primary">T</strong><strong>B</strong></div>
                    </a>
                    <!-- Sidebar Toggle Btn-->
                    <button class="sidebar-toggle"><i class="fa fa-long-arrow-left"></i></button>
                </div>
                <div class="right-menu list-inline no-margin-bottom">

                    <div class="list-inline-item dropdown">

                    </div>
                </div>
            </div>
        </nav>
    </header>
    <div class="d-flex align-items-stretch">
        <!-- Sidebar Navigation-->
        <nav id="sidebar">
            <!-- Sidebar Header-->
            @using Microsoft.AspNetCore.Identity
            @using Microsoft.AspNetCore.Authorization
            @inject IAuthorizationService AuthorizationService
            @inject SignInManager<IdentityUser>   SignInManager

            @inject UserManager<IdentityUser> UserManager

            @inject RoleManager<IdentityRole> roleManager


            @{
                var userid = UserManager.GetUserId(User);

                IdentityUser user = UserManager.FindByIdAsync(userid).Result;



            }
            @if (SignInManager.IsSignedIn(User))
            {

                <div class="sidebar-header d-flex align-items-center">
                    <div class="avatar"><img src="~/admin/img/user.png" alt="..." class="img-fluid rounded-circle"></div>
                    <div class="title">
                        <h1 class="h5">@user.UserName</h1>
                        <h5><img src="~/admin/img/admin.png" alt="" height="20" width="20" />Admin </h5>
                        Tarih : @DateTime.Now.ToShortDateString()
                    </div>
                </div>
            }
            <!-- Sidebar Navidation Menus--><span class="heading">Main</span>
            <ul class="list-unstyled">
                <li><a href="~/Admin/Home"> <i class="icon-home"></i>Anasayfa </a></li>
                <li><a asp-action="Index" asp-controller="Posts"><i class="icon-pencil-case"></i> Onaylanan Postlar</a></li>
                <li><a asp-action="UnAccepteds" asp-controller="Posts"><i class="icon-controls"></i> Onay Bekleyen Postlar</a></li>

            </ul>
        </nav>
        <div class="page-content">
            <!-- Sidebar Navigation end-->
            <div>
                @RenderBody()
            </div>
            <footer class="footer">
                <div class="footer__block block no-margin-bottom">
                    <div class="container-fluid text-center">
                        <!-- Please do not remove the backlink to us unless you support us at https://bootstrapious.com/donate. It is part of the license conditions. Thank you for understanding :)-->
                        <p class="no-margin-bottom">2019 &copy; Your company. Design by <a href="https://bootstrapious.com/p/bootstrap-4-dark-admin">Bootstrapious</a>.</p>
                    </div>
                </div>
            </footer>
        </div>
    </div>

    <!-- JavaScript files-->
    <script src="~/admin/vendor/jquery/jquery.min.js"></script>
    <script src="~/admin/vendor/popper.js/umd/popper.min.js"></script>
    <script src="~/admin/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="~/admin/vendor/jquery.cookie/jquery.cookie.js"></script>
    <script src="~/admin/vendor/chart.js/Chart.min.js"></script>
    <script src="~/admin/vendor/jquery-validation/jquery.validate.min.js"></script>
    <script src="~/admin/js/charts-home.js"></script>
    <script src="~/admin/js/front.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/summernote@0.8.16/dist/summernote.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#summernote').summernote();
        });
    </script>
    <script>
        $(document).ready(function () {
            $('.list-unstyled').find('[href="' + window.location.pathname + '"]').parent().addClass('active');
        });
    </script>

</body>
</html>
```
Admin Side tarafına Bir HomeController  ekledim ve Index Actionunu oluşturup hoş bir görüntü oluşsun diye bol componentli bir anasayfa ekledim.

HomeController.cs Admin Side...
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheBlogger.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
```
Areasını belirttikten sonra Athorize ekleyip üye rolü sadece admin olanların görüntüleyebileceği şekilde ayarladım.

Index.cshtml Admin Side
```C#

@{
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
}

<div class="page-header">
    <div class="container-fluid">
        <h2 class="h5 no-margin-bottom">Gösterge Paneli</h2>
    </div>
</div>
<section class="no-padding-top no-padding-bottom">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3 col-sm-6">
                <div class="statistic-block block">
                    <div class="progress-details d-flex align-items-end justify-content-between">
                        <div class="title">
                            <div class="icon"><i class="icon-user-1"></i></div><strong>New Clients</strong>
                        </div>
                        <div class="number dashtext-1">27</div>
                    </div>
                    <div class="progress progress-template">
                        <div role="progressbar" style="width: 30%" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template dashbg-1"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="statistic-block block">
                    <div class="progress-details d-flex align-items-end justify-content-between">
                        <div class="title">
                            <div class="icon"><i class="icon-contract"></i></div><strong>New Projects</strong>
                        </div>
                        <div class="number dashtext-2">375</div>
                    </div>
                    <div class="progress progress-template">
                        <div role="progressbar" style="width: 70%" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template dashbg-2"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="statistic-block block">
                    <div class="progress-details d-flex align-items-end justify-content-between">
                        <div class="title">
                            <div class="icon"><i class="icon-paper-and-pencil"></i></div><strong>New Invoices</strong>
                        </div>
                        <div class="number dashtext-3">140</div>
                    </div>
                    <div class="progress progress-template">
                        <div role="progressbar" style="width: 55%" aria-valuenow="55" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template dashbg-3"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6">
                <div class="statistic-block block">
                    <div class="progress-details d-flex align-items-end justify-content-between">
                        <div class="title">
                            <div class="icon"><i class="icon-writing-whiteboard"></i></div><strong>All Projects</strong>
                        </div>
                        <div class="number dashtext-4">41</div>
                    </div>
                    <div class="progress progress-template">
                        <div role="progressbar" style="width: 35%" aria-valuenow="35" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template dashbg-4"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="no-padding-bottom">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-4">
                <div class="bar-chart block no-margin-bottom">
                    <canvas id="barChartExample1"></canvas>
                </div>
                <div class="bar-chart block">
                    <canvas id="barChartExample2"></canvas>
                </div>
            </div>
            <div class="col-lg-8">
                <div class="line-cahrt block">
                    <canvas id="lineCahrt"></canvas>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="no-padding-bottom">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-6">
                <div class="stats-2-block block d-flex">
                    <div class="stats-2 d-flex">
                        <div class="stats-2-arrow low"><i class="fa fa-caret-down"></i></div>
                        <div class="stats-2-content">
                            <strong class="d-block">5.657</strong><span class="d-block">Standard Scans</span>
                            <div class="progress progress-template progress-small">
                                <div role="progressbar" style="width: 60%;" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template progress-bar-small dashbg-2"></div>
                            </div>
                        </div>
                    </div>
                    <div class="stats-2 d-flex">
                        <div class="stats-2-arrow height"><i class="fa fa-caret-up"></i></div>
                        <div class="stats-2-content">
                            <strong class="d-block">3.1459</strong><span class="d-block">Team Scans</span>
                            <div class="progress progress-template progress-small">
                                <div role="progressbar" style="width: 35%;" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template progress-bar-small dashbg-3"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="stats-3-block block d-flex">
                    <div class="stats-3">
                        <strong class="d-block">745</strong><span class="d-block">Total requests</span>
                        <div class="progress progress-template progress-small">
                            <div role="progressbar" style="width: 35%;" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100" class="progress-bar progress-bar-template progress-bar-small dashbg-1"></div>
                        </div>
                    </div>
                    <div class="stats-3 d-flex justify-content-between text-center">
                        <div class="item">
                            <strong class="d-block strong-sm">4.124</strong><span class="d-block span-sm">Threats</span>
                            <div class="line"></div><small>+246</small>
                        </div>
                        <div class="item">
                            <strong class="d-block strong-sm">2.147</strong><span class="d-block span-sm">Neutral</span>
                            <div class="line"></div><small>+416</small>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="drills-chart block">
                    <canvas id="lineChart1"></canvas>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="no-padding-bottom">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-4">
                <div class="user-block block text-center">
                    <div class="avatar">
                        <img src="~/admin/img/avatar-1.jpg" alt="..." class="img-fluid">
                        <div class="order dashbg-2">1st</div>
                    </div><a href="#" class="user-title">
                        <h3 class="h5">Richard Nevoreski</h3><span>richardnevo</span>
                    </a>
                    <div class="contributions">950 Contributions</div>
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>150</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>340</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>460</strong></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="user-block block text-center">
                    <div class="avatar">
                        <img src="~/admin/img/avatar-4.jpg" alt="..." class="img-fluid">
                        <div class="order dashbg-1">2nd</div>
                    </div><a href="#" class="user-title">
                        <h3 class="h5">Samuel Watson</h3><span>samwatson</span>
                    </a>
                    <div class="contributions">772 Contributions</div>
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>80</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>420</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>272</strong></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="user-block block text-center">
                    <div class="avatar">
                        <img src="~/admin/img/avatar-6.jpg" alt="..." class="img-fluid">
                        <div class="order dashbg-4">3rd</div>
                    </div><a href="#" class="user-title">
                        <h3 class="h5">Sebastian Wood</h3><span>sebastian</span>
                    </a>
                    <div class="contributions">620 Contributions</div>
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>150</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>280</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>190</strong></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="public-user-block block">
            <div class="row d-flex align-items-center">
                <div class="col-lg-4 d-flex align-items-center">
                    <div class="order">4th</div>
                    <div class="avatar"> <img src="~/admin/img/avatar-1.jpg" alt="..." class="img-fluid"></div><a href="#" class="name"><strong class="d-block">Tomas Hecktor</strong><span class="d-block">tomhecktor</span></a>
                </div>
                <div class="col-lg-4 text-center">
                    <div class="contributions">410 Contributions</div>
                </div>
                <div class="col-lg-4">
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>110</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>200</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>100</strong></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="public-user-block block">
            <div class="row d-flex align-items-center">
                <div class="col-lg-4 d-flex align-items-center">
                    <div class="order">5th</div>
                    <div class="avatar"> <img src="~/admin/img/avatar-2.jpg" alt="..." class="img-fluid"></div><a href="#" class="name"><strong class="d-block">Alexander Shelby</strong><span class="d-block">alexshelby</span></a>
                </div>
                <div class="col-lg-4 text-center">
                    <div class="contributions">320 Contributions</div>
                </div>
                <div class="col-lg-4">
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>150</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>120</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>50</strong></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="public-user-block block">
            <div class="row d-flex align-items-center">
                <div class="col-lg-4 d-flex align-items-center">
                    <div class="order">6th</div>
                    <div class="avatar"> <img src="~/admin/img/avatar-6.jpg" alt="..." class="img-fluid"></div><a href="#" class="name"><strong class="d-block">Arther Kooper</strong><span class="d-block">artherkooper</span></a>
                </div>
                <div class="col-lg-4 text-center">
                    <div class="contributions">170 Contributions</div>
                </div>
                <div class="col-lg-4">
                    <div class="details d-flex">
                        <div class="item"><i class="icon-info"></i><strong>60</strong></div>
                        <div class="item"><i class="fa fa-gg"></i><strong>70</strong></div>
                        <div class="item"><i class="icon-flow-branch"></i><strong>40</strong></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="margin-bottom-sm">
    <div class="container-fluid">
        <div class="row d-flex align-items-stretch">
            <div class="col-lg-4">
                <div class="stats-with-chart-1 block">
                    <div class="title"> <strong class="d-block">Sales Difference</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="row d-flex align-items-end justify-content-between">
                        <div class="col-5">
                            <div class="text"><strong class="d-block dashtext-3">$740</strong><span class="d-block">May 2017</span><small class="d-block">320 Sales</small></div>
                        </div>
                        <div class="col-7">
                            <div class="bar-chart chart">
                                <canvas id="salesBarChart1"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="stats-with-chart-1 block">
                    <div class="title"> <strong class="d-block">Visit Statistics</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="row d-flex align-items-end justify-content-between">
                        <div class="col-4">
                            <div class="text"><strong class="d-block dashtext-1">$457</strong><span class="d-block">May 2017</span><small class="d-block">210 Sales</small></div>
                        </div>
                        <div class="col-8">
                            <div class="bar-chart chart">
                                <canvas id="visitPieChart"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="stats-with-chart-1 block">
                    <div class="title"> <strong class="d-block">Sales Activities</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="row d-flex align-items-end justify-content-between">
                        <div class="col-5">
                            <div class="text"><strong class="d-block dashtext-2">80%</strong><span class="d-block">May 2017</span><small class="d-block">+35 Sales</small></div>
                        </div>
                        <div class="col-7">
                            <div class="bar-chart chart">
                                <canvas id="salesBarChart2"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section class="no-padding-bottom">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-6">
                <div class="checklist-block block">
                    <div class="title"><strong>To Do List</strong></div>
                    <div class="checklist">
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-1" name="input-1" class="checkbox-template">
                            <label for="input-1">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-2" name="input-2" checked class="checkbox-template">
                            <label for="input-2">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-3" name="input-3" class="checkbox-template">
                            <label for="input-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-4" name="input-4" class="checkbox-template">
                            <label for="input-4">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-5" name="input-5" class="checkbox-template">
                            <label for="input-5">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                        <div class="item d-flex align-items-center">
                            <input type="checkbox" id="input-6" name="input-6" class="checkbox-template">
                            <label for="input-6">Lorem ipsum dolor sit amet, consectetur adipisicing elit.</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="messages-block block">
                    <div class="title"><strong>New Messages</strong></div>
                    <div class="messages">
                        <a href="#" class="message d-flex align-items-center">
                            <div class="profile">
                                <img src="~/admin/img/avatar-3.jpg" alt="..." class="img-fluid">
                                <div class="status online"></div>
                            </div>
                            <div class="content">   <strong class="d-block">Nadia Halsey</strong><span class="d-block">lorem ipsum dolor sit amit</span><small class="date d-block">9:30am</small></div>
                        </a><a href="#" class="message d-flex align-items-center">
                            <div class="profile">
                                <img src="~/admin/img/avatar-2.jpg" alt="..." class="img-fluid">
                                <div class="status away"></div>
                            </div>
                            <div class="content">   <strong class="d-block">Peter Ramsy</strong><span class="d-block">lorem ipsum dolor sit amit</span><small class="date d-block">7:40am</small></div>
                        </a><a href="#" class="message d-flex align-items-center">
                            <div class="profile">
                                <img src="~/admin/img/avatar-1.jpg" alt="..." class="img-fluid">
                                <div class="status busy"></div>
                            </div>
                            <div class="content">   <strong class="d-block">Sam Kaheil</strong><span class="d-block">lorem ipsum dolor sit amit</span><small class="date d-block">6:55am</small></div>
                        </a><a href="#" class="message d-flex align-items-center">
                            <div class="profile">
                                <img src="~/admin/img/avatar-5.jpg" alt="..." class="img-fluid">
                                <div class="status offline"></div>
                            </div>
                            <div class="content">   <strong class="d-block">Sara Wood</strong><span class="d-block">lorem ipsum dolor sit amit</span><small class="date d-block">10:30pm</small></div>
                        </a><a href="#" class="message d-flex align-items-center">
                            <div class="profile">
                                <img src="~/admin/img/avatar-1.jpg" alt="..." class="img-fluid">
                                <div class="status online"></div>
                            </div>
                            <div class="content">   <strong class="d-block">Nader Magdy</strong><span class="d-block">lorem ipsum dolor sit amit</span><small class="date d-block">9:47pm</small></div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-4">
                <div class="stats-with-chart-2 block">
                    <div class="title"><strong class="d-block">Credit Sales</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="piechart chart">
                        <canvas id="pieChartHome1"></canvas>
                        <div class="text"><strong class="d-block">$2.145</strong><span class="d-block">Sales</span></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="stats-with-chart-2 block">
                    <div class="title"><strong class="d-block">Channel Sales</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="piechart chart">
                        <canvas id="pieChartHome2"></canvas>
                        <div class="text"><strong class="d-block">$7.784</strong><span class="d-block">Sales</span></div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="stats-with-chart-2 block">
                    <div class="title"><strong class="d-block">Direct Sales</strong><span class="d-block">Lorem ipsum dolor sit</span></div>
                    <div class="piechart chart">
                        <canvas id="pieChartHome3"></canvas>
                        <div class="text"><strong class="d-block">$4.957</strong><span class="d-block">Sales</span></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
```
Son olarak SideBar da PostState değerine göre onaylanan ve onay bekleyen postlar için görünümler ve Post Controller ekledim böylelike admin onay vermediği postu silip onayladığı postun poststate ini güncelleyip sayfada yayınlanmasına izin verecektir.

PostsContoller.cs Admin Side
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheBlogger.Models;

namespace TheBlogger.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class PostsController : Controller
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Admin/Posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.posts.ToListAsync());
        }
        public async Task<IActionResult> UnAccepteds()
        {
            return View(await _context.posts.ToListAsync());
        }
        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,PostState")] Post post)
        {
            if (id != post.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var temp = await _context.posts.FindAsync(id);
                    temp.PostState = 1;
                    _context.Update(temp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id, [Bind("id,PostState")] Post post)
        {
            if (id != post.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var temp = await _context.posts.FindAsync(id);
                    temp.PostState = 0;
                    _context.Update(temp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .FirstOrDefaultAsync(m => m.id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.posts.FindAsync(id);
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.posts.Any(e => e.id == id);
        }
    }
}
```

Bu Sayfada Onaylanan Postlar
Posts/Index.cshtml
```C#
@model IEnumerable<TheBlogger.Models.Post>

@{
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
}
<div class="page-header">
    <div class="container-fluid">
        <h2 class="h5 no-margin-bottom">Postlarımıza Hoş Geldiniz</h2>
    </div>
</div>
<div class="col-lg-12">
    <div class="block">
        <div class="block-body">
            <section class="no-padding-top">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="block">

                            </div>
                        </div>


                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        Post Başlığı
                                    </th>
                                    <th>
                                        İçerik
                                    </th>
                                    <th>
                                        Tarih
                                    </th>
                                    <th>
                                        Post Durumu
                                    </th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var item in Model.Where(z => z.PostState == 1))
                                {
                                    <tr>
                                        <td>
                                            @Html.DisplayFor(modelItem => item.title)
                                        </td>
                                        <td>
                                            @{
                                                string icerik = "";
                                                if (item.content.Length <= 15)
                                                {
                                                    icerik = item.content;
                                                }
                                                else
                                                {
                                                    icerik = item.content.Substring(0, 15);
                                                }
                                            }
                                            @Html.Raw(icerik)...
                                        </td>
                                        <td>
                                            @Html.DisplayFor(modelItem => item.TimeStamp)
                                        </td>
                                        <td>
                                            Onaylandı !
                                        </td>
                                        <td>
                                            <a asp-action="Edit2" asp-route-id="@item.id">Onay Kaldır</a> |
                                            <a asp-action="Delete" asp-route-id="@item.id">Sil</a>
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
        </div>
    </div>
</div>
```

Onay Bekleyen Postlar

UnAceppteds.cshtml
```C#

@model IEnumerable<TheBlogger.Models.Post>
@{
    ViewData["Title"] = "UnAccepteds";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
}
<div class="page-header">
    <div class="container-fluid">
        <h2 class="h5 no-margin-bottom">Postlarımıza Hoş Geldiniz</h2>
    </div>
</div>
<div class="col-lg-12">
    <div class="block">
        <div class="block-body">
            <section class="no-padding-top">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-5">
                            <div class="block">

                            </div>
                        </div>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>
                                        Post Başlığı
                                    </th>
                                    <th>
                                        İçerik
                                    </th>
                                    <th>
                                        Tarih
                                    </th>
                                    <th>
                                        Post Durumu
                                    </th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var item in Model.Where(i => i.PostState == 0))
                                {
                                    <tr>
                                        <td>
                                            @Html.DisplayFor(modelItem => item.title)
                                        </td>
                                        <td>
                                            @{
                                                string icerik = "";
                                                if (item.content.Length <= 15)
                                                {
                                                    icerik = item.content;
                                                }
                                                else
                                                {
                                                    icerik = item.content.Substring(0, 15);
                                                }
                                            }
                                            @Html.Raw(icerik)...
                                        </td>
                                        <td>
                                            @Html.DisplayFor(modelItem => item.TimeStamp)
                                        </td>
                                        <td>
                                            Onay Bekliyor...
                                        </td>
                                        <td>
                                            <a asp-action="Edit" asp-route-id="@item.id">Onayla</a> |
                                            <a asp-action="Delete" asp-route-id="@item.id">Sil</a>
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>
        </div>
    </div>
</div>
```


##Sonuç ve Ekranlar:



![Screen](https://github.com/behlulalas/Blogg/blob/master/images/5.png)


![Screen](https://github.com/behlulalas/Blogg/blob/master/images/6.png)


![Screen](https://github.com/behlulalas/Blogg/blob/master/images/7.png)


![Screen](https://github.com/behlulalas/Blogg/blob/master/images/8.png)


![Screen](https://github.com/behlulalas/Blogg/blob/master/images/9.png)


![Screen](https://github.com/behlulalas/Blogg/blob/master/images/10.png)

#pragma checksum "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61aa13f2ab44c11760e37b68b62aefb6bcfc6ddf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PostofUser), @"mvc.1.0.view", @"/Views/Home/PostofUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/PostofUser.cshtml", typeof(AspNetCore.Views_Home_PostofUser))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\_ViewImports.cshtml"
using TheBlogger.Models;

#line default
#line hidden
#line 2 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\_ViewImports.cshtml"
using TheBlogger.ViewModel;

#line default
#line hidden
#line 3 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61aa13f2ab44c11760e37b68b62aefb6bcfc6ddf", @"/Views/Home/PostofUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb9cec59b2d3ecdb39aac83137f2a06df15a27a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PostofUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TheBlogger.Models.Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
  
    ViewData["Title"] = "PostofUser";


#line default
#line hidden
#line 6 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
  int j = 0;

#line default
#line hidden
#line 7 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
  int k = 0;

#line default
#line hidden
#line 8 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
 foreach (var c in Model.MainComments)
{
    j++;
    foreach (var sc in c.subComments)
    {
        k++;
    }
}

#line default
#line hidden
#line 16 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
  
    int toplamyorum = j + k;

#line default
#line hidden
            BeginContext(269, 28, true);
            WriteLiteral("<div class=\"main-wrapper\">\r\n");
            EndContext();
#line 20 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
      
        string Tarih = Model.TimeStamp.ToShortDateString();
        string Saat = Model.TimeStamp.ToShortTimeString();
    

#line default
#line hidden
            BeginContext(433, 169, true);
            WriteLiteral("    <article class=\"blog-post px-3 py-5 p-md-5\">\r\n        <div class=\"container\">\r\n            <header class=\"blog-post-header\">\r\n                <h2 class=\"title mb-2\">");
            EndContext();
            BeginContext(603, 37, false);
#line 27 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                  Write(Html.DisplayFor(model => model.title));

#line default
#line hidden
            EndContext();
            BeginContext(640, 72, true);
            WriteLiteral("</h2>\r\n                <div class=\"meta mb-3\"><span class=\"date\">Tarih: ");
            EndContext();
            BeginContext(713, 5, false);
#line 28 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                            Write(Tarih);

#line default
#line hidden
            EndContext();
            BeginContext(718, 32, true);
            WriteLiteral("</span><span class=\"time\">Saat: ");
            EndContext();
            BeginContext(751, 4, false);
#line 28 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                                                  Write(Saat);

#line default
#line hidden
            EndContext();
            BeginContext(755, 36, true);
            WriteLiteral("</span><span class=\"comment\">Yorum (");
            EndContext();
            BeginContext(792, 11, false);
#line 28 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                                                                                           Write(toplamyorum);

#line default
#line hidden
            EndContext();
            BeginContext(803, 117, true);
            WriteLiteral(")<a href=\"#\"></a></span></div>\r\n            </header>\r\n\r\n            <div class=\"blog-post-body\">\r\n\r\n                ");
            EndContext();
            BeginContext(921, 23, false);
#line 33 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
           Write(Html.Raw(Model.content));

#line default
#line hidden
            EndContext();
            BeginContext(944, 52, true);
            WriteLiteral("\r\n            </div><!--//blog-comments-section-->\r\n");
            EndContext();
#line 35 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
              

                await Html.RenderPartialAsync("_CommentAdd", new CommentViewModel() { PostId = Model.id, MainCommentId = 0 });

            

#line default
#line hidden
            BeginContext(1159, 308, true);
            WriteLiteral(@"
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""comments"">
                            <div class=""comments-details"">
                                <span class=""total-comments comments-sort"">Yorumlar(");
            EndContext();
            BeginContext(1468, 11, false);
#line 46 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                               Write(toplamyorum);

#line default
#line hidden
            EndContext();
            BeginContext(1479, 148, true);
            WriteLiteral(")</span>\r\n                                <span class=\"dropdown\">\r\n\r\n                                </span>\r\n                            </div>\r\n\r\n");
            EndContext();
#line 52 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                              int i = 0;

#line default
#line hidden
            BeginContext(1670, 28, true);
            WriteLiteral("                            ");
            EndContext();
#line 53 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                             foreach (var comment in Model.MainComments)
                            {


#line default
#line hidden
            BeginContext(1777, 358, true);
            WriteLiteral(@"                                <div class=""comment-box"">
                                    <span class=""commenter-pic"">
                                        <img src=""https://bootdey.com/img/Content/user_1.jpg"" alt="""" class=""img-fluid"">
                                    </span>
                                    <span class=""commenter-name"">
");
            EndContext();
#line 61 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                         if (comment.UserName == null)
                                        {

#line default
#line hidden
            BeginContext(2250, 69, true);
            WriteLiteral("                                            <a href=\"#\">Misafir</a>\r\n");
            EndContext();
#line 64 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(2451, 56, true);
            WriteLiteral("                                            <a href=\"#\">");
            EndContext();
            BeginContext(2508, 16, false);
#line 67 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                   Write(comment.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2524, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 68 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                        }

#line default
#line hidden
            BeginContext(2571, 28, true);
            WriteLiteral(" <span class=\"comment-time\">");
            EndContext();
            BeginContext(2600, 15, false);
#line 68 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                Write(comment.Created);

#line default
#line hidden
            EndContext();
            BeginContext(2615, 118, true);
            WriteLiteral("</span>\r\n                                    </span>\r\n                                    <p class=\"comment-txt more\">");
            EndContext();
            BeginContext(2734, 15, false);
#line 70 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                           Write(comment.Message);

#line default
#line hidden
            EndContext();
            BeginContext(2749, 70, true);
            WriteLiteral("</p>\r\n\r\n\r\n                                    <div class=\"panel-group\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2819, "\"", 2836, 2);
            WriteAttributeValue("", 2824, "accordion_", 2824, 10, true);
#line 73 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
WriteAttributeValue("", 2834, i, 2834, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2837, 75, true);
            WriteLiteral(">\r\n                                        <div class=\"panel panel-default\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2912, "\"", 2925, 2);
            WriteAttributeValue("", 2917, "panel_", 2917, 6, true);
#line 74 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
WriteAttributeValue("", 2923, i, 2923, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2926, 254, true);
            WriteLiteral(">\r\n                                            <div class=\"panel-heading\">\r\n                                                <h4 class=\"panel-title\">\r\n                                                    <a data-toggle=\"collapse\" data-target=\"#collapseOne_");
            EndContext();
            BeginContext(3181, 1, false);
#line 77 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                                                   Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(3182, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3183, "\"", 3205, 2);
            WriteAttributeValue("", 3190, "#collapseOne_", 3190, 13, true);
#line 77 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
WriteAttributeValue("", 3203, i, 3203, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3206, 281, true);
            WriteLiteral(@">
                                                        Yanıtla
                                                    </a>
                                                </h4>
                                            </div>
                                            <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3487, "\"", 3506, 2);
            WriteAttributeValue("", 3492, "collapseOne_", 3492, 12, true);
#line 82 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
WriteAttributeValue("", 3504, i, 3504, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3507, 112, true);
            WriteLiteral(" class=\"panel-collapse collapse in\">\r\n                                                <div class=\"panel-body\">\r\n");
            EndContext();
#line 84 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                      
                                                        await Html.RenderPartialAsync("_CommentAdd", new CommentViewModel() { PostId = Model.id, MainCommentId = comment.Id });
                                                    

#line default
#line hidden
            BeginContext(3907, 202, true);
            WriteLiteral("                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n\r\n");
            EndContext();
#line 92 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                     foreach (var item in comment.subComments)
                                    {

#line default
#line hidden
            BeginContext(4228, 406, true);
            WriteLiteral(@"                                        <div class=""comment-box replied"">
                                            <span class=""commenter-pic"">
                                                <img src=""https://bootdey.com/img/Content/user_1.jpg"" alt="""" class=""img-fluid"">
                                            </span>
                                            <span class=""commenter-name"">
");
            EndContext();
#line 99 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                 if (item.UserName == null)
                                                {

#line default
#line hidden
            BeginContext(4762, 77, true);
            WriteLiteral("                                                    <a href=\"#\">Misafir</a>\r\n");
            EndContext();
#line 102 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
            BeginContext(4995, 64, true);
            WriteLiteral("                                                    <a href=\"#\">");
            EndContext();
            BeginContext(5060, 13, false);
#line 105 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                           Write(item.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(5073, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 106 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                }

#line default
#line hidden
            BeginContext(5130, 77, true);
            WriteLiteral("\r\n                                                <span class=\"comment-time\">");
            EndContext();
            BeginContext(5208, 12, false);
#line 108 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                      Write(item.Created);

#line default
#line hidden
            EndContext();
            BeginContext(5220, 134, true);
            WriteLiteral("</span>\r\n                                            </span>\r\n                                            <p class=\"comment-txt more\">");
            EndContext();
            BeginContext(5355, 12, false);
#line 110 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                                                   Write(item.Message);

#line default
#line hidden
            EndContext();
            BeginContext(5367, 58, true);
            WriteLiteral("</p>\r\n\r\n\r\n                                        </div>\r\n");
            EndContext();
#line 114 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                    }

#line default
#line hidden
            BeginContext(5464, 42, true);
            WriteLiteral("\r\n                                </div>\r\n");
            EndContext();
#line 117 "C:\Users\HP\source\repos\TheBlogger\TheBlogger\Views\Home\PostofUser.cshtml"
                                i++;
                            }

#line default
#line hidden
            BeginContext(5575, 198, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div><!--//container-->\r\n    </article>\r\n\r\n    <!--//promo-section-->\r\n</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TheBlogger.Models.Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
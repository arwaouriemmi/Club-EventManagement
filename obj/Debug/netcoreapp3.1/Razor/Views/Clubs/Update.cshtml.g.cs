#pragma checksum "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7c256724df624f93acbff4335ee6b028c56c122"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clubs_Update), @"mvc.1.0.view", @"/Views/Clubs/Update.cshtml")]
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
#nullable restore
#line 1 "C:\Users\onsou\Desktop\FrameworksProject\Views\_ViewImports.cshtml"
using FrameworksProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\onsou\Desktop\FrameworksProject\Views\_ViewImports.cshtml"
using FrameworksProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7c256724df624f93acbff4335ee6b028c56c122", @"/Views/Clubs/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70053674d2b90feeec2989712c1437946f54ac1e", @"/Views/_ViewImports.cshtml")]
    public class Views_Clubs_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Club>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
  
    ViewData["Title"] = "Update Club";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"display-4\">Update an Event!!</h2>\r\n<div class=\"row\">\r\n    <div class=\"col-12 justify-content-center\">\r\n        <section id=\"CreateForm\">\r\n");
#nullable restore
#line 10 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
             using (Html.BeginForm("Update", "Clubs", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <hr />\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 14 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Enter the Club name: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 16 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control form-control-lg", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Enter the club description: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 22 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBoxFor(m => m.Description, new { @class = "form-control form-control-lg", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Enter the club creation year: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 29 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBoxFor(m => m.CreationYear, new { @class = "form-control form-control-lg", @type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 34 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Enter the club website: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBoxFor(m => m.Website, new { @class = "form-control form-control-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 40 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Enter the club logo: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 42 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBoxFor(m => m.Logo, new { @class = "form-control form-control-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 45 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
           Write(Html.Label("name", "Members: ", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"members\">\r\n");
#nullable restore
#line 48 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
             foreach (var m in Model.Members)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    ");
#nullable restore
#line 51 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.TextBox("ids", m.Id, new { @class = "form-control d-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 52 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Role:", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-4\">\r\n                        ");
#nullable restore
#line 54 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBox("roles", m.Role, new { @class = "form-control form-control-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    ");
#nullable restore
#line 56 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
               Write(Html.Label("name", "Name:", new { @class = "control-label lead" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-4\">\r\n                        ");
#nullable restore
#line 58 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
                   Write(Html.TextBox("names", m.Name, new { @class = "form-control form-control-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"mb-2\">\r\n                        <button class=\"col-md-1 btn btn-link \" id=\"removeRow\" type=\"button\"> &#9587 </button>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 64 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
                <button class=""btn btn-danger my-2"" id=""addRow"" type=""button""> Add Member </button>
                <div class=""form-group mt-3"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <input type=""submit"" value=""Update"" class=""btn btn-danger btn-lg"" />
                    </div>
                </div>
");
#nullable restore
#line 72 "C:\Users\onsou\Desktop\FrameworksProject\Views\Clubs\Update.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </section>\r\n        </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(""#addRow"").click(function () {
        var html = `<div class=""row"">
                        <input name=""ids"" class=""d-none"" value=""-1""/>
                        <label class=""control-label lead"">Role:</label>
                        <div class=""col-md-4"">
                            <input name=""roles"" class=""form-control form-control-lg"" required/>
                        </div>
                        <label class=""control-label lead"">Name:</label>
                        <div class=""col-md-4"">
                            <input name=""names"" class=""form-control form-control-lg"" required/>
                        </div>
                        <div class=""mb-2"">
                        <button class=""col-md-1 btn btn-link"" id=""removeRow"" type=""button""> &#9587 </button>
                        </div>
                    </div>`
        $('#members').append(html);
    });

        jQuery('body').on('click', '#removeRow', function () {
                console.log($");
                WriteLiteral("(this));\r\n                $(this).parent().parent().remove();\r\n            })\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Club> Html { get; private set; }
    }
}
#pragma warning restore 1591

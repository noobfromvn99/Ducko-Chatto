#pragma checksum "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93571502140c92889d37be649712541a86bf8e9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_List), @"mvc.1.0.view", @"/Views/Chat/List.cshtml")]
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
#line 1 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\_ViewImports.cshtml"
using RandomChat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\_ViewImports.cshtml"
using RandomChat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93571502140c92889d37be649712541a86bf8e9d", @"/Views/Chat/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f499c04f3e511d9d1c9c429e7d214a396e37ec4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RandomChat.Models.Topic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Reply", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
  
    ViewData["Title"] = "Topic replies";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
Write(Html.DisplayFor(Model => Model.TopicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
 foreach (var reply in ViewBag.replies)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Anonymous: ");
#nullable restore
#line 11 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
             Write(reply.Reply);

#line default
#line hidden
#nullable disable
            WriteLiteral(" on ");
#nullable restore
#line 11 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
                             Write(reply.ReplyOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 12 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"topics-container\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93571502140c92889d37be649712541a86bf8e9d5140", async() => {
                WriteLiteral("\r\n        <input name=\"content\" id=\"content\" class=\"form-control\" placeholder=\"Leave some short and nice comment :)\" />\r\n        <input type=\"hidden\" name=\"TopicId\" id=\"TopicId\"");
                BeginWriteAttribute("value", " value=\"", 481, "\"", 529, 1);
#nullable restore
#line 17 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
WriteAttributeValue("", 489, Html.DisplayFor(Model => Model.TopicId), 489, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <button type=\"submit\" value=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        ");
#nullable restore
#line 19 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
   Write(Html.ValidationMessage("Error", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 24 "C:\Users\Bach Rach\Source\Repos\noobfromvn99\StrangerChatApp\RandomChat\Views\Chat\List.cshtml"
       await Html.RenderPartialAsync("_ValidationScriptsPartial"); 

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RandomChat.Models.Topic> Html { get; private set; }
    }
}
#pragma warning restore 1591

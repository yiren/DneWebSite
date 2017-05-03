using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DneWebSite.Helper
{
    public static class EnumRadioButtonHelper
    {
        public static MvcHtmlString EnumRadioButton<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var listOfValues = Enum.GetNames(metaData.ModelType);

            var sb = new StringBuilder();

            if (listOfValues != null)
            {
                


                foreach (var name in listOfValues)
                {
                    var label = name;

                    var memInfo = metaData.ModelType.GetMember(name);

                    if (memInfo != null)
                    {
                        var attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                        if (attributes != null && attributes.Length > 0)
                            label = ((DisplayAttribute)attributes[0]).Name;
                    }

                    var id = string.Format(
                        "{0}_{1}_{2}",
                        htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                        metaData.PropertyName,
                        name
                    );

                    var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();

                    sb.AppendFormat("{0} {1}", radio, HttpUtility.HtmlEncode(label));
                    sb.AppendFormat("<br/>");
                }
                
                
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
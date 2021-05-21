using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Arquitetura.UI.Web.Helpers
{
    public static class HtmlDropDownExtensions
    {
        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes, bool useHelper)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = ConvertToString(value),
                    Value = value.ToString(),
                    Selected = value.Equals(metadata.Model)
                };

            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(
                    expression, 
                    items, 
                    htmlAttributes
                );
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        public static string ConvertToString(object value)
        {
            var stringReturn = "";

            switch (value.ToString())
            {
                #region Example

                case "EnumItemInformation":
                    stringReturn = "Informação do item do menu";
                    break;

                #endregion Example

                #region default
                default:
                    stringReturn = value.ToString();
                    break;
                #endregion default
            }

            return stringReturn;
        }
    }
}
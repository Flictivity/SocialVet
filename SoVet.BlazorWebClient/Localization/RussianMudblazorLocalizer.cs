using Microsoft.Extensions.Localization;
using MudBlazor;

namespace SoVet.BlazorWebClient.Localization;

public class RussianMudblazorLocalizer : MudLocalizer
{
    private Dictionary<string, string> _localization;

    public RussianMudblazorLocalizer()
    {
        _localization = new()
        {
            { "MudDataGrid.AddFilter", "Добавить фильтр" },
            { "MudDataGrid.Apply", "Применить" },
            { "MudDataGrid.Cancel", "Отменить" },
            { "MudDataGrid.Clear", "Очистить" },
            { "MudDataGrid.CollapseAllGroups", "Свернуть все колонки" },
            { "MudDataGrid.Column", "Колонка" },
            { "MudDataGrid.Columns", "Колонки" },
            { "MudDataGrid.contains", "Содержит" },
            { "MudDataGrid.ends with", "Заканичивается на" },
            { "MudDataGrid.equals", "Равно" },
            { "MudDataGrid.ExpandAllGroups", "Развернуть все группы" },
            { "MudDataGrid.Filter", "Фильтр" },
            { "MudDataGrid.False", "Ложь" },
            { "MudDataGrid.FilterValue", "Значение фильтра" },
            { "MudDataGrid.Group", "Сгруппировать" },
            { "MudDataGrid.Hide", "Скрыть" },
            { "MudDataGrid.HideAll", "Скрыть все" },
            { "MudDataGrid.is", "Есть" },
            { "MudDataGrid.is after", "После" },
            { "MudDataGrid.is before", "До" },
            { "MudDataGrid.is empty", "Пусто" },
            { "MudDataGrid.is not", "Не" },
            { "MudDataGrid.is not empty", "Не пусто" },
            { "MudDataGrid.is on or after", "Равно или после" },
            { "MudDataGrid.is on or before", "Равно или до" },
            { "MudDataGrid.not contains", "Не содержит" },
            { "MudDataGrid.not equals", "Не равно" },
            { "MudDataGrid.Operator", "Оператор" },
            { "MudDataGrid.RefreshData", "Обновить" },
            { "MudDataGrid.Save", "Сохранить" },
            { "MudDataGrid.ShowAll", "Показать все" },
            { "MudDataGrid.starts with", "Начинается с" },
            { "MudDataGrid.True", "Верно" },
            { "MudDataGrid.Ungroup", "Разгруппировать" },
            { "MudDataGrid.Unsort", "Отменить сортировку" },
            { "MudDataGrid.Value", "Значение" }
        };
    }

    public override LocalizedString this[string key]
    {
        get
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (currentCulture.Equals("ru", StringComparison.InvariantCultureIgnoreCase)
                && _localization.TryGetValue(key, out var res))
            {
                return new LocalizedString(key, res);
            }

            return new LocalizedString(key, key, true);
        }
    }
}
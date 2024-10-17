using Broom.Core;
using NLog;
using Terminal.Gui;

namespace Broom.TUI;

public class MyView : Window
{
    public MyView()
    {
        Title = $"Broom ({Application.QuitKey} для выхода)";

        var menu = new MenuBar();
        menu.Menus =
        [
            new MenuBarItem(
                title: "_Файл",
                children: new MenuItem[]
            {
                new(
                    title: "_Закрыть",
                    help: "Выйти из программы",
                    action: () => Application.RequestStop()),
            }),

            new MenuBarItem(
                title: "_Помощь",
                children: new MenuItem[]
            {
                new(
                    title: "_О программе",
                    help: string.Empty,
                    action: () =>
                {
                    MessageBox.Query(
                        title: "Broom",
                        message: """
                                 Очистка кэша и Корзины, удаление временных файлов
                                 Старинин Андрей Николаевич (AnSt), 2024
                                 GNU General Public License v3.0
                                 Версия: 0.1 (Октябрь 2024)
                                 """,
                        buttons: "Закрыть");
                }),
            })
        ];;

        var buttonClear = new Button
        {
            Text = "Очистить",
            X = Pos.Center(),
            Y = Pos.Center(),
            IsDefault = true
        };

        buttonClear.MouseClick += (_, _) =>
        {
            Cleaning.Logger = LogManager.GetLogger(nameof(Cleaning)); //FIXME
            DeleteService.Logger = LogManager.GetLogger(nameof(DeleteService)); //FIXME

            var cleaner = new Cleaner(); //TODO

            cleaner.Add(Cleaning.RecycleBinWinApi);
            cleaner.Add(Cleaning.Downloads);
            cleaner.Add(Cleaning.Temp);

            cleaner.Clean();
            if (cleaner.Errors.Count == 0)
            {
                MessageBox.Query(
                    title: "Broom",
                    message: "Очистка завершена успешно");
            }
            else
            {

                MessageBox.ErrorQuery(
                    title: "Broom",
                    message: "Ошибки при очистке",
                    buttons: "Ok");

                foreach (var error in cleaner.Errors)
                {
                    MessageBox.ErrorQuery(
                        title: "Broom",
                        message: error.Message,
                        buttons: "Ok");
                }
            }
        };

        Add(menu, buttonClear);
    }
}

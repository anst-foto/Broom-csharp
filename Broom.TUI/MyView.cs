using Broom.Core;
using NLog;
using Terminal.Gui;

namespace Broom.TUI;

public class MyView : Window
{
    public MyView()
    {
        Title = $"Broom ({Application.QuitKey} для выхода)";

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
                MessageBox.Query("Broom", "Очистка завершена успешно");
            }
            else
            {

                MessageBox.ErrorQuery("Broom", "Ошибки при очистке", "Ok");
                foreach (var error in cleaner.Errors)
                {
                    MessageBox.ErrorQuery("Broom", error.Message, "Ok");
                }
            }
        };

        Add(buttonClear);
    }
}

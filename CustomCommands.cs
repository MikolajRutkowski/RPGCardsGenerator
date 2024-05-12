using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPGCardsGenerator
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Exit from app",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Q,ModifierKeys.Control)
            }

            );

        public static readonly RoutedUICommand NewCharacter = new RoutedUICommand(
            "Create NewCharacter",
            "NewCharacter",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N,ModifierKeys.Control)
            }

            );

    }
}

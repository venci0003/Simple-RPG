using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Drawers.Interfaces
{
    public interface IDrawer<T>
    {
        public void Draw(T value);

        public void DrawAt(T value, int leftX, int topY);
    }
}

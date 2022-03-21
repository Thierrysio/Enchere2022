using Enchere2022.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enchere2022.Interfaces
{
    interface IDecompteTimer
    {
        void Start(TimeSpan CountdownTime);
        void Stop();

        event EventHandler<TimerEventArgs> TicTac;
        event EventHandler Complet;
        event EventHandler Avorte;
    }
}
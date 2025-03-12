using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022300119
{
    public class FanLaptop
    {
        public enum State { Quiet, Balanced, Performance, Turbo }
        public enum Triger { Mode_UP, Mode_Down, Turbo_Shortcut }
        private State now = State.Quiet;
        
        public class Transition
        {
            public State set_awal;
            public State set_akhir;
            public Triger triger;

            public Transition(State first, State last, Triger triger)
            {
                set_awal = first;
                set_akhir = last;
                triger = triger;
            }
        }

        public Transition[] transisi =
        {
            new Transition(State.Quiet, State.Balanced, Triger.Mode_UP),
            new Transition(State.Quiet, State.Turbo, Triger.Turbo_Shortcut),
            new Transition(State.Balanced, State.Quiet, Triger.Mode_Down),
            new Transition(State.Balanced, State.Performance, Triger.Mode_UP),
            new Transition(State.Performance, State.Balanced, Triger.Mode_Down),
            new Transition(State.Performance, State.Turbo, Triger.Mode_UP),
            new Transition(State.Turbo, State.Quiet, Triger.Turbo_Shortcut),
            new Transition(State.Turbo, State.Performance, Triger.Mode_Down),
        };
            
        public State GetNext(State first, Triger triger)
        {
            foreach (Transition transition in transisi)
            {
                if (first == transition.set_awal && triger == transition.triger)
                {
                    return transition.set_akhir;
                }
            }

            return first;
        }

        public void aktif(Triger triger)
        {
            State prev = now;
            now = GetNext(now, triger);
            Console.WriteLine($"{prev} berubah menjadi {now}");
        }

        public void tes()
        {
            aktif(Triger.Mode_UP);
            aktif(Triger.Mode_UP);
            aktif(Triger.Mode_Down);
            aktif(Triger.Mode_UP);
            aktif(Triger.Turbo_Shortcut);

        }
        
    }
}

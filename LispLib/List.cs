using System;

namespace LispLib
{
    public delegate void VoidFunc<T> (T argument);
    public delegate void VoidFunc<T1, T2> (T1 arg1, T2 arg2);

    public struct List {

        static readonly Symbol lambda = Symbol.Intern ("lambda");

        class ConsCell {
            private readonly object? car;
            private readonly List cdr;

            public ConsCell (object? car, List cdr) {
                this.car = car;
                this.cdr = cdr;
            }

            public object? Car => this.car;
            public List Cdr => this.cdr;
        }

        private readonly ConsCell? head;

        private List (ConsCell? head) {
            this.head = head;
        }

        public List (params object [] items) {
            ConsCell? tail = null;
            for (int i = items.Length - 1; i > -1; i--) {
                tail = new ConsCell (items[i], new List (tail));
            }
            head = tail;
        }

        public object? Car => head == null ? throw new ArgumentNullException () : head.Car;
        public List Cdr => head == null ? throw new ArgumentNullException () : head.Cdr;

        public object? Cadr => head is null ? throw new NotImplementedException () : head.Cdr.Car;
        public List Cddr => head is null ? throw new NotImplementedException () : head.Cdr.Cdr;


        public List Cons (object? item) => new(new List.ConsCell (item, this));

        public static List Empty => new((ConsCell?)null);

        public object? Eval (Environment environment) {
            if (head == null)
                return null;
            else if (head.Car == lambda) {
                return new Closure (this, environment);
            } else {
                List evaled = Mapcar (subexpression => Interpreter.Eval (subexpression, environment));
                return Interpreter.Apply (evaled.Car, evaled.Cdr);
            }
        }

        public object? EvalBody (Environment environment) {
            if (head == null) {
                return null;
            }
            ConsCell? tail = head;
            while (!tail.Cdr.IsEmpty) {
                Interpreter.Eval (tail.Car, environment);
            }
            return Interpreter.Eval (tail.Car, environment);
        }

        public T FoldLeft<T> (Func<T, object?, T> f, T init) {
            return head == null ? init : head.Cdr.FoldLeft (f, f (init, head.Car));
        }

        public bool IsEmpty => head == null;

        public int Length () {
            return head == null ? 0 : 1 + head.Cdr.Length ();
        }

        public void Mapc (VoidFunc<object?> f) {
            ConsCell? tail = head;
            while (tail != null) {
                f (tail.Car);
                tail = tail.Cdr.head;
            }
        }

        public static void Mapc (VoidFunc<object?, object?> f, List list1, List list2) {
            ConsCell? tail1 = list1.head;
            ConsCell? tail2 = list2.head;
            while (tail1 != null) {
                if (tail2 == null) throw new NotImplementedException ();
                f (tail1.Car, tail2.Car);
                tail1 = tail1.Cdr.head;
                tail2 = tail2.Cdr.head;
            }
            if (tail2 != null) throw new NotImplementedException ();
        }

        public List Mapcar (Func<object?, object?> f) => FoldLeft ((List accum, object? item) => accum.Cons (f (item)), List.Empty).Reverse ();

        public T[] MapToVector<T> (Func<object?, T> f) => MapToVectorOffset (f, 0);

        public T[] MapToVectorOffset<T> (Func<object?, T> f, int offset) {
            if (head == null) {
                return new T[offset];
            } else {
                T item = f (head.Car);
                T[] vector = head.Cdr.MapToVectorOffset (f, offset + 1);
                vector[offset] = item;
                return vector;
            }
        }

        public List Revappend (List tail) => FoldLeft ((List answer, object? item) => answer.Cons (item), tail);

        public List Reverse () => Revappend (List.Empty);

        public object? [] ToVector() => ToVectorOffset (0);

        public object? [] ToVectorOffset (int offset) {
            if (head == null)
                return new object[offset];
            else {
                object? [] vector = head.Cdr.ToVectorOffset (offset + 1);
                vector[offset] = head.Car;
                return vector;
            }
        }
    }
}

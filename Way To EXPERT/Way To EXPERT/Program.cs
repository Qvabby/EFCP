using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using qvabbytesD1;

namespace Way_To_EXPERT_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Author = "Qvabbyte";
            const string LastPage = " 63 | Indices and Ranges ";
            //Apperently this is Default lambda parameters
            var QvaPrint = (string msg = "") =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Author}: {msg}");
                Console.ResetColor();
            };
            var Line = () =>
            {
                Console.WriteLine("\n");
            };
            var SomethingDidntWork = () =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("smthn didn't work here...");
                Console.ResetColor();
            };
            //Just as ordinary methods can define parameters with default values:
            void Print(string msg = "") => Console.WriteLine($"----|  {msg}  |----");


            //Dialogs.
            QvaPrint($"Hello World, This {Author}'s way from interedimate to C# Expert. (using QvaPrint Method)");
            Print("This is same as Qvaprint Method, only difference is the structure of code and lets say use for it, Qvaprint will be for Dialogs, and this as a thinking.");
            QvaPrint($"Already seeing difference in code is that when we used this we could add more code into it, easily.");
            int[] numbers = [16, 17, 29, 30];
            QvaPrint($"i've now created array of integers -> {numbers}, is [16,17,29,30] equal to {numbers.ToString} as in code? \nAnswer is: {numbers is [16, 17, 29, 30]}");


            //================================================ B E G I N I N G =======================================================



            //Statement 1 (computes the expression 12*30 and stores the result in variable, named x)
            int x = 12 * 30;
            //Statement 2 (calls WriteLine method on a class called Console, which is defined in namespace called System)
            System.Console.WriteLine(x);
            Print("Now we have learned how Console WriteLine works, and how storing in variable works.");

            int FeetToInches(int Feet)
            {
                int inches = Feet * 12;
                return inches;
            }
            /*
             * {
             * 
             * }
             *  Those braces are called statement block.
             */



            Console.WriteLine(FeetToInches(30));
            Console.WriteLine(FeetToInches(100));
            QvaPrint("Results Above are already a methods, which means we know what methods are now. (i knew im just repeating whole c#)");

            //now my first task to myself is to create QvaPrint Alike thing but difference is to distiguish stuff on screen.

            var MethodPrint = (string msg) =>
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(msg);
                Console.ResetColor();
            };

            QvaPrint($"now let's use our MethodPrint function ->");
            MethodPrint(FeetToInches(30).ToString());
            QvaPrint("Now we know that, green text is me, and that weird color is console output stuff.");

            #region Here is the full list of C# reserved keywords
            /*
        abstract
        as
        base
        bool
        break
        byte
        case
        catch
        char
        checked
        class
        const
        continue
        decimal
        default
        delegate
        do
        double
        else
        enum
        event
        explicit
        extern
        false
        finally
        fixed
        float
        for
        foreach
        goto
        if
        implicit
        in
        int
        interface
        internal
        is
        lock
        long
        namespace
        new
        null
        object
        operator
        out
        override
        params
        private
        protected
        public
        readonly
        record
        ref
        return
        sbyte
        sealed
        short
        sizeof
        stackalloc
        static
        string
        struct
        switch
        this
        throw
        true
        try
        typeof
        uint
        ulong
        unchecked
        unsafe
        ushort
        using
        virtual
        void
        volatile
        while
             */
            #endregion

            #region Contextual keywords (still can use as a variable name)
            /*
            add
            alias
            and
            ascending
            async
            await
            by
            descending
            dynamic
            equals
            file
            from
            get
            global
            group
            init
            into
            join
            let
            managed
            nameof
            nint
            not
            notnull
            nuint
            on
            or
            orderby
            partial
            remove
            required
            select
            set
            unmanaged
            value
            var
            with
            when
            where
            yield
            */
            #endregion
            Line();
            //if we wanna use variable named as reserved keyword we should do something like
            var @using = "this variable is called @using because using is reserved.";
            QvaPrint("lets try @using variable"); MethodPrint(@using);


            UnitConverter feetToInchesConverter = new UnitConverter(12);
            UnitConverter milesToFeetConverter = new UnitConverter(5280);

            Print("I've now created our own type, UnitConverter, then created two instances for it, feetToInchesConverter and milesToFeetConverter");
            QvaPrint($"5 feet to inches is {feetToInchesConverter.Convert(5)}, and five miles to feet is {milesToFeetConverter.Convert(5)}");
            Print("Creating Panda class, which holds population of pandas as a static data member of class, and name as a individual data member.");
            Panda p1 = new Panda("Qvanda");
            Panda p2 = new Panda("Landa");
            Print($"Population of pandas is - {Panda.population}, however names of those are - {p1.name}, {p2.name}");
            QvaPrint("That means that static data member 'Population' holds static data, which is same for every created instance.");
            Line();
            Print("Now I've created value and reference objects, points, ValuePoint and ReferencePoint, to see difference between value types and reference types.");
            ValuePoint valuePoint = new ValuePoint();
            valuePoint.x = 5;
            ValuePoint valuePoint2 = valuePoint;
            QvaPrint($"I've initialized valuePoint which is struct, and gave X - {valuePoint.x} value, and gave valuePoint2, first's value, which is - {valuePoint2.x}, now I will change x's value and show both of them again.");
            valuePoint.x = 7;
            Print($"after changing x to 7 values are, X - {valuePoint.x}, X2 - {valuePoint2.x}");


            Line();


            Print("Now let's demonstrate reference type.");
            ReferencePoint RP = new ReferencePoint();
            RP.x = 5;
            ReferencePoint RP2 = RP;

            Print($"I've now initialized two ReferencePoints, RP's x - {RP.x}, and gave RP2 RP's instance for initialization so RP2's x is - {RP2.x}, now lets change RP-s x");
            RP.x += 5;
            Print($"after changing RP's x - {RP.x}, RP2's x - {RP2.x}");


            Line();



            int aforOverflow = 10000;
            int bforOverflow = 10000;
            QvaPrint($"I can use \"checked\" to check if there is overflow happening which is about numbers doin shitty stuff so u should like check em or smthn, so I made a:{aforOverflow} and b: {bforOverflow}");
            QvaPrint("We will now multiply those and check at the same time, and then print.");

            //there are following two ways for checked.
            int cForOverflowExpression = checked( aforOverflow * bforOverflow);

            checked
            {
                int cForOverflowStatementBlock = aforOverflow * bforOverflow;
            }

            QvaPrint($"After multiplying using expression - {cForOverflowExpression} and with statement block - {cForOverflowExpression}, difference is that statement block checks everything within a block");
            Print("Keep in mind that it incurs a small performance cost.");
            //we can also put settings on top level that it always checks and use "unchecked" when we don't wanna check.


            Line();


            short aForShortOperation = 1, bForShortOperation = 1;
            short zForShortOperation = (short)(aForShortOperation + bForShortOperation); 

            Print($"also keep in mind that if we do operations on \"short\" types, for example if we add 1 to another 1 it will automatically try to cast it to int, and if we define like result as short and try to put sum in it, we will have error, because we will need explict cast there, which means that we need to add smthn like short z = (short)(a + b) thing. " +
                $"\nexample: {aForShortOperation} + {bForShortOperation} = {zForShortOperation} |all of those are short types|");


            Line();


            QvaPrint("I just found out we have positive and negative infinity, and also NaN (not a number), and also -0 thing");
            var nan = double.NaN;
            var Pinfinity = double.PositiveInfinity;
            var Ninfinity = double.NegativeInfinity;
            var minusZero = -0;
            Print($"So NaN - {nan.ToString()}, Positive Infinity - {Pinfinity}, Negative Infinity - {Ninfinity}, minusZero - {minusZero} | those can also be floats and doubles");


            Line();
            // q ? a : b  <-----> (condition) ? if true a evulates : else b evulates
            //conditional operator (ternary operator)
            //(5 == 5) ? Print(" I knew this but there is also conditional operator which I always seem to forget how to write, its condition ? smmthn : else smthn, this will be written by it.") : Print("what?");

            //didn't work coz it needs to be call or smthn idk anyways...
            SomethingDidntWork();


            Line();



            QvaPrint("Now I learned about raw strings / multilines too");
            string raw = """
                <html>
                <head>
                    <link rel=""/>
                </head>
                <body>
                    <p>Simple HTML</p>
                </body>
                </html>
                """;
            MethodPrint(raw);

            Line();
            QvaPrint("look what we can do:");

            MethodPrint($$"""{"TimeStamp": "{{DateTime.Now}}" }""");
            QvaPrint("This is done with double $$ interpolation, basically if you do it like that instead of {} you have to write {{DateTime.Now}} to get smthn.");
            Line();
            // $"" means interpolating (interpolated)
            Line();



            //Arrays.
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            //or (Collection expression [] )
            char[] vowels2 = [ 'a', 'e', 'i', 'o', 'u' ];

            ValuePoint[] a = new ValuePoint[1000];
            int xValuePoint = a[500].x;
            Print($"We have just created array of 1000 Value point struct, when element type is a value type each element value is allocated as part of the array. a[500].x = {xValuePoint}");

            ConsoleOutputVisualizer COV = new ConsoleOutputVisualizer();
            ReferencePoint[] referencePoints = new ReferencePoint[1000];
            try
            {
                int xReferencePoints = referencePoints[500].x;
            }
            catch (Exception e)
            {
                COV.Qdanger(e.Message);
            }
            Print("But well if it is the reference points then we will get this following error. to avoid this we have to loop through each of them and assign new ReferencePoint() to each.");
            QvaPrint("Let's do that.");
            for (int i = 0; i < referencePoints.Length; i++)
            {
                referencePoints[i] = new ReferencePoint();
            }

            try
            {
                int xReferencePoints = referencePoints[500].x;
                Print($"{xReferencePoints} - This is what we get now that we assigned new ReferencePoint() to each element of the array.");
            }
            catch (Exception e)
            {
                COV.Qdanger(e.Message);
            }



            //END=========================================================================================
            Line();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            QvaPrint($"===========================================================================\n" +
                $"====================Last page was -> {LastPage}==============================================\n" +
                $"=====================================================================================");
            Console.ResetColor();
            Console.ReadLine();
        }

        //lets create our type
        public class UnitConverter
        {
            int ratio;
            public UnitConverter(int unitRatio)
            {
                ratio = unitRatio;
            }

            public int Convert(int unit)
            {
                return unit * ratio;
            }
        }

        public class Panda
        {
            public string name;
            public static int population;

            public Panda(string n)
            {
                name = n;
                population++;
            }
        }

        public struct ValuePoint{ public int x, y; }

        public class ReferencePoint { public int x, y; }

    }
}

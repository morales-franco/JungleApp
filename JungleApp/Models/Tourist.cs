using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{

    public class Tourist
    {
        public string Name { get; private set; }
        public Tourist(): this("TOURIST")
        {

        }

        public Tourist(string name)
        {
            Name = name;
        }

        //TODO: Delegate
        private delegate void RunAsChamp(int velocity);
        private delegate int GetNumber();

        //TODO: Event is an action that executes when a specified condition satisfied
        private event Action<int> TiredAlert;

        private void RunAsHorse(int velocity)
        {
            Debug.WriteLine($"[Horse]Run at {velocity}");
        }

        private void RunAsTurtle(int velocity)
        {
            Debug.WriteLine($"[Turtle]Run at {velocity}");
        }

        private void RunAsHuman(int velocity)
        {
            Debug.WriteLine($"[Human]Run at {velocity}");
        }

        private int Get10()
        {
            return 10;
        }
        private int Get20()
        {
            return 20;
        }

        private int Get30()
        {
            return 30;
        }

        private void SaysMyCompleteName(string name, string surname)
        {
            Debug.WriteLine($"Name {name} - Surname {surname}");
        }

        private void Ask(string question)
        {
            Debug.WriteLine($"Question {question}");
        }

        private void SaysSomething(int age, int year, string country)
        {
            Debug.WriteLine($"I'm age {age} years old - Year: { year } - Country: { country }");
        }

        public void Run()
        {
            //TODO: Multicast Delegate
            RunAsChamp delegateRun = new RunAsChamp(RunAsHorse);
            delegateRun += RunAsTurtle;
            delegateRun += RunAsHuman;
            delegateRun(1000);

            //TODO: Multicast Delegate with return value
            GetNumber getNumb = Get10;
            getNumb += Get20;
            getNumb += Get30;

            foreach (GetNumber methodDelegate in getNumb.GetInvocationList())
            {
                Debug.WriteLine($"Method { methodDelegate.Method.Name } - Return Value { methodDelegate() }");
            }

            /*
             * TODO: Action
             * Action<> is a generic delegate. It can be used with methods that AT LEAST have one argument and don’t return
             * a value. Action<> delegate comes with 16 generic overloads, which means it can take up to 16 arguments of
             * void method
             * 
             * 1..16 Parameters (Required 1 parameter minimun) And NOT RETURN anything
             * 
             */
            Action<string, string> talk1 = SaysMyCompleteName;
            Action<string> talk2 = Ask;
            Action<int, int, string> talk3 = SaysSomething;

            Debug.WriteLine("############ Action ############");
            Presentation(talk1, talk2, talk3);

            /*
             * TODO: Function
             * Func<> is a generic delegate. It can be used with methods that return a value and may have a parameter list.
             * The last parameter of Func<> determines the method’s return type and the remaining parameters are used
             * for a method’s argument list. Func<> delegate comes with 17 generic overloads, which means it uses the last
             * parameter as a method’s return type and the remaining 16 can be used as a method’s argument list. Also, if
             * the Func<> has only one parameter, then its first parameter would be considered as a method’s return type.
             * 
             * 0..16 Parameters + 1(return value)
             * Parameter No required
             */

            Func<string, string, int, string, DateTime, string> getPersonalInfoFunc = GetPersonalInformation;

            Debug.WriteLine("############ Func ############");
            TellMeYourExperiences(getPersonalInfoFunc);

            /*
             * TODO: Predicate
             * A predicate delegate represents a method that takes one input parameter and returns a bool value on the
             * basis of some criteria.
             */

            Predicate<int> isAdultPred = IsAdult;

            if (isAdultPred(18))
                Debug.WriteLine("IS ADULT!");

            //TODO: Anonymous method that does NOT return value
            Action<int> tellMeIsAdult = delegate (int age)
            {
                if (age >= 18)
                    Debug.WriteLine("IS ADULT!");
            };

            //TODO: Anonymous method that does return value
            Func<int, bool> checkIsAdult = delegate (int age)
            {
                return age >= 18;
            };

            tellMeIsAdult(18);
            if (checkIsAdult(18))
                Debug.WriteLine("IS ADULT!");

            //TODO: Lambda Expression that doesn't return value
            Action<int> tellMeIsAdult2 = (int age) =>
            {
                if (age >= 18)
                    Debug.WriteLine("[Lambda] IS ADULT!(1)");
            };

            //TODO: Lambda Expression that does have return value
            Func<int, bool> getMeAdult = (int age) =>
            {
                return age >= 18;
            };

            tellMeIsAdult2(21);
            if (getMeAdult(21))
                Debug.WriteLine("[Lambda] IS ADULT! (2)");

            Debug.WriteLine("############ Events ############");
            TiredAlert += OnAlert;

            RunKm(10);
            RunKm(20);
            RunKm(30);
        }

        private void RunKm(int kilometers)
        {
            Debug.WriteLine($"Run { kilometers } km");

            if (TiredAlert == null)
                return;

            if (kilometers > 10)
                TiredAlert(kilometers);

        }

        private void OnAlert(int km)
        {
            Debug.WriteLine($"I'm tired! I don't want to run { km } km");
        }

        private bool IsAdult(int age)
        {
            return age >= 18;
        }

        private void TellMeYourExperiences(Func<string, string, int, string, DateTime, string> functionGetInfo)
        {
            var data = functionGetInfo("Cosme", "Fulanito", 28, "Argentina", new DateTime(1990, 06, 04));
            Debug.WriteLine($"Personal Information: { data }");
        }

        private string GetPersonalInformation(string name, string surname, int age, string country, DateTime birthday)
        {
            return $"Complete Name : { surname } {name} - { age } - { country } - { birthday.ToString("dd/MM/yyyy HH:mm") }";
        }

        private void Presentation(Action<string, string> functionName, Action<string> funtionAsk, Action<int, int, string> functionSomething)
        {
            functionName("Cosme", "Fulanito");
            funtionAsk("How you doing?");
            functionSomething(28, 2019, "Argentina");
        }
    }
}

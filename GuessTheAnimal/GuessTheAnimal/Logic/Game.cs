using System.Collections.Generic;
using System.Linq;
using GuessTheAnimal.Interface;
using GuessTheAnimal.Model;

namespace GuessTheAnimal.Logic
{
    public class Game
    {
        private readonly QuestionAndAnswer[] _questionAndAnswers = new QuestionAndAnswer[]
        {
            new QuestionAndAnswer {Type = QuestionType.Feature, Question = "What kind of feature does it have?"},
            new QuestionAndAnswer {Type = QuestionType.Sound, Question = "How does it make sound?"},
            new QuestionAndAnswer {Type = QuestionType.Colour, Question = "What is its colour?"}
        };

        private const string _initialQuestion = "***** Game starts now. Please pick up an animal from the list. I'll guess what it is.";
        private const string _storageFile = @"Data\Animals.csv";

        private readonly IConsoleDisplay _consoleDisplay;

        public Game (IConsoleDisplay consoleDisplay)
        {
            _consoleDisplay = consoleDisplay;
        }

        public void Play()
        {
            var allAnimals = new Animal().GetStoredAnimals(_storageFile);

            while (true)
            {
                DisplayIntroduction();

                DisplayAnimalList(allAnimals);

                var candidate = GetAllAnswers();

                var name = FindMatchingAnimal(allAnimals, candidate);

                _consoleDisplay.OutputEmptyLine();

                if (string.IsNullOrEmpty(name))
                    _consoleDisplay.OutputLine("Sorry, I don't know the animal.");
                else
                    _consoleDisplay.OutputLine($"I know. It is {name}.");

                _consoleDisplay.OutputEmptyLine();
            }
        }

        private void DisplayIntroduction()
        {
            _consoleDisplay.OutputLine(_initialQuestion);
        }

        private void DisplayAnimalList(IEnumerable<Animal> animals)
        {
            _consoleDisplay.OutputEmptyLine();

            animals.ToList().ForEach(x =>
            {
                _consoleDisplay.OutputLine(x.Name);
            });

            _consoleDisplay.OutputEmptyLine();
        }

        private string GetAnswerForQuestion(int questionIndex)
        {
            _consoleDisplay.OutputLine(_questionAndAnswers[questionIndex].Question);
            return _consoleDisplay.GetInputLine();
        }

        private Animal GetAllAnswers()
        {
            var animal = new Animal();

            _consoleDisplay.OutputEmptyLine();

            _consoleDisplay.OutputLine("Before I guess, please tell me something about the animal.");

            _consoleDisplay.OutputEmptyLine();

            for (int i = 0; i < _questionAndAnswers.Count(); i++)
            {
                switch (_questionAndAnswers[i].Type)
                {
                    case QuestionType.Feature:
                        animal.Feature = GetAnswerForQuestion(i);
                        break;

                    case QuestionType.Sound:
                        animal.Sound = GetAnswerForQuestion(i);
                        break;

                    case QuestionType.Colour:
                        animal.Colour = GetAnswerForQuestion(i);
                        break;
                }
            }

            return animal;
        }

        private string FindMatchingAnimal(IEnumerable<Animal> animals, Animal input)
        {
            foreach(var animal in animals)
            {
                var animalName = animal.GetName(input);
                if (!string.IsNullOrEmpty(animalName))
                    return animalName;
            }

            return string.Empty;
        }
    }
}

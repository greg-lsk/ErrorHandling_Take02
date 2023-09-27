using ConsoleApp.Entities;
using ConsoleApp.ValueTypes;
using ErrorHandling.Evaluating;


var evaluation = Evaluation.Init();

evaluation.Evaluate(Person.Create(Name.Create("gregg"),
                                  Name.Create("Allman")))
          .Print();
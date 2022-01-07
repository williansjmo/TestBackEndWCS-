using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Test.Domain.Entities;

namespace Test.Domain.Validations
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(r=> r.Name)
                .NotEmpty()
                .WithMessage("Debe de introducir el nombre.");
            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("Debe de introducir el apellido.");
            RuleFor(r => r.Age)
                .NotEmpty()
                .WithMessage("Debe de introducir la edad.")
                .Must(ValidationNumer)
                .WithMessage("La edad debe ser mayor a 0.");
            RuleFor(r => r.Identification)
                .NotEmpty()
                .WithMessage("Debe de introducir el numero de identificación.");
            RuleFor(r => r.HouseAspire)
                .NotEmpty()
                .WithMessage("Debe de introducir la casa a la que aspira pertenecer.")
                .Must(ValidationHouseAspire)
                .WithMessage("Debe de introducir una casa a la que aspira pertenecer valida.");
        }

        private bool ValidationHouseAspire(string value)
        {
            List<string> HouseAspireList = new List<string>() { "Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin" };
            return HouseAspireList.Any(a => a.ToLower() == value.ToLower());
        }


        private bool ValidationNumer(int value) => value == 0 ? false : true;
    }
}

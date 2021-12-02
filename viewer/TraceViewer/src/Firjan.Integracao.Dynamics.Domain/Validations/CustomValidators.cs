using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor.Tipos.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Models.Utility;
using FluentValidation;
using FluentValidation.Validators;
using System;

namespace Firjan.Integracao.Dynamics.Domain.Validations
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, int?> GreaterThanZero<T>(this IRuleBuilder<T, int?> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThan(0);
        }

        public static IRuleBuilderOptions<T, int> GreaterThanZero<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThan(0);
        }

        public static IRuleBuilderOptions<T, string> Greater<T>(this IRuleBuilder<T, string> ruleBuilder, int tam)
        {
            return ruleBuilder
                .Length(1, tam)
                .WithMessage(String.Concat("{PropertyName} must be at least 1 but no more than ",tam," characters long."));
        }

        public static IRuleBuilderOptions<T, short> Greater<T>(this IRuleBuilder<T, short> ruleBuilder, int tam)
        {
            return ruleBuilder
                .GreaterThan((short)tam)
                .WithMessage(String.Concat("{PropertyName} must be at least 1 but no more than ", tam, " characters long."));
        }

        public static IRuleBuilderOptions<T, char> GreaterThanZero<T>(this IRuleBuilder<T, char> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThan((char)0)
                .WithMessage("Id unique identifier must be greater to 0");
        }

        public static IRuleBuilderOptions<T, short> GreaterThanZero<T>(this IRuleBuilder<T, short> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThan((short)0)
                .WithMessage("Id unique identifier must be greater to 0");
        }


        public static IRuleBuilderOptions<T, short?> GreaterThanZero<T>(this IRuleBuilder<T, short?> ruleBuilder)
        {
            return ruleBuilder
                .GreaterThan((short)0)
                .WithMessage("Id unique identifier must be greater to 0");
        }

        public static IRuleBuilderOptions<T, Face> IsValidFace<T>(this IRuleBuilder<T, Face> ruleBuilder)
        {
            return ruleBuilder
              .Must(x => x == null || x.IsEqualTo(Face.Sim))
              .WithMessage("{PropertyName} must be null or S");
        }

        public static IRuleBuilderOptions<T, Raiz> IsValidRaiz<T>(this IRuleBuilder<T, Raiz> ruleBuilder)
        {
            return ruleBuilder
              .Must(x => x == null || x.IsEqualTo(Raiz.Sim))
              .WithMessage("{PropertyName} must be null or S");
        }

        public static IRuleBuilderOptions<T, int?> IsRequired<T>(this IRuleBuilder<T, int?> ruleBuilder)
        {
            return ruleBuilder
              .GreaterThanZero()
              .WithMessage("{PropertyName} must not be null or empty or zero");
        }

        public static IRuleBuilderOptions<T, Int32> IsRequired<T>(this IRuleBuilder<T, Int32> ruleBuilder)
        {
            return ruleBuilder
              .GreaterThanZero()
              .WithMessage("{PropertyName} must not be null or empty or zero");
        }

        public static IRuleBuilderOptions<T, object> IsRequired<T>(this IRuleBuilder<T, object> ruleBuilder)
        {
            return ruleBuilder
               .NotNull()
                .NotEmpty()
              .WithMessage("{PropertyName} must not be null or empty or zero");
        }

        public static IRuleBuilderOptions<T, string> NotNullNotEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, short> NotNullNotEmpty<T>(this IRuleBuilder<T, short> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, char> NotNullNotEmpty<T>(this IRuleBuilder<T, char> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, char?> NotNullNotEmpty<T>(this IRuleBuilder<T, char?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, DateTime?> NotNullNotEmpty<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, DateTime> NotNullNotEmpty<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, short?> NotNullNotEmpty<T>(this IRuleBuilder<T, short?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, byte> NotNullNotEmpty<T>(this IRuleBuilder<T, byte> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, Enums<byte?>> NotNullNotEmpty<T>(this IRuleBuilder<T, Enums<byte?>> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, Enums<char?>> NotNullNotEmpty<T>(this IRuleBuilder<T, Enums<char?>> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, byte[]> NotNullNotEmpty<T>(this IRuleBuilder<T, byte[]> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }


        public static IRuleBuilderOptions<T, Enums<string>> NotNullNotEmpty<T>(this IRuleBuilder<T, Enums<string>> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, byte?> NotNullNotEmpty<T>(this IRuleBuilder<T, byte?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, int?> NotNullNotEmpty<T>(this IRuleBuilder<T, int?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, int> NotNullNotEmpty<T>(this IRuleBuilder<T, int> ruleBuilder)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, Enumeration> NotNullNotEmpty<T>(this IRuleBuilder<T, Enumeration> ruleBuilder)
        {
            return ruleBuilder
                .Must(x => x == null)
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, bool> BoolNotNullNotEmpty<T>(this IRuleBuilder<T, bool> ruleBuilder)
        {
            return ruleBuilder
                .Must(x => x == false || x == true)
                .WithMessage("{PropertyName} must not be null or empty");
        }

        public static IRuleBuilderOptions<T, TProperty> IsValidDomain<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsInEnumValidator<TProperty>());
        }
    }

    public class IsInEnumValidator<T> : PropertyValidator
    {
        public IsInEnumValidator() : base("Property {PropertyName} it not a valid value.") { }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (!typeof(T).IsEnum) return false;
            return Enum.IsDefined(typeof(T), context.PropertyValue);
        }
    }
}

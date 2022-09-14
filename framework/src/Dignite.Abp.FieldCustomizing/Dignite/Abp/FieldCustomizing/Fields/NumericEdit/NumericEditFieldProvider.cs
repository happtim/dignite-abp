﻿namespace Dignite.Abp.FieldCustomizing.Fields.NumericEdit;

/// <summary>
///
/// </summary>
public class NumericEditFieldProvider : FieldProviderBase
{
    public const string ProviderName = "NumericEdit";

    public override string Name => ProviderName;

    public override string DisplayName => L["NumericEditControl"];

    public override FieldType ControlType => FieldType.Simple;

    public override void Validate(FieldValidateArgs args)
    {
        var configuration = new NumericEditConfiguration(args.FieldDefinition.Configuration);
        decimal value = decimal.MinValue;

        if (configuration.Required && (args.Value == null || args.Value.ToString().Length == 0))
        {
            args.ValidationErrors.Add(
                new System.ComponentModel.DataAnnotations.ValidationResult(
                    L["ValidateValue:Required"],
                    new[] { args.FieldDefinition.Name }
                    ));
        }
        else
        {
            if (decimal.TryParse(args.Value.ToString(), out value))
            {
                args.ValidationErrors.Add(
                    new System.ComponentModel.DataAnnotations.ValidationResult(
                        L["ValidateValue:NotNumericType"],
                        new[] { args.FieldDefinition.Name }
                        ));
            }
        }

        if (value != decimal.MinValue && configuration.Max.HasValue && configuration.Max.Value < value)
        {
            args.ValidationErrors.Add(
                new System.ComponentModel.DataAnnotations.ValidationResult(
                    L["ValueCannotBeGreaterThan", args.FieldDefinition.DisplayName, configuration.Max.Value],
                    new[] { args.FieldDefinition.Name }
                    ));
        }

        if (value != decimal.MinValue && configuration.Min.HasValue && configuration.Min.Value > value)
        {
            args.ValidationErrors.Add(
                new System.ComponentModel.DataAnnotations.ValidationResult(
                    L["ValueCannotBeLessThan", args.FieldDefinition.DisplayName, configuration.Min.Value],
                    new[] { args.FieldDefinition.Name }
                    ));
        }
    }

    public override FieldConfigurationBase GetConfiguration(FieldConfigurationDictionary fieldConfiguration)
    {
        return new NumericEditConfiguration(fieldConfiguration);
    }
}
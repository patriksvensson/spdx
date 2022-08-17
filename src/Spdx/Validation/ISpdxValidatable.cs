namespace Spdx.Validation;

internal interface ISpdxValidatable
{
    void Validate(SpdxValidationContext context);
}

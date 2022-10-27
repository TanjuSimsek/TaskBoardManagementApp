﻿using FluentValidation;
using TaskBoardManagementApp.Application.IssueDetails.Constants;

namespace TaskBoardManagementApp.Application.IssueDetails.Commands.CreateIssueDetail;

public class CreateIssueDetailCommandValidator : AbstractValidator<CreateIssueDetailCommand>
{
    public CreateIssueDetailCommandValidator()
    {
        RuleFor(x => x.IssueId)
            .NotEmpty()
            .NotNull()
            .WithMessage($"{IssueDetailMessages.IssueIdCannotBeEmpty}");
    }
}
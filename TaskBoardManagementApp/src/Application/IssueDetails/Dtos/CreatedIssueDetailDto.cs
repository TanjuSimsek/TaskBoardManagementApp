﻿namespace TaskBoardManagementApp.Application.IssueDetails.Dtos;

public record CreatedIssueDetailDto
{
    public Guid Id { get; set; }
    public Guid IssueId { get;  set; }
    public string Description { get;  set; }
}